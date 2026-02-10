using System.Dynamic;

namespace DelegatesDemo
{
    public class OnClickEvents : EventArgs
    {
        public string ButtonName{get; set; }   
    }
    //Publisher
    public class Button
    {
        public delegate void OnClickHandler();

        public event OnClickHandler OnClick;

        //Informing subscribers that the button was clicked

        public void Click()
        {
            OnClick?.Invoke();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DelegatesDemoApp app = new DelegatesDemoApp();
            // app.Run();
            // app.LambdaExpressionDemo();
            // app.AnonymousMethodDemo();
            // app.HigherOrderFunctionDemo();

                Button button = new Button();
                button.OnClick += () => Console.WriteLine("Button was for 1st time!");
                button.OnClick += () => Console.WriteLine("Button was for 2nd time!");
                button.OnClick += () => Console.WriteLine("Button was for 3rd time!");
                button.OnClick += () => Console.WriteLine("Button was for 4th time!");
                button.Click();

                var assignment= new Assignment();
                assignment.Run();
            
        }
    }

    delegate int MathOperation(int a, int b);
    delegate void GenericTwoParameterAction<TFirst, TSecond>(TFirst a, TSecond b);
    class DelegatesDemoApp
    {

        public void HigherOrderFunctionDemo()
        {
            var result = CalculateArea(AreaOfReactangle);
            Console.WriteLine($"Area of rectangle: {result}");
        }

        int CalculateArea(Func<int,int,int> areaFunction)
        {
            return areaFunction(5, 10);
        }

        int AreaOfReactangle (int length, int width)
        {
            return length * width;
        }

        int AreaOfTriangle(int baseLength, int height)
        {
            return (baseLength * height) / 2;
        }



        void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public void LambdaExpressionDemo()
        {
            Func<int,int> f;
            f= (int x) => x * x;

            var result = f(5);
            Console.WriteLine($"The square of 5 is: {result}");
        }

        public void AnonymousMethodDemo()
        {
            MathOperation operation = delegate (int a, int b)
            {
                Console.WriteLine($"Anonymous method: Adding {a} and {b} gives {a + b}");
                return a + b;
            };
            operation(5,3);
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

            // return;

            Func<string, string, string> stringOperation = Concatenate;

            var x = stringOperation("Hello, ", "World!");
            Console.WriteLine($"Concatenation result: {x}");

            genericOperation += Subtract;
            genericOperation += Multiply;
            genericOperation += Divide;

            // operation(5,3);

            var result = genericOperation(5, 3);
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
            if (b != 0)
            {
                Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
                return a / b;
            }
            else
            {
                Console.WriteLine("Cannot divide by zero.");
            }
            return 0;
        }
    }
}