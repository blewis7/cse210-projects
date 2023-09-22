public class Entry 
{
    public string _prompt;
    public string _date;
    public string _answer;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}\n{_answer}");
    }

    public string GetEntry()
    {
        return $"Date: {_date} - Prompt: {_prompt}\n{_answer}";
    }
}