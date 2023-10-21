public abstract class Goal
{
    protected int _target;
    protected int _amountCompleted;
    protected string _description;
    protected string _name;

    public Goal(int target, string description, string name)
    {
        _target = target;
        _amountCompleted = 0;
        _description = description;
        _name = name;
    }

    public Goal(int target, string description, string name, int amountCompleted)
    {
        _target = target;
        _amountCompleted = amountCompleted;
        _description = description;
        _name = name;
    }

    public abstract string GetStringRepresentation();

    public virtual string GetGoalDetails()
    {
        return $"{_name} - {_description} - Goal of {_target} per week";
    }

    public virtual string ShowGoalVariables()
    {
        return $"{_name} - {_description} - {_amountCompleted}/{_target}";
    }

    public virtual void RecordEvent()
    {
        _amountCompleted++;
    }
}
