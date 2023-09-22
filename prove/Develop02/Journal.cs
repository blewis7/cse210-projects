using System.IO;

public class Journal 
{
    public List<Entry> _entries;

    public void Display()
    {
        foreach(Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine("");
        }
    }

    public void Add(Entry entry)
    {
        _entries.Add(entry);
    }

    public string GetJournalEntries()
    {
        string entriesAsString = "";
        foreach(Entry entry in _entries)
        {
            entriesAsString += entry.GetEntry();
            entriesAsString += "\n\n";
        }
        return entriesAsString;
    }

    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(GetJournalEntries());
        }
    }

    public void Load(string filename)
    {
        Entry entry = new Entry();
        try 
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {

                if (line != "")
                {
                    if (line.Contains("Date:"))
                    {
                        string splitWord = "Prompt: ";
                        string prompt = line.Substring(line.IndexOf(splitWord) + splitWord.Length);
                        string date = line.Substring(6, 10);

                        entry._prompt = prompt;
                        entry._date = date;
                    }
                    else 
                    {
                        entry._answer = line;
                        _entries.Add(entry);
                        entry = new Entry();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: Invalid File Name!");
            Console.WriteLine(ex);
        }
    }

    public void ShowJournalOptions()
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Need Motivation?");
        Console.WriteLine("2. Write");
        Console.WriteLine("3. Display");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Save");
        Console.WriteLine("6. Quit");
        Console.WriteLine("What would you like to do?");
    }
}