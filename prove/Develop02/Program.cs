using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        bool displayOptions = true;
        Journal journal = new Journal();
        journal._entries = new List<Entry>();

        while (displayOptions)
        {
            journal.ShowJournalOptions();
            var response = Console.ReadLine();
            var option = Convert.ToInt32(response);
            if (!(option < 7) && !(option > 0))
            {
                Console.WriteLine("Invalid input. Input must be a number between 1 and 6.");
            }
            else 
            {
                if (option == 1)
                {
                    Motivation motivation = new Motivation();
                    motivation.ShowMotivationOptions();
                    int motivationOption = Convert.ToInt32(Console.ReadLine());

                    if (motivationOption != 1 && motivationOption != 2)
                    {
                        Console.WriteLine("Invalid input. Input must be a number between 1 and 2.");
                    }
                    else 
                    {
                        if (motivationOption == 1)
                        {
                            motivation.GetRandomQuote();
                        }
                        if (motivationOption == 2)
                        {
                            Console.WriteLine("Do not go to this link.");
                            Console.WriteLine("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                            Console.WriteLine("Did you go to the link? (Yes/No)");
                            string yesOrNo = Console.ReadLine();
                            if (yesOrNo.ToLower() == "yes")
                            {
                                Console.WriteLine("GOT 'EM!\n");
                            }
                            else if (yesOrNo.ToLower() == "no")
                            {
                                Console.WriteLine("Smart...very smart!\n");
                            }
                            else 
                            {
                                Console.WriteLine("Invalid Input.\n");
                            }
                        }
                    }
                }
                else if (option == 2)
                {
                    string question = new Prompt().GetRandomPrompt();
                    string date = DateTime.Now.ToString("MM/dd/yyyy");

                    Console.WriteLine(question);
                    string answer = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = date;
                    newEntry._answer = answer;
                    newEntry._prompt = question;

                    journal.Add(newEntry);
                }
                else if (option == 3)
                {
                    journal.Display();
                }
                else if (option == 4)
                {
                    Console.WriteLine("What is the filename?");
                    string filename = Console.ReadLine();

                    journal.Load(filename); 
                }
                else if (option == 5)
                {
                    Console.WriteLine("What is the filename?");
                    string filename = Console.ReadLine();

                    journal.Save(filename);
                }
                else if (option == 6)
                {
                    displayOptions = false;
                }
            }


        }

    }
}