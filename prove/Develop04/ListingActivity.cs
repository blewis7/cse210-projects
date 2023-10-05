public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>{ "Who are the most important people in your life?",
        "What are your greatest strengths?",
        "What are your greatest weaknesses?",
        "Who have you helped this week?",
        "How have you come closer to Christ this month?"
    };
    private List<int> _promptIndexesUsed = new List<int>();
    private List<string> _listResponses = new List<string>();

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _duration = 30;
        _count = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine(GetRandomPrompt());
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string response = Console.ReadLine();
            _count++;
            _listResponses.Add(response);
        }

        Console.WriteLine($"You listed {_count} items!");

        Console.WriteLine();

        _count = 0;
        _listResponses.Clear();

        DisplayEndingMessage();

    }

    public string GetRandomPrompt()
    {
        if (_promptIndexesUsed.Count == 5)
        {
            _promptIndexesUsed.Clear();
        }

        Random rnd = new Random();
        int i = rnd.Next(_prompts.Count);

        while (_promptIndexesUsed.Contains(i))
        {
            i = rnd.Next(_prompts.Count);
        }

        _promptIndexesUsed.Add(i);
        
        return _prompts[i];
    }
}