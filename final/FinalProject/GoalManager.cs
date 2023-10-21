public class GoalManager
{
    // private Food _totalCalories;
    private Macros _macros;
    private WaterIntake _waterIntake;
    private string _date;
    private double _weight;
    private List<Goal> _otherGoals;

    public GoalManager()
    {
        // _totalCalories = new Food();
        _macros = new Macros();
        _waterIntake = new WaterIntake();
        _date = DateTime.Now.ToString("MM/dd/yyyy");
        _otherGoals = new List<Goal>();
    }

    public List<Goal> GetOtherGoals()
    {
        return _otherGoals;
    }

    public Macros GetMacros()
    {
        return _macros;
    }

    public WaterIntake GetWaterIntake()
    {
        return _waterIntake;
    }

    public void ShowVariables()
    {
        Console.WriteLine($"Calories: {_macros.GetCalories()}");
        Console.WriteLine($"carbGrams: {_macros.GetCarbGrams()}, carbPercent: {_macros.GetCarbPercent()}");
        Console.WriteLine($"proteinGrams: {_macros.GetProteinGrams()}, proteinPercent: {_macros.GetProteinPercent()}");
        Console.WriteLine($"fatGrams: {_macros.GetFatGrams()}, fatPercent: {_macros.GetFatPercent()}");
        Console.WriteLine($"waterIntake: {_waterIntake.GetOunces()}");
        Console.WriteLine($"date: {_date}");
        Console.WriteLine($"weight: {_weight}");
        _otherGoals.ForEach(goal => {
            Console.WriteLine(goal.ShowGoalVariables());
        });
    }

    public void DisplayMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("\t1. Create Goals");
        Console.WriteLine("\t2. Load Goals");
        Console.WriteLine("\t3. Display Goals");
        Console.WriteLine("\t4. Record Variable");
        Console.WriteLine("\t5. Load Today's Values");
        Console.WriteLine("\t6. Save Today's Values");
        Console.WriteLine("\t7. Display Today's Values");
        Console.WriteLine("\t8. Save Week Averages");
        Console.WriteLine("\t9. Display Week Averages");
        Console.WriteLine("\t10. Quit");
    }

// Needs to go to DailyTotalsManager class
    public void DisplayVariableMenu()
    {
        Console.WriteLine("What type of variable would you like to input?");
        Console.WriteLine("\t1. Calories");
        Console.WriteLine("\t2. Water Intake");
        Console.WriteLine("\t3. Weight");
        Console.WriteLine("\t4. Exercise");
        Console.WriteLine("\t5. Other");
    }

    public void LoadGoals(string filename)
    {
        try 
        {
            string[] lines = System.IO.File.ReadAllLines($"Goals/{filename}");

            _date = lines[0];
            _weight = Convert.ToDouble(lines[1].Substring(lines[1].IndexOf(":") + 1));
            _macros.SetCalories(Convert.ToInt32(lines[2].Substring(lines[2].IndexOf(":") + 1)));
            _waterIntake.SetOunces(Convert.ToInt32(lines[3].Substring(lines[3].IndexOf(":") + 1)));

            for (int i = 4; i < 7; i++)
            {
                string currentLine = lines[i];
                int index = currentLine.IndexOf(":");
                int pipeIndex = currentLine.IndexOf("|");

                // string grams = currentLine.Substring(index + 1, pipeIndex - index - 1);
                // string percent = currentLine.Substring(pipeIndex + 1);

                double grams = Convert.ToDouble(currentLine.Substring(index + 1, pipeIndex - index - 1));
                double percent = Convert.ToDouble(currentLine.Substring(pipeIndex + 1));

                if (i == 4)
                {
                    _macros.SetProteinGrams(grams);
                    _macros.SetProteinPercent(percent);
                }
                else if (i == 5)
                {
                    _macros.SetFatGrams(grams);
                    _macros.SetFatPercent(percent);
                }
                else 
                {
                    _macros.SetCarbGrams(grams);
                    _macros.SetCarbPercent(percent);
                }
            }

            for (int i = 7; i < lines.Length; i++)
            {
                string currentLine = lines[i];
                int index = currentLine.IndexOf(":");
                string goalType = currentLine.Substring(0, index);
                currentLine = currentLine.Substring(index + 1);

                string[] categories = currentLine.Split("|");
                string name = categories[0];
                string description = categories[1];
                int target = Convert.ToInt32(categories[2]);
                int amountCompleted = Convert.ToInt32(categories[3]);

                if (goalType == "ExerciseGoal")
                {
                    ExerciseGoal exerciseGoal = new ExerciseGoal(target, description, name, amountCompleted);
                    _otherGoals.Add(exerciseGoal);
                }
                else 
                {
                    MiscellaneousGoal miscellaneousGoal = new MiscellaneousGoal(target, description, name, amountCompleted);
                    _otherGoals.Add(miscellaneousGoal);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Invalid File Name!");
            Console.WriteLine(ex);
        }    
    }

    public void DisplayGoals(string filename)
    {
        try 
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            for (int i = 1; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Invalid File Name!");
            Console.WriteLine(ex);
        }
    }

    public void DisplayOtherGoalsMenu()
    {
        Console.WriteLine("Would you like to add any of the following extra goals?");
        Console.WriteLine("\t1. Exercise Goal");
        Console.WriteLine("\t2. Miscellaneous Goal");
        Console.WriteLine("\t3. I do not want to add any other goals");
    }

    public void InitiateOtherGoalCreation()
    {
        bool otherGoalPortionComplete = false;
        Helper helper = new Helper();

        while (otherGoalPortionComplete == false)
        {
            DisplayOtherGoalsMenu();
            string response = Console.ReadLine();
            if (response == "1" || response == "2")
            {
                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                int target = helper.CheckAndReturnValidInt("How many times a week do you want to accomplish this exercise goal?");

                if (response == "1")
                {
                    ExerciseGoal exerciseGoal = new ExerciseGoal(target, description, name);
                    _otherGoals.Add(exerciseGoal);
                }
                else 
                {
                    MiscellaneousGoal miscellaneousGoal = new MiscellaneousGoal(target, description, name);
                    _otherGoals.Add(miscellaneousGoal);
                }     

                bool validResponse = false;
                while (validResponse == false)
                {
                    Console.WriteLine("Do you want to add another goal?");
                    string anotherGoalResponse = Console.ReadLine();
                    if (anotherGoalResponse.ToLower() == "yes")
                    {
                        validResponse = true;
                    }
                    else if (anotherGoalResponse.ToLower() == "no")
                    {
                        validResponse = true;
                        otherGoalPortionComplete = true;
                    }
                    else 
                    {
                        helper.DisplayErrorMessage();
                    }
                } 
            }
            else if (response == "3")
            {
                otherGoalPortionComplete = true;
            }
            else 
            {
                helper.DisplayErrorMessage();
                Console.WriteLine("Your goal was not saved.");
            }
        }
    }

    public void RunGoalCreation()
    {
        bool macroPortionComplete = false;
        Helper helper = new Helper();

        _macros.SetCalories(helper.CheckAndReturnValidInt("What is your daily calorie allowance?"));

        while (macroPortionComplete == false)
        {
            double fatPercent = helper.CheckAndReturnValidNumber("What percent of your daily intake do you want fat to take up?");
            double carbPercent = helper.CheckAndReturnValidInt("What percent of your daily intake do you want carbs to take up?");
            double proteinPercent = 0;
            double proteinPercentTemp = 100 - fatPercent - carbPercent;
            Console.WriteLine($"You want your daily protein intake to be {proteinPercentTemp}%?");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                proteinPercent = proteinPercentTemp;
                _macros.SetAllPercent(proteinPercent, fatPercent, carbPercent);
                macroPortionComplete = true;
            }
            else if (response.ToLower() == "no")
            {
                Console.WriteLine("Redoing macro portion!");
            }
            else
            {
                helper.DisplayErrorMessage();
                Console.WriteLine("Redoing macro portion!");
            }
        }

        _macros.SetAllGramsFromPercent();

        _waterIntake.SetOunces(helper.CheckAndReturnValidInt("How many ounces of water do you want to drink per day?"));
        _weight = helper.CheckAndReturnValidInt("What is your target weight (in pounds)?");
        InitiateOtherGoalCreation();

        Console.WriteLine("What filename do you want to store your goals under?");
        string filename = Console.ReadLine();
        SaveGoals(filename);
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter($"Goals/{filename}"))
        {
            outputFile.WriteLine(_date);
            outputFile.WriteLine($"GoalWeight:{_weight}");

            // Get calories as string
            outputFile.WriteLine(_macros.DisplayResultsAsString());

            outputFile.WriteLine(_waterIntake.DisplayResultsAsString());

            List<string> macroStrings = _macros.DisplayMacrosAsStrings();

            macroStrings.ForEach(macro => {
                outputFile.WriteLine(macro);
            });
            
            if (_otherGoals.Count > 0)
            {
                _otherGoals.ForEach(goal => {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                });
            }
        }
    }

}