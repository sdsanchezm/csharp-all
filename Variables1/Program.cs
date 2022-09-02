using System;

namespace Variables1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Types in C#");

            int integerVariable = 21;
            bool isenabled = true;
            float floatNumber = 0.2398f;
            double doubleNumber = 34.23d;
            char charVariable = 'a';
            string stringVariable = "this is a test";
            long longVariable = 100000900;
            uint uintVariable = 5;

            Console.WriteLine("Int: " + integerVariable);
            Console.WriteLine("bool: " + isenabled);
            Console.WriteLine("float: " + floatNumber);
            Console.WriteLine("double: " + doubleNumber);
            Console.WriteLine("char: " + charVariable);
            Console.WriteLine("string: " + stringVariable);
            Console.WriteLine("long: " + longVariable);
            Console.WriteLine("uint: " + uintVariable);

        }
    }
}
