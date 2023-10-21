public class Helper
{
    public double CheckAndReturnValidNumber(string question)
    {
        bool responsesComplete = false;
        double returnNumber = 0;
        while(responsesComplete == false)
        {
            Console.Write($"{question} ");
            string response = Console.ReadLine();
            bool res = double.TryParse(response, out returnNumber);
            if (res == false)
            {
                Console.WriteLine("Must input an integer.");
            }
            else
            {
                responsesComplete = true;
            }    
        }
        return returnNumber;
    }

    public int CheckAndReturnValidInt(string question)
    {
        bool responsesComplete = false;
        int returnInteger = 0;
        while(responsesComplete == false)
        {
            Console.Write($"{question} ");
            string response = Console.ReadLine();
            bool res = int.TryParse(response, out returnInteger);
            if (res == false)
            {
                Console.WriteLine("Must input an integer.");
            }
            else
            {
                responsesComplete = true;
            }    
        }
        return returnInteger;
    }

    public void DisplayErrorMessage()
    {
        Console.WriteLine("Invalid Response!");
    }

    public string GetWeeklyFilename(string date)
    {
        var firstDayOfWeek = DateTime.Parse(date).FirstDayOfWeek();
        var lastDayOfWeek = DateTime.Parse(date).LastDayOfWeek();

        string firstDayString = firstDayOfWeek.ToString("MM/dd/yyyy");
        string lastDayString = lastDayOfWeek.ToString("MM/dd/yyy");

        return $"{firstDayString.Replace("/", "_")}-{lastDayString.Replace("/", "_")}.txt";
    }
}

public static class DateTimeExtensions
{
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }

    public static DateTime FirstDayOfWeek(this DateTime dt)
    {
        var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

        if (diff < 0)
        {
            diff += 7;
        }

        return dt.AddDays(-diff).Date;
    }

    public static DateTime LastDayOfWeek(this DateTime dt) =>
        dt.FirstDayOfWeek().AddDays(6);
}