using System.ComponentModel;
using System.Security.Principal;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n\n");
        Console.WriteLine($"{_description}\n\n");
        Console.WriteLine("How long, in seconds, would you like for your session? (Note: If input is not valid, default session length of 30 seconds will be used.)");

        string response = Console.ReadLine();

        if(int.TryParse(response, out int value))
        {
            _duration = Convert.ToInt32(response);
        }

        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine("\n");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>{ "|", "/", "-", "\\", "|", "/", "-", "\\" };

        int i = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;
        
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int second)
    {
        for (int i = second; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if (i < 10)
            {
                Console.Write("\b \b");
            }
            else 
            {
                Console.Write("\b\b  \b\b");
            }
        }
    }
}