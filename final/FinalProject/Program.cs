using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool goalsLoaded = false;
        bool finished = false;
        Helper helper = new Helper();
        DailyTotalsManager dailyTotalsManager = new DailyTotalsManager();

        // var firstDayOfWeek = DateTime.Now.FirstDayOfWeek();
        // var lastDayOfWeek = DateTime.Now.LastDayOfWeek();

        // var dates = new List<DateTime>();

        // for (var dt = firstDayOfWeek; dt <= lastDayOfWeek; dt = dt.AddDays(1))
        // {
        // dates.Add(dt);
        // }

        // dates.ForEach(date =>{
        //     Console.WriteLine(date);
        // });

        // bool exists = System.IO.File.Exists("Goals/goals.txt");
        // bool exists2 = System.IO.File.Exists("Dailys/goals.txt");
        // Console.WriteLine(exists);
        // Console.WriteLine(exists2);


        while (finished == false)
        {
            goalManager.DisplayMenu();
            string response = Console.ReadLine();

            if (response == "1")
            {
                goalManager.RunGoalCreation();
            }
            else if (response == "2")
            {
                Console.WriteLine("What is the filename for the goals you want to retrieve?");
                string filename = Console.ReadLine();
                goalManager.LoadGoals(filename);
                goalsLoaded = true;
            }
            else if (response == "3")
            {
                if (goalsLoaded == false)
                {
                    Console.WriteLine("Goals must be loaded first!");
                }
                else 
                {
                    goalManager.ShowVariables();
                }
            }
            else if (response == "4")
            {
                dailyTotalsManager.RunRecord(goalManager, goalsLoaded);
            }
            else if (response == "5")
            {
                try 
                {
                    string filename = DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "_") + ".txt";
                    if (System.IO.File.Exists($"Dailys/{filename}"))
                    {
                        dailyTotalsManager.Load(filename);
                    }
                    else 
                    {
                        Console.WriteLine("File for today does not exist. Save files for today before loading.");
                    }  
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else if (response == "6")
            {
                if (dailyTotalsManager.GetGoals().Count < 1)
                {
                    dailyTotalsManager.GetGoalTotalsFromWeek(goalManager);
                }
                dailyTotalsManager.Save();
            }
            else if (response == "7")
            {
                dailyTotalsManager.ShowVariables();
            }
            else if (response == "8")
            {
                DailyTotalsManager weekTotals = new DailyTotalsManager();
                weekTotals.SaveWeekGoals();
            }
            else if (response == "9")
            {
                Console.WriteLine("Enter any date from the week you are looking for (must be MM/dd/yyyy format).");
                string date = Console.ReadLine();
                try 
                {
                    string filename = helper.GetWeeklyFilename(date);
                    DailyTotalsManager temp = new DailyTotalsManager();
                    temp.LoadWeeklyFile(filename);
                    temp.ShowVariables();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    helper.DisplayErrorMessage();
                }
            }
            else if (response == "10")
            {
                finished = true;
            }
            else 
            {
                helper.DisplayErrorMessage();
            }
        } 
    }
}