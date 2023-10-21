public class ExerciseGoal : Goal
{
    public ExerciseGoal(int target, string description, string name) : base(target, description, name){}
    public ExerciseGoal(int target, string description, string name, int amountCompleted) : base(target, description, name, amountCompleted){}

    public override string GetStringRepresentation()
    {
        return $"ExerciseGoal:{_name}|{_description}|{_target}|{_amountCompleted}";
    }
}