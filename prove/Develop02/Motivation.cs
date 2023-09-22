public class Motivation 
{
    // List of quotes supplied by https://dayoneapp.com/blog/quotes-about-journaling/
    public List<string> _quotes = new List<string>{"In the journal, I am at ease. — Anaïs Nin",
        "When my journal appears, many statues must come down. — Arthur Wellesley",
        "All the noise in my brain. I clamp it to the page so it will be still. — Barbara Kingsolver",
        "A journal can offer you a place to be someone, anyone, who you want to be. — Brian Ledger",
        "Writing in your journal gives you a chance to go back over your day and extract meaning from a hurried meeting with a friend or retrieve the significance of some fleeting event. — Janette Rainwater",
        "Journal writing is a voyage to the interior. — Christina Baldwin",
        "We're drawn to making our mark, leaving a record to show we were here, and a journal is a great place to do it. — Keri Smith"
    };

    public void GetRandomQuote()
    {
        Random rnd = new Random();
        int num = rnd.Next(7);

        Console.WriteLine(_quotes[num] + "\n");
    }

    public void ShowMotivationOptions()
    {
        Console.WriteLine("What do you need?");
        Console.WriteLine("1. Get me a quote about journaling");
        Console.WriteLine("2. Don't choose this option");
        Console.WriteLine("What would you like to do?");
    }
}