using System;

class Method
{
    public static void Main()
    {
        Console.WriteLine("This is Methods Programs");

        int result = Method_Declar.Add(5, 3);        //Static Method Invocation (with return value)

        Console.WriteLine("Result: " + result);


//Parameters and return type demo
        int sum =ParameterReturnDemo.Add(10,20);        //Static Method Invocation (Overloaded + Return)     
        Console.WriteLine("sum:" +sum);

        ParameterReturnDemo.PrintMessage("hello this is message from ParameterReturnDemo");     //Static Void Method Invocation

        double product = ParameterReturnDemo.Multiply(3.5,5.3);       //Static Method Invocation (Return double)
        Console.WriteLine("product:" +product);

        ParameterReturnDemo.Greet("Darshan");    //Hello, Darshan!        //Static Method Invocation (Default Parameter)
        ParameterReturnDemo.Greet();             //Hello, Guest!

//Method overloading demo
        int sum1=Overloading.Add(2,3);
        Console.WriteLine("sum1:" +sum1);

        int sum2=Overloading.Add(1,2,3);
        Console.WriteLine("sum2:" +sum2);

        double sum3=Overloading.Add(2.5,3.7);
        Console.WriteLine("sum3:" +sum3);

        string sum4=Overloading.Add("Hello","World");
        Console.WriteLine("sum4:" +sum4);

    }
    
}
