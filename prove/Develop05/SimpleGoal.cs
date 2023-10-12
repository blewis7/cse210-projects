public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base (name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete) : base (name, description, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override void showVariables()
    {
        Console.WriteLine($"ShortName = {_shortName}");
        Console.WriteLine($"Description = {_description}");
        Console.WriteLine($"Points = {_points}");
        Console.WriteLine($"IsComplete = {_isComplete}");
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}|{_description}|{_points}|{_isComplete}";
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    
}