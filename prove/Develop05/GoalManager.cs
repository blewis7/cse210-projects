public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _rank;
    private List<string> _allRanks = new List<string>{ "None", "Bronze", "Silver", "Gold", "Master" };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _rank = "None";
    }

    public void DisplayMenu()
    {
        Console.WriteLine($"\nYou have {_score} points. \n");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t 1. Create New Goal");
        Console.WriteLine("\t 2. List Goals");
        Console.WriteLine("\t 3. Save Goals");
        Console.WriteLine("\t 4. Load Goals");
        Console.WriteLine("\t 5. Record Event");
        Console.WriteLine("\t 6. Get Current Rank");
        Console.WriteLine("\t 7. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public void DisplayTypesOfGoals()
    {
        Console.WriteLine("The types of Goals are::");
        Console.WriteLine("\t 1. Simple Goal");
        Console.WriteLine("\t 2. Eternal Goal");
        Console.WriteLine("\t 3. Checklist Goal");
    }

    public void RecordEvent()
    {
        Helper helper = new Helper();
        Console.WriteLine("The goals are:");

        int currentIndex = 0;
        foreach(var goal in _goals)
        {
            Console.WriteLine($"{currentIndex + 1}. {goal.GetName()}");
            currentIndex++;
        }

        int index = helper.CheckAndReturnValidInt("Which goal did you accomplish?");

        int earnedPoints = _goals[index - 1].RecordEvent();
        CheckForRankUpgrade(_score, earnedPoints);
        _score += earnedPoints;
        Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void CreateGoal()
    {
        Helper helper = new Helper();
        DisplayTypesOfGoals();
        int goalInput = helper.CheckAndReturnValidInt("Which type of goal would you like to create?");

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        int points = helper.CheckAndReturnValidInt("What is the amount of points associated with this goal?");

        if (goalInput == 1)
        {
            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
            _goals.Add(simpleGoal);
        }
        else if (goalInput == 2)
        {
            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            _goals.Add(eternalGoal);
        }
        else 
        {
            int target = helper.CheckAndReturnValidInt("How many times does this goal need to be accomplished for a bonus?");
            int bonus = helper.CheckAndReturnValidInt("What is the bonus for accomplishing it that many times?");

            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklistGoal);
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            _goals[i].ShowDetailsString(i);
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void Save()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{_score}");
            _goals.ForEach(goal => {
                outputFile.WriteLine(goal.GetStringRepresentation());
            });
        }
    }

    public void Load()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try 
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            _score = Convert.ToInt32(lines[0]);
            SetRank();

            for (int i = 1; i < lines.Length; i++)
            {
                string currentLine = lines[i];
                int index = currentLine.IndexOf(":");
                string goalType = currentLine.Substring(0, index);
                currentLine = currentLine.Substring(index + 1);

                if (goalType == "SimpleGoal")
                {
                    string[] categories = currentLine.Split("|");
                    string name = categories[0];
                    string description = categories[1];
                    int points = Convert.ToInt32(categories[2]);
                    bool isComplete = Convert.ToBoolean(categories[3]);

                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points, isComplete);
                    _goals.Add(simpleGoal);
                }
                else if (goalType == "EternalGoal")
                {
                    string[] categories = currentLine.Split("|");
                    string name = categories[0];
                    string description = categories[1];
                    int points = Convert.ToInt32(categories[2]);

                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                    _goals.Add(eternalGoal);
                }
                else 
                {
                    string[] categories = currentLine.Split("|");
                    string name = categories[0];
                    string description = categories[1];
                    int points = Convert.ToInt32(categories[2]);
                    int bonus = Convert.ToInt32(categories[3]);
                    int target = Convert.ToInt32(categories[4]);
                    int amountCompleted = Convert.ToInt32(categories[5]);

                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                    _goals.Add(checklistGoal);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Invalid File Name!");
            Console.WriteLine(ex);
        }
    }

    public void SetRank()
    {
        if (_score >= 4000)
        {
            _rank = "Master";
        }
        else if (_score >= 3000)
        {
            _rank = "Gold";
        }
        else if (_score >= 2000)
        {
            _rank = "Silver";
        }
        else if (_score >= 1000)
        {
            _rank = "Bronze";
        }
        else
        {
            _rank = "None";
        }
    }

    public void DisplayRank()
    {
        Console.WriteLine($"Your current rank is {_rank}");
    }

    public void CheckForRankUpgrade(int previousScore, int addedPoints)
    {
        if (previousScore >= 4000)
        {
            return;
        }

        if ((previousScore % 1000) + addedPoints >= 1000)
        {
            int index = _allRanks.IndexOf(_rank);
            _rank = _allRanks[index + 1];

            Console.WriteLine("********************************************\n");
            Console.WriteLine($"Congratulations! You have ranked up to {_rank}!");
            Console.WriteLine("\n********************************************");
        }
    }
}