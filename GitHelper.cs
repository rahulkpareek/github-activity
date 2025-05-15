using Newtonsoft.Json;
public class GitHelper
{
    private const string GitHubApiUrl = "https://api.github.com/users/{0}/events";
    
    public List<string> GetActivityFromUsername(string username)
    {
        string url = string.Format(GitHubApiUrl, username);

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
            var response = client.GetAsync(url).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch data from GitHub API: {response.StatusCode}");
            }

            var content = ParseGitHubActivity(response.Content.ReadAsStringAsync().Result);
            if (content==null || content.Count == 0)
            {
                throw new Exception("No activity found for the provided username.");
            }

            return content;
        }
    }

    public List<string> ParseGitHubActivity(string json)
    {
        var events = JsonConvert.DeserializeObject<List<GitEvent>>(json);
        var messages = new List<string>();
        if (events == null || events.Count == 0)
        {
            return messages;
        }

        foreach (var gitEvent in events)
        {
            if (gitEvent.Type == "PushEvent")
            {
                var payload = gitEvent.Payload;
                if (payload != null && payload.Commits != null && payload.Commits.Count > 0)
                {
                   foreach (var commit in payload.Commits)
                    {
                        if (commit == null)
                        {
                            continue;
                        }
                        messages.Add(FormatCommitInfo(gitEvent, commit));
                    }
                }
            }
            else if (gitEvent.Type == "PullRequestEvent")
            {
               var payload = gitEvent.Payload;
                if (payload != null && payload.PullRequest != null)
                {
                    var pullreq = payload.PullRequest;

                    messages.Add(FormatPullRequestInfo(gitEvent, pullreq));
                }
            }
            else
            {
                messages.Add(FormatGenericEventInfo(gitEvent));
            }
        }

        return messages;
    }

    private string FormatCommitInfo(GitEvent gitEvent, Commit commit)
    {
        return $"Repository: {gitEvent.Repository.RepositoryName}, Commit: {commit.CommitSha}, Message: {commit.CommitMessage}, Date: {gitEvent.CreatedAt}, Author: {commit.CommitAuthor.AuthorName} <{commit.CommitAuthor.AuthorEmail}>";
    }

    private string FormatPullRequestInfo(GitEvent gitEvent, PullRequest pullRequest)
    {
        return $"Repository: {gitEvent.Repository.RepositoryName}, Pull Request: {pullRequest.PullRequestUrl}, Title: {pullRequest.PullRequestTitle}, Date: {gitEvent.CreatedAt}";
    }

    private string FormatGenericEventInfo(GitEvent gitEvent)
    {
        return $"Repository: {gitEvent.Repository.RepositoryName}, Event Type: {gitEvent.Type}, Date: {gitEvent.CreatedAt}";
    }

}