using System;
using System.Collections;

namespace Day5
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Garbage Collection Demo");

            // ResourceDemo();
            DisposableDemo();
            CollectionClasesDemo();
            RecordDemo();
            // ArrayCollectionDemo();
            NewCollectionClasesDemo();
            DictionaryDemo();
        }

        // private static void ResourceDemo()
        // {
        //     var res1 = new Resource("Res1");
        //     var res2 = new Resource("Res2");

        //     res1 = null;   // Eligible for GC

        //     GC.Collect();
        //     GC.WaitForPendingFinalizers();

        //     Console.WriteLine("GC Completed");
        // }

        // public static void ArrayCollectionDemo()
        // {
        //     ArrayList list = new ArrayList();
        //     list.Add(1);
        //     list.Add(2);
        //     list.Add(3);
        //     list.Add("Hello");
        //     list.Add(3.14);

        //     foreach (var item in list)
        //     {
        //         Console.WriteLine(item);
        //     }

        //     int sum = 0;

        //     foreach (var item in list)
        //     {
        //         Console.WriteLine($"item: {item}, type: {item.GetType()}");

        //         if (item is int number)
        //         {
        //             sum += number;
        //         }
        //     }

        //     Console.WriteLine($"Final Sum: {sum}");
        // }



        public static void CollectionClasesDemo()
        {
            List<string> List =new List<string>();
            List.Add("1");
            List.Add("2");
            List.Add("3");
            List.Add("4");

            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
        }

        public static void DictionaryDemo()
        {
            Dictionary<string, int > Dict =new Dictionary<string, int>();
            Dict.Add("Darshan",56);
            Dict.Add("Aayush",54);
            Dict.Add("Naresh",75);
            Dict.Add("Sai",67);

            foreach(var item in Dict)
            {
                Console.WriteLine($"name:{item.Key} marks:{item.Value}");
            }
        }

        public static void NewCollectionClasesDemo()
        {
            List<int> marks = new List <int>(10);
            marks.Add(90);
            marks.Add(80);
            Console.WriteLine($"Count: {marks.Count}, capacity: {marks.Capacity}");

            marks.AddRange(new int[] {1,2,3});
            Console.WriteLine($"Count: {marks.Count}, capacity: {marks.Capacity}");

            marks.AddRange(new int[] {4,5,6});
            Console.WriteLine($"Count: {marks.Count}, capacity: {marks.Capacity}");

            marks.AddRange(new int[] {4,5,6});
            Console.WriteLine($"Count: {marks.Count}, capacity: {marks.Capacity}");

            Console.WriteLine($"Average: {marks.Average()}");
        }



        private static void DisposableDemo()
        {
            using (var manager = new FileManager())
            {
                manager.OpenFile("example.txt");
            }

            using var manager2 = new FileManager();
        }

        private static void RecordDemo()
        {
            var temp1 = new Temp { Id = 1, Name = "Temp1" };
            var temp2 = new Temp { Id = 1, Name = "Temp1" };

            Console.WriteLine(temp1);
            Console.WriteLine(temp2);
            Console.WriteLine(temp1 == temp2);   // Value-based equality

            var temp3 = temp1 with { Id = 2 };
            Console.WriteLine(temp3);
        }
    }
}
