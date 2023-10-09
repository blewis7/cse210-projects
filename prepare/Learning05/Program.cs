using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("green", 5);
        // Console.WriteLine($"Square: Color is {square.GetColor()}, and area is {square.GetArea()}");

        Rectangle rectangle = new Rectangle("purple", 5, 4);
        // Console.WriteLine($"Rectangle: Color is {rectangle.GetColor()}, and area is {rectangle.GetArea()}");

        Circle circle = new Circle("red", 2);
        // Console.WriteLine($"Circle: Color is {circle.GetColor()}, and area is {circle.GetArea()}");

        List<Shape> shapes = new List<Shape>{ square, rectangle, circle };

        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"Color is {shape.GetColor()}, and area is {shape.GetArea()}");
        }
    }
}