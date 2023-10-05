public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through a breathing exercise. Clear your mind and focus on your breathing.";
        _duration = 30;
    }
    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowCountDown(6);
            Console.WriteLine("\n");
        }

        DisplayEndingMessage();
    }
}