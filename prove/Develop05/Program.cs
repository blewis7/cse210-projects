using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool finished = false;

        while (finished == false)
        {
            goalManager.DisplayMenu();
            string response = Console.ReadLine();

            if (response == "1")
            {
                goalManager.CreateGoal();
            }
            else if (response == "2")
            {
                goalManager.ListGoals();
            }
            else if (response == "3")
            {
                goalManager.Save();
            }
            else if (response == "4")
            {
                goalManager.Load();
            }
            else if (response == "5")
            {
                goalManager.RecordEvent();
            }
            else if (response == "6")
            {
                goalManager.DisplayRank();
            }
            else if (response == "7")
            {
                finished = true;
            }
            else
            {
                Console.WriteLine($"Invalid response!");
            }
        }
    }
}