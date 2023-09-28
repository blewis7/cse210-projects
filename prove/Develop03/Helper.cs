public class Helper
{
    public List<int> GetRandomIndexes(int numberOfIndexes, int numberOfWords, List<int> removedIndexes)
    {
        List<int> indexes = new List<int>();

        for (int i = 0; i < numberOfIndexes; i++)
        {
            var random = new Random();
            var index = random.Next(0, numberOfWords);
            while (indexes.Contains(index) || removedIndexes.Contains(index))
            {
                index = random.Next(0, numberOfWords);
            }
            indexes.Add(index);
        }
        return indexes;
    }

    public void DisplayScriptureStart()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("Type 1 to add a scripture to practice or 2 to practice a default scripture.");
    }

    public void DisplayInvalidResponseMessage()
    {
        Console.WriteLine("Invalid Response");
        Console.WriteLine("Press Enter to Continue Exercise");
        Console.ReadLine();
    }
}