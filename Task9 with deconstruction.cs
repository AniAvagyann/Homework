using System;

public class Program
{
    public static void Main()
    {
        double a, b, c, d;

        do
        {
            Console.Write("Give a value to a: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Give a value to b: ");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Give a value to c: ");
            c = double.Parse(Console.ReadLine());
            d = Math.Pow(b, 2) - 4 * a * c;
            Console.WriteLine();

            if (d < 0)
            {
                Console.WriteLine("Discriminant (d) cannot be negative. Please enter valid coefficients.");
            }

        } while (d < 0);

        QuadraticEquation equation = new QuadraticEquation(a, b, d);

        if (!equation.IsValid)
        {
            Console.WriteLine("Coefficient 'a' cannot be zero.");
        }
        else
        {
            Console.WriteLine("The first root of the quadratic equation is: " + equation.x1);
            Console.WriteLine("The second root of the quadratic equation is: " + equation.x2);
        }
    }
}

public class QuadraticEquation
{
    public double x1 { get; private set; }
    public double x2 { get; private set; }
    public bool IsValid { get; private set; }

    public QuadraticEquation(double a, double b, double d)
    {
        if (a == 0)
        {
            IsValid = false;
            return;
        }

        IsValid = true;
        x1 = (-b - Math.Sqrt(d)) / (2 * a);
        x2 = (-b + Math.Sqrt(d)) / (2 * a);
    }
}
