# GitHub Activity Viewer

A simple console application that displays a user's recent GitHub activities, including commits, pull requests, and other events.

## Features

- Fetches recent GitHub activities for any public GitHub username
- Displays detailed information about:
  - Push events (commits)
  - Pull request events
  - Other GitHub events
- Color-coded console output for better readability

## Requirements

- .NET 9.0 or higher
- Newtonsoft.Json package (automatically restored via NuGet)

## Installation

1. Clone the repository:
```powershell
git clone https://github.com/yourusername/github-activity.git
cd github-activity
```

2. Build the project:
```powershell
dotnet build
```

## Usage

1. Run the application:
```powershell
dotnet run
```

2. When prompted, enter a GitHub username and press Enter
3. The application will display the user's recent GitHub activities

Example output:
```
Enter your github username:
octocat

Here are the latest activities for the user: octocat

Repository: octocat/Hello-World, Commit: a123b4c, Message: Update README.md, Date: 2025-05-14, Author: Octocat <octocat@github.com>
Repository: octocat/Spoon-Knife, Pull Request: https://github.com/octocat/Spoon-Knife/pull/1, Title: Add new feature, Date: 2025-05-13
```

## Contributing

Feel free to open issues or submit pull requests to help improve this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
