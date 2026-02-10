using System;

class Overloading
{
    public static int Add(int a, int b)
    {
        return a+b;
    }
    public static int Add(int a, int b, int c)
    {
        return a+b+c;
    }
    public static double Add(double a, double b)
    {
        return a+b;
    }
    public static string Add(string a, string b)
    {
        return a+" " +b;
    }

}