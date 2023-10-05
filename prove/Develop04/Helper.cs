public class Helper 
{
    public void ShowErrorMessage()
    {
        Console.WriteLine("Invalid Response!");
    }

    public void ShowMenu()
    {
        Console.WriteLine("Menu Options:\n" +
            "\t 1. Start breathing activity \n" +
            "\t 2. Start reflecting activity \n" +
            "\t 3. Start listing activity \n" +
            "\t 4. Quit \n" +
            "Select a choice from the menu:"
        );
    }
}