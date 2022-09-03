using System;

namespace Operators1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rectangle Area Calculation");

            Console.WriteLine("type longitude side 1");
            float side1 = float.Parse(Console.ReadLine());
            Console.WriteLine("type longitude side 2");
            float side2 = float.Parse(Console.ReadLine());
            float area = side1 * side2;
            Console.WriteLine(area);

            float x1 = 5.5f;// float must have an f at the end
            int x2 = 4;
            float res = x1 * x2; // this is possible only if res is float

            //add +
            //substract - 
            //ModuleHandle %
            //multipl *
            //DivideByZeroException /
            //increment ++
            //decrement --

        }
    }
}
