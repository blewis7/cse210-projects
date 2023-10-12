public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base (name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base (name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target ? true : false;
    }

    public override void showVariables()
    {
        Console.WriteLine($"ShortName = {_shortName}");
        Console.WriteLine($"Description = {_description}");
        Console.WriteLine($"Points = {_points}");
        Console.WriteLine($"AmountCompleted = {_amountCompleted}");
        Console.WriteLine($"Target = {_target}");
        Console.WriteLine($"Bonus = {_bonus}");

    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted >= _target)
        {
            Console.WriteLine("********************************************\n");
            Console.WriteLine("Congratulations! You have finished your goal!");
            Console.WriteLine("\n********************************************");
            return _points + _bonus;
        }
        else 
        {
            return _points;
        }
    }

    public override void ShowDetailsString(int index)
    {
        if(IsComplete())
            {
                Console.WriteLine($"{index + 1}. [X] {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}");
            }
            else 
            {
                Console.WriteLine($"{index + 1}. [ ] {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}");
            }
    }
}