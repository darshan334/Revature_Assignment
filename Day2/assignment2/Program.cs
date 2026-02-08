using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello DotNet");

        // Calling other demo classes
        Condition.Ifelse();
        Dtype.Run();
        StringDemo.Run();
    }
}
