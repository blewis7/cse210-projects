using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What grade (in percentage) did you receive?");
        string input = Console.ReadLine();
        int grade = Convert.ToInt32(input);

        bool passed = false;
        string plusOrMinus = "";
        string letterGrade = "";

        if ((grade % 10) >= 7)
        {
            plusOrMinus = "+";
        }
        else if ((grade % 10) < 3)
        {
            plusOrMinus = "-";
        }

        if (grade >= 100) 
        {
            letterGrade = "A";
            plusOrMinus = "";
            passed = true;
        }
        else if (grade >= 90)
        {
            if (plusOrMinus == "+")
            {
                plusOrMinus = "";
            }
            letterGrade = "A";
            passed = true;
        }
        else if (grade >= 80) 
        {
            letterGrade = "B";
            passed = true;
        }
        else if (grade >= 70) 
        {
            letterGrade = "C";
            passed = true;
        }
        else if (grade >= 60) 
        {
            letterGrade = "D";
        }
        else 
        {
            letterGrade = "F";
            plusOrMinus = "";
        }

        Console.WriteLine($"You got a grade of {letterGrade}{plusOrMinus} in the course");

        if (passed)
        {
            Console.WriteLine("Congradulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("You did not pass, but work hard, and you'll get it the next time!");
        }
    }
}