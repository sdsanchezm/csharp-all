using System;
using System.Collections.Generic;

namespace Methods1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Methods");


            Random rand = new Random();
            Console.WriteLine($"{rand.Next(1, 10)}");

            int x1 = 23;
            Console.WriteLine(x1.Equals(2));
            Console.WriteLine(x1.Equals(23));

            string kk2 = "this Is A Atring";
            Console.WriteLine(kk2);
            Console.WriteLine(kk2.ToUpper());
            Console.WriteLine(kk2.ToLower());

            // Method beep for the console:
            Console.Beep();

            List<int> randomNumbersLists = new List<int>();

            randomNumbersLists.Add(1);
            randomNumbersLists.Add(4);
            randomNumbersLists.Add(7);
            randomNumbersLists.Add(2);

            randomNumbersLists.ForEach( (x) => Console.WriteLine(x));

            // Generic Lists:
            // List<T> list = new List<T>();



        }
    }
}
