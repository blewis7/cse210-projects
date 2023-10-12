public class Helper
{
    public int CheckAndReturnValidInt(string question)
    {
        bool responsesComplete = false;
        int returnInteger = 0;
        while(responsesComplete == false)
        {
            Console.Write($"{question} ");
            string response = Console.ReadLine();
            bool res = int.TryParse(response, out returnInteger);
            if (res == false)
            {
                Console.WriteLine("Must input an integer.");
            }
            else
            {
                responsesComplete = true;
            }    
        }
        return returnInteger;
    }
}