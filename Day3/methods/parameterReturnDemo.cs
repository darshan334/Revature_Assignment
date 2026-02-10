using System;

class ParameterReturnDemo
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static double Multiply (double x, double y)
    {
        return x * y;
    }

    public static void Greet(string name = "Guest")
    {
        Console.WriteLine("Hello, " + name + "!");
    }
}