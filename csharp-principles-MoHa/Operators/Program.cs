// See https://aka.ms/new-console-template for more information

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = a++; // first assign, then increments
            Console.WriteLine("==");
            Console.WriteLine("a: {0} ", a); // 2
            Console.WriteLine("b: {0} ", b); // 1
            
            b = ++a; // first increment, then assign
            Console.WriteLine("==");
            Console.WriteLine("a: {0} ", a); // 3 
            Console.WriteLine("b: {0} ", b); // 3

            Console.WriteLine("===================");

            var x = 10;
            var y = 3;
            Console.WriteLine((float)x / (float)y); // with casting 3.333
            Console.WriteLine(x / y); // with no casting 3
            Console.WriteLine(x > y);
            
            Console.WriteLine( calculator.sum1(2,3 ) );

        }

        public class calculator
        {
            public static int sum1(int a, int b)
            {
                return a + b;
            }
        }
    }
}