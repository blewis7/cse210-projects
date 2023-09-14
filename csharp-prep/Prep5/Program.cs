using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        DisplayResult(name, SquareNumber(favoriteNumber));
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
            Console.WriteLine("Please enter your name:");
            return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:");
            return Convert.ToInt32(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number*number;
    }

    static void DisplayResult(string name, int numberSquared)
    {
        Console.WriteLine($"{name}, the square of your number is {numberSquared}");
    }
}