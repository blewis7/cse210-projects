using System;

class Program
{
    static void Main(string[] args)
    {
        bool finished = false;
        Helper helper = new Helper();

        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        while (finished == false)
        {
            Console.Clear();
            helper.ShowMenu();
            string response = Console.ReadLine();

            if (response == "1")
            {
                breathingActivity.Run();
            }
            else if (response == "2")
            {
                reflectingActivity.Run();
            }
            else if (response == "3")
            {
                listingActivity.Run();
            }
            else if (response == "4")
            {
                Console.Clear();
                finished = true;
            }
            else 
            {
                Activity activity = new Activity();
                helper.ShowErrorMessage();
                Console.Write("Return to menu in: ");
                activity.ShowCountDown(3);
            }
        }
    }
}