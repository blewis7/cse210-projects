using System;

class Program
{
    static void Main(string[] args)
    {
        bool isFinished = false;
        Helper helper = new Helper();

        helper.DisplayScriptureStart();
        string choice = Console.ReadLine();
        Scripture scripture = new Scripture();
        List<int> removedIndexes = new List<int>();

        while(choice != "1" && choice != "2")
        {
            Console.WriteLine("Invalid Response!");
            helper.DisplayScriptureStart();
            choice = Console.ReadLine();
        }

        if (choice == "1")
        {
            Console.WriteLine("Enter Book");
            string book = Console.ReadLine();

            Console.WriteLine("Enter Chapter");
            int chapter = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Starting Verse");
            int startVerse = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Ending Verse (if applicable). If no end verse, type 0");
            int endVerse = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Now, type out scripture you want to practice.");
            string scriptureQuote = Console.ReadLine();

            Reference reference = new Reference(book, chapter, startVerse, endVerse);
            scripture = new Scripture(reference, scriptureQuote);
        }
        
        while (!isFinished)
        {
            Console.Clear();
            scripture.DisplayScripture(); 
            Console.WriteLine("Press 1 to remove random words (if all words, program will terminate), 2 to show full scripture, 3 to get reference, or 4 to quit.");
            string response = Console.ReadLine();

            if (response == "1")
            {
                if (scripture.IsCompletelyHidden())
                {
                    isFinished = true;
                }
                else 
                {
                    Console.WriteLine("How many words do you want to remove?");
                    int wordsToRemove = Convert.ToInt32(Console.ReadLine());
                    if (wordsToRemove > 0 && wordsToRemove + removedIndexes.Count <= scripture.GetNumberOfWords())
                    {
                        List<int> indexes = helper.GetRandomIndexes(wordsToRemove, scripture.GetNumberOfWords(), removedIndexes);
                        indexes.ForEach(index => {
                            removedIndexes.Add(index);
                            scripture.RemoveWordByIndex(index);
                        });
                    }
                    else 
                    {
                        helper.DisplayInvalidResponseMessage();
                    }
                }
            }
            else if (response == "2")
            {
                scripture.DisplayUnalteredScripture();
                Console.WriteLine("Press Enter to Continue Exercise");
                Console.ReadLine();
            }
            else if (response == "3")
            {
                scripture.DisplayReference();
                Console.WriteLine("Press Enter to Continue Exercise");
                Console.ReadLine();
            }
            else if (response == "4")
            {
                isFinished = true;
            }
            else 
            {
                helper.DisplayInvalidResponseMessage();
            }
        }
    }
}