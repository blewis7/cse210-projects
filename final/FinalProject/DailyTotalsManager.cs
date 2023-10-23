using System.Data.Common;
using System.Net;

public class DailyTotalsManager
{
    private Macros _macros;
    private WaterIntake _waterIntake;
    private string _date;
    private double _weight;
    private List<Goal> _otherGoals;

    public DailyTotalsManager()
    {
        _macros = new Macros();
        _waterIntake = new WaterIntake();
        _waterIntake.SetOunces(0);
        _date = DateTime.Now.ToString("MM/dd/yyyy");
        _weight = 0;
        _otherGoals = new List<Goal>();
    }

    public DailyTotalsManager(Macros macros, int ounces, double weight, List<Goal> goals, string date)
    {
        _macros = macros;
        _waterIntake = new WaterIntake();
        _waterIntake.SetOunces(ounces);
        _date = date;
        _weight = weight;
        _otherGoals = goals;
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

    public void RecordMenu()
    {
        Console.WriteLine("What would you like to record?");
        Console.WriteLine("\t1. Food");
        Console.WriteLine("\t2. Water");
        Console.WriteLine("\t3. Weight");
        Console.WriteLine("\t4. Other Goals (Exercise or Miscellaneous)");
        Console.WriteLine("\t5. Finished Recording");
    }

    public Macros GetMacros()
    {
        return _macros;
    }

    public WaterIntake GetWaterIntake()
    {
        return _waterIntake;
    }

    public List<Goal> GetGoals()
    {
        return _otherGoals;
    }

    public void RunRecord(GoalManager goalManager, bool compare)
    {
        Helper helper = new Helper();
        bool finished = false;
        while (finished == false)
        {
            RecordMenu();
            string response = Console.ReadLine();
            if (response == "1")
            {
                int calories = helper.CheckAndReturnValidInt("How many calories do you want to record?");
                RecordFoodIntake(calories, goalManager, compare);
            }
            else if (response == "2")
            {
                int water = helper.CheckAndReturnValidInt("How many oz of water do you want to record?");
                RecordWaterIntake(water, goalManager, compare);
            }
            else if (response == "3")
            {
                RecordWeight();
            }
            else if (response == "4")
            {
                recordOtherGoals(goalManager);
            }
            else if (response == "5")
            {
                finished = true;
            }
            else 
            {
                helper.DisplayErrorMessage();
            }
        }
        
    }

    public void GetGoalTotalsFromWeek(GoalManager goalManager)
    {
         var firstDayOfWeek = DateTime.Now.FirstDayOfWeek();

        var previousDay = DateTime.Today.AddDays(-1);

         if (firstDayOfWeek.DayOfWeek == DayOfWeek.Sunday)
         {
            previousDay = firstDayOfWeek;
         }

        for (DateTime dt = previousDay; dt > firstDayOfWeek; dt = dt.AddDays(-1))
        {
            string date = dt.ToString("MM/dd/yyyy").Replace("/", "_") + ".txt";
            bool exists = System.IO.File.Exists($"Dailys/{date}");
            if (exists)
            {
                LoadGoals(date);
                break;
            }
        }

        if (_otherGoals.Count == 0)
        {
            if (goalManager.GetOtherGoals().Count != 0)
            {
                LoadGoalsFromGoalManager(goalManager);
            }
        }
    }

    public void SaveWeekGoals()
    {
        Helper helper = new Helper();
        double weight = helper.CheckAndReturnValidNumber("What is your current weight?");
        int calories = 0;
        double fatGrams = 0;
        double proteinGrams = 0;
        double carbGrams = 0;
        int ouncesOfWater = 0;
        List<Goal> goals = new List<Goal>();

        var firstDayOfWeek = DateTime.Now.FirstDayOfWeek();
        var lastDayOfWeek = DateTime.Now.LastDayOfWeek();
        int numberOfDays = 0;

        string firstDayString = firstDayOfWeek.ToString("MM/dd/yyyy");
        string lastDayString = lastDayOfWeek.ToString("MM/dd/yyy");

        string filename = $"{firstDayString.Replace("/", "_")}-{lastDayString.Replace("/", "_")}.txt";

        var files = new List<string>();

        for (var dt = firstDayOfWeek; dt <= lastDayOfWeek; dt = dt.AddDays(1))
        {
            string file = $"{dt.ToString("MM/dd/yyyy").Replace("/", "_")}.txt";
            if (System.IO.File.Exists($"Dailys/{file}"))
            {
                numberOfDays++;
                files.Add(file);
            }        
        }

        for (int i = 0; i < files.Count; i++)
        {
            DailyTotalsManager dailyTotalsManager = new DailyTotalsManager();
            dailyTotalsManager.Load(files[i]);
            Macros tempMacros = dailyTotalsManager.GetMacros();
            calories += tempMacros.GetCalories();
            fatGrams += tempMacros.GetFatGrams();
            proteinGrams += tempMacros.GetProteinGrams();
            carbGrams += tempMacros.GetCarbGrams();
            ouncesOfWater += dailyTotalsManager.GetWaterIntake().GetOunces();

            if (i == files.Count - 1)
            {
                goals = dailyTotalsManager.GetGoals();
            }
        }
        try 
        {
            if (numberOfDays > 0)
            {
                calories = calories / numberOfDays;
                fatGrams = fatGrams / numberOfDays;
                proteinGrams = proteinGrams / numberOfDays;
                carbGrams = carbGrams / numberOfDays;
                ouncesOfWater = ouncesOfWater / numberOfDays;

                Macros macros = new Macros();
                macros.SetCalories(calories);
                macros.SetFatGrams(fatGrams);
                macros.SetCarbGrams(carbGrams);
                macros.SetProteinGrams(proteinGrams);
                macros.SetAllPercentFromGrams();

                DailyTotalsManager weeklyTotals = new DailyTotalsManager(macros, ouncesOfWater, weight, goals, $"{firstDayString}-{lastDayString}.txt");

                weeklyTotals.SaveWeeklys(filename);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    public void LoadGoalsFromGoalManager(GoalManager goalManager)
    {
        _otherGoals = goalManager.GetOtherGoals();
    }

    public void RecordFoodIntake(int calories, GoalManager goalManager, bool compareManagers)
    {
        _macros.AddCalories(calories);
        Console.WriteLine($"You added {calories} calories to your daily total.");

        RecordMacros();

        Console.WriteLine();

        if (compareManagers)
        {
            int currentCalories = _macros.GetCalories();
            int goalCalories = goalManager.GetMacros().GetCalories();

            if (currentCalories <= goalCalories)
            {
                Console.WriteLine($"You have {goalCalories - currentCalories} calories left for the day.");
            }
            else 
            {
                Console.WriteLine($"You are over by {currentCalories - goalCalories} calories for the day.");
            }

            CompareMacros(goalManager);
        }
    }

    public void RecordMacros()
    {
        Helper helper = new Helper();
        double proteinGrams = helper.CheckAndReturnValidNumber("How many grams of protein were in your meal?");
        double fatGrams = helper.CheckAndReturnValidNumber("How many grams of fat were in your meal?");
        double carbGrams = helper.CheckAndReturnValidNumber("How many grams of carbs were in your meal?");
        _macros.AddAllGrams(proteinGrams, fatGrams, carbGrams);
        _macros.SetAllPercentFromGrams();
    }

    public void CompareMacros(GoalManager goalManager)
    {
        double currentProteinGrams = _macros.GetProteinGrams();
        double currentFatGrams = _macros.GetFatGrams();
        double currentCarbGrams = _macros.GetCarbGrams();
        List<double> currentGrams = new List<double>{ currentProteinGrams, currentFatGrams, currentCarbGrams };

        double goalProteinGrams = goalManager.GetMacros().GetProteinGrams();
        double goalFatGrams = goalManager.GetMacros().GetFatGrams();
        double goalCarbGrams = goalManager.GetMacros().GetCarbGrams();
        List<double> goalGrams = new List<double>{ goalProteinGrams, goalFatGrams, goalCarbGrams };

        for (int i = 0; i < currentGrams.Count; i++)
        {
            if (currentGrams[i] <= goalGrams[i])
            {
                if (i == 0)
                {
                    Console.WriteLine($"You have {goalGrams[i] - currentGrams[i]} grams of protein left for the day.");
                }
                else if (i == 1)
                {
                    Console.WriteLine($"You have {goalGrams[i] - currentGrams[i]} grams of fat left for the day.");
                }
                else 
                {
                    Console.WriteLine($"You have {goalGrams[i] - currentGrams[i]} grams of carbs left for the day.");
                }
            }
            else 
            {
                if (i == 0)
                {
                    Console.WriteLine($"You are over by {currentGrams[i] - goalGrams[i]} grams of protein for the day.");
                }
                else if (i == 1)
                {
                    Console.WriteLine($"You are over by {currentGrams[i] - goalGrams[i]} grams of fat for the day.");
                }
                else 
                {
                    Console.WriteLine($"You are over by {currentGrams[i] - goalGrams[i]} grams of carbs for the day.");
                }
            }
        }
    }

    public void RecordWaterIntake(int waterIntake, GoalManager goalManager, bool compareManagers)
    {
        _waterIntake.AddOunces(waterIntake);
        Console.WriteLine($"You added {waterIntake} oz to your daily total.");

        if (compareManagers)
        {  
            int currentWaterIntake = _waterIntake.GetOunces();
            int goalWaterIntake = goalManager.GetWaterIntake().GetOunces();

            if (currentWaterIntake < goalWaterIntake)
            {
                Console.WriteLine($"You have {goalWaterIntake - currentWaterIntake} oz of water left for the day.");
            }
            else 
            {
                Console.WriteLine($"Congratulations! You have reached your goal for daily water intake!");
            }
        }
    }

    public void RecordWeight()
    {
        Helper helper = new Helper();
        _weight = helper.CheckAndReturnValidNumber("What is your current weight?");
        Console.WriteLine("Your current weight has been recorded.");
    }

    public void recordOtherGoals(GoalManager goalManager)
    {
        Helper helper = new Helper();

        if (_otherGoals.Count == 0)
        {
            GetGoalTotalsFromWeek(goalManager);
        }
        
        if (_otherGoals.Count == 0 && goalManager.GetOtherGoals().Count == 0)
        {
            Console.WriteLine("Must load goals before recording goals");
            return;
        }
        else if (_otherGoals.Count == 0 && goalManager.GetOtherGoals().Count != 0)
        {
            LoadGoalsFromGoalManager(goalManager);
        }

        bool validResponse = false;
        while (validResponse == false)
        {
            Console.WriteLine("Which goal did you perform?");
            for (int i = 0; i < _otherGoals.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {_otherGoals[i].GetGoalDetails()}");
            }
            string response = Console.ReadLine();
            if (Int32.TryParse(response, out int j))
            {
                if (j - 1 < _otherGoals.Count)
                {
                    _otherGoals[j - 1].RecordEvent();
                    validResponse = true;
                }
                else 
                {
                    helper.DisplayErrorMessage();
                }
            }
            else 
            {
                helper.DisplayErrorMessage();
            }
        }
        
    }

    public void LoadGoals(string date)
    {
        string[] lines = System.IO.File.ReadAllLines($"Dailys/{date}");

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

    public void Load(string date)
    {
        try 
        {        
            string[] lines = System.IO.File.ReadAllLines($"Dailys/{date}");

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

            LoadGoals(date);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Invalid File Name!");
            Console.WriteLine(ex);
        }    
    }

    public void LoadWeeklyFile(string filename)
    {
        if (!System.IO.File.Exists($"Weeklys/{filename}"))
        {
            Console.WriteLine("There are no weekly totals from that week or input was not in correct format!");
            return;
        }
        try 
        {
            string[] lines = System.IO.File.ReadAllLines($"Weeklys/{filename}");

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

    public void Save()
    {
        string date = _date.Replace("/", "_"); 
        using (StreamWriter outputFile = new StreamWriter($"Dailys/{date}.txt"))
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
        Console.WriteLine("Values saved successfully!");
    }

    public void SaveWeeklys(string filename)
    { 
        using (StreamWriter outputFile = new StreamWriter($"Weeklys/{filename}"))
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
        Console.WriteLine("Values saved successfully!");
    }
}