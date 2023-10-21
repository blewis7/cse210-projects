public class MiscellaneousGoal : Goal
{
    public MiscellaneousGoal(int target, string description, string name) : base(target, description, name){}
    public MiscellaneousGoal(int target, string description, string name, int amountCompleted) : base(target, description, name, amountCompleted){}

    public override string GetStringRepresentation()
    {
        return $"MiscellaneousGoal:{_name}|{_description}|{_target}|{_amountCompleted}";
    }


}