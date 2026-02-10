namespace DelegatesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegatesDemo app = new DelegatesDemo();
            app.Run();
        }
    }

    delegate int MathOperation(int a, int b);
    delegate void GenericTwoParameterFunction<TFirst, TSecond, TResult>(TFirst a, TSecond b);
    class DelegatesDemo
    {
        void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        bool IsEven(int number)
        {
            return number % 2 == 0;
        }



        public void Run()
        {
            // MathOperation operation = Add;


            Func<int, int, int> genericOperation = Add;

            Action<string> action = PrintMessage;
            action("Hello from action delegate!");

            Predicate<int> predicate = IsEven;
            int testNumber = 4;
            Console.WriteLine($"{testNumber} is even: {predicate(testNumber)}");

            return;

            Func<string, string, string> stringOperation = Concatenate;

            var x = stringOperation("Hello, ", "World!");
            Console.WriteLine($"Concatenation result: {x}");

            operation += Subtract;
            operation += Multiply;
            operation += Divide;

            // operation(5,3);

            var result = operation(5, 3);
            Console.WriteLine($"Result: {result}");

        }

        public string Concatenate(string a, string b)
        {
            string result = a + b;
            Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
            return result;
        }




        public int Add(int a, int b)
        {
            Console.WriteLine($"Addition of {a} and {b} is: {a + b} ");
            return a = +b;
        }

        public int Subtract(int a, int b)
        {
            Console.WriteLine($"Subtraction of {a} and {b} is: {a - b} ");
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            Console.WriteLine($"Multiplication of {a} and {b} is : {a * b}");
            return a * b;

        }

        public int Divide(int a, int b)
        {
            Console.WriteLine($"Division of {a} and {b} is : {a / b}");
            return a / b;
        }
    }
}