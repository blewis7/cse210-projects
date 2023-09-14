using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int input = -1;

        while (input != 0)
        {
            input = Convert.ToInt32(Console.ReadLine());
            if (input != 0)
            {
                numbers.Add(input);  
            } 
        }

        int sum = 0;
        int largestNumber = 0;
        foreach(var number in numbers)
        {
            if (number > largestNumber)
            {
                largestNumber = number;
            }
            sum += number;
        }
        double average = numbers.Average();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}