using System.Runtime.InteropServices;

public class WaterIntake : IDailyIntake
{
    private int _ounces;


    public WaterIntake()
    {
        _ounces = 0;
    }

    public string DisplayResultsAsString()
    {
        return $"WaterIntake:{_ounces}";
    }

    public int GetOunces()
    {
        return _ounces;
    }
    public void SetOunces(int ounces)
    {
        _ounces = ounces;
    }

    public void AddOunces(int ounces)
    {
        _ounces += ounces;
    }

    public void GetValuesFromString(string str)
    {
        int ounces = Convert.ToInt32(str.Substring(12));
        _ounces = ounces;
    }
}