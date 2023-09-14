using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("What is the magic number?");
        // int number = Convert.ToInt32(Console.ReadLine());

        Random rand = new Random();
        int number = rand.Next(1, 101);
        Console.WriteLine($"{number}");

        Console.WriteLine("What is your guess?");
        int guess = Convert.ToInt32(Console.ReadLine());

        while (number != guess)
        {
            if (number > guess)
            {
                Console.WriteLine("Higher");
                guess = Convert.ToInt32(Console.ReadLine());
            }
            else if (number < guess)
            {
                Console.WriteLine("Lower");
                guess = Convert.ToInt32(Console.ReadLine());
            }
        }
        Console.WriteLine("You guessed it!");
    }
}