// See https://aka.ms/new-console-template for more information
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter your github username: ");
        string username = Console.ReadLine();

        if(string.IsNullOrEmpty(username))
        {
            DisplayErrorMessasge("\nUsername cannot be empty.\n");
            return;
        }

        try
        {
            GitHelper gitHelper = new GitHelper();
            var activities = gitHelper.GetActivityFromUsername(username);
            if (activities == null || activities.Count == 0)
            {
                DisplayErrorMessasge("No activity found for the provided username.");
                return;
            }

            DisplaySuccessMessasge($"Here are the latest activities for the user: {username}\n");
            int Count = 0;
            foreach (var activity in activities)
            {
                if (activity == null)
                {
                    continue;
                }
                Console.WriteLine("Activity " + ++Count);    
                Console.WriteLine(activity);
                Console.WriteLine("--------------------------------------------------");
            }
            DisplaySuccessMessasge("\n Press any key to exit...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            DisplayErrorMessasge($"An error occurred: {ex.Message}");
            return;
        }
    }

    private static void DisplaySuccessMessasge(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void DisplayErrorMessasge(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
