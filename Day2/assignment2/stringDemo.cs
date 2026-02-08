using System;
using System.Text;

class StringDemo
{
    public static void Run()
    {
        string greeting = "Good " + "Morning";

        var sb = new StringBuilder();
        sb.Append("Hello").Append(" ");
        sb.Append("world");

        Console.WriteLine(greeting);
        Console.WriteLine(sb.ToString());
    }
}
