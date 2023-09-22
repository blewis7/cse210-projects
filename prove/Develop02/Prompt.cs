public class Prompt 
{
    public List<string> _questions = new List<string>{"Did you have any interesting conversations today?",
        "Did you meet anyone new today?",
        "Did you have any memorable food today?",
        "Did you do any work today?",
        "Did you learn anything new today?"
    };

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        int num = rnd.Next(5);

        return _questions[num];
    }
}