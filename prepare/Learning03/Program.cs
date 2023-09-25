using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6, 7);
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction3.GetFractionString());

        fraction1.SetTop(4);
        fraction1.SetBottom(9);

        Console.WriteLine($"Top: {fraction1.GetTop()}");
        Console.WriteLine($"Bottom: {fraction1.GetBottom()}");

        Fraction fraction4 = new Fraction();
        Fraction fraction5 = new Fraction(5);
        Fraction fraction6 = new Fraction(3, 4);
        Fraction fraction7 = new Fraction(1, 3);

        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
        Console.WriteLine(fraction5.GetFractionString());
        Console.WriteLine(fraction5.GetDecimalValue());
        Console.WriteLine(fraction6.GetFractionString());
        Console.WriteLine(fraction6.GetDecimalValue());
        Console.WriteLine(fraction7.GetFractionString());
        Console.WriteLine(fraction7.GetDecimalValue());
    }
}