public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>{ "Think of a time when you did charity for someone else.", 
        "Think of a time when you prioritized someone else's feelings before your own.",
        "Think about a time you had to overcome something challenging.",
        "Think of a time when you stood up for someone else."
    };
    private List<string> _questions = new List<string>{ "How did you feel afterwards?",
        "What is your favorite thing about this experience?",
        "What can you learn from this experience that can be applied to your life today?",
        "Have you ever done anything like this before?",
        "How did you get started?"
    };

    private List<int> _promptIndexesUsed = new List<int>();
    private List<int> _questionIndexesUsed = new List<int>();

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 30;
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        while (DateTime.Now < endTime)
        {
            DisplayQuestions();
        }

        Console.WriteLine("\n");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        if (_promptIndexesUsed.Count == 4)
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

    public string GetRandomQuestion()
    {
        if (_questionIndexesUsed.Count == 5)
        {
            _questionIndexesUsed.Clear();
        }

        Random rnd = new Random();
        int i = rnd.Next(_questions.Count);

        while (_questionIndexesUsed.Contains(i))
        {
            i = rnd.Next(_questions.Count);
        }
        
        _questionIndexesUsed.Add(i);
        
        return _questions[i];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        Console.WriteLine();
        Console.Write($"{GetRandomQuestion()} ");
        ShowSpinner(10);
    }
}