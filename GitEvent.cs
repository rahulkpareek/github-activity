


using System.Runtime.InteropServices.JavaScript;    
using Newtonsoft.Json;


public class GitRepository
{
    [JsonProperty("name")]
    public string RepositoryName { get; set; }
    [JsonProperty("url")]
    public string RepositoryUrl { get; set; }

    public GitRepository()
    {
        RepositoryName = string.Empty;
        RepositoryUrl = string.Empty;
    }
}


public class Author
{
    [JsonProperty("name")]
    public string AuthorName { get; set; }
    [JsonProperty("email")]
    public string AuthorEmail { get; set; }

    public Author()
    {
        AuthorName = string.Empty;
        AuthorEmail = string.Empty;
    }
}


public class Commit
{
    [JsonProperty("sha")]
    public string CommitSha { get; set; }
    [JsonProperty("message")]
    public string CommitMessage { get; set; }
    [JsonProperty("author")]
    public Author CommitAuthor { get; set; }

    Commit()
    {
        CommitSha = string.Empty;
        CommitMessage = string.Empty;
        CommitAuthor = new Author();
    }
}


public class PullRequest
{
    [JsonProperty("url")]
    public string PullRequestUrl { get; set; }
    [JsonProperty("title")]
    public string PullRequestTitle { get; set; }

    public PullRequest()
    {
        PullRequestUrl = string.Empty;
        PullRequestTitle = string.Empty;
    }

}


public class Payload
{
    [JsonProperty("commits")]
    public List<Commit> Commits { get; set; }

    [JsonProperty("pull_request")]
    public PullRequest PullRequest { get; set; }

    public Payload()
    {
        Commits = new List<Commit>();
        PullRequest = new PullRequest();
    }
}

public class GitEvent
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("repo")]
    public GitRepository Repository { get; set; }
    [JsonProperty("payload")]
    public Payload Payload { get; set; }
    [JsonProperty("public")]
    public string IsPublic {get; set; }
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    GitEvent()
    {
        Type = string.Empty;
        Repository = new GitRepository();
        Payload = new Payload();
        IsPublic = string.Empty;
        CreatedAt = DateTime.MinValue;
    }
}

