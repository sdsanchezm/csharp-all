using System;

namespace LogicOperators1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Logic Operators");

            bool value1 = true;
            bool value2 = false;

            // &&, ||, !

            Console.WriteLine($"true && false is: {value1 && value2}");
            Console.WriteLine(value1 || value2);
            Console.WriteLine(value1 && !value2);
            Console.WriteLine(value1 ^ value2);

            // Different way to declare variable
            var (xa, xb, xc) = (false, true, false);

            // this is not permited because is implicitly changing the type pf a variable
            // xa = 123;  

            Console.WriteLine($"xa: {xa} xa: {xb} xa: {xc}");


        }
    }
}
