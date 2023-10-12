public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract bool IsComplete();

    public abstract int RecordEvent();

    public virtual void ShowDetailsString(int index)
    {
        if(IsComplete())
            {
                Console.WriteLine($"{index + 1}. [X] {GetName()} ({GetDescription()}) ");
            }
            else 
            {
                Console.WriteLine($"{index + 1}. [ ] {GetName()} ({GetDescription()}) ");
            }
    }

    public virtual void showVariables()
    {
        Console.WriteLine($"ShortName = {_shortName}");
        Console.WriteLine($"Description = {_description}");
        Console.WriteLine($"Points = {_points}");
    }

    public string GetName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract string GetStringRepresentation();

    // public virtual void GetDetails()
    // {
    //     bool responsesComplete = false;

    //     Console.Write("What is the name of your goal? ");
    //     _shortName = Console.ReadLine();
    //     Console.Write("\nWhat is a short description of it? ");
    //     _description = Console.ReadLine();
        
    //     while(responsesComplete == false)
    //     {
    //         Console.Write("\nWhat is the amount of points associated with this goal? ");
    //         int points;
    //         string response = Console.ReadLine();
    //         bool res = int.TryParse(response, out points);
    //         if (res == false)
    //         {
    //             Console.WriteLine("Must input an integer.");
    //         }
    //         else
    //         {
    //             _points = points;
    //             responsesComplete = true;
    //         }    
    //     }
    // }
}