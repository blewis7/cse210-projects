public class Food : IDailyIntake
{
    protected int _calories;

    public void SetCalories(int calories)
    {
        _calories = calories;
    }
    public int GetCalories()
    {
        return _calories;
    }

    public void AddCalories(int calories)
    {
        _calories += calories; 
    }

    public string DisplayResultsAsString()
    {
        return $"Calories:{_calories}";
    }

    public void GetValuesFromString(string str)
    {
        int calories = Convert.ToInt32(str.Substring(9));
        _calories = calories;
    }
}