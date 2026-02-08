using System;

class Dtype
{
    public static void Run()
    {
        int a = 42;
        long big = 22525253L;
        float f = 2.3f;
        double d = 2.33434;
        decimal money = 23.34m;
        bool isActive = true;
        char letter = 'a';

        Console.WriteLine("this is int: " + a);
        Console.WriteLine("this is long: " + big);
        Console.WriteLine("this is float: " + f);
        Console.WriteLine("this is double: " + d);
        Console.WriteLine("this is decimal: " + money);
        Console.WriteLine("this is bool: " + isActive);
        Console.WriteLine("this is char: " + letter);
    }
}
