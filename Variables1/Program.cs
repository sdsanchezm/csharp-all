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

            Console.WriteLine("Int: " + integerVariable + integerVariable.GetType());
            Console.WriteLine("bool: " + isenabled);
            Console.WriteLine("float: " + floatNumber);
            Console.WriteLine("double: " + doubleNumber);
            Console.WriteLine("char: " + charVariable);
            Console.WriteLine("string: " + stringVariable);
            Console.WriteLine("long: " + longVariable);
            Console.WriteLine("uint: " + uintVariable);

            Console.WriteLine("type your name");
            //var name = Console.ReadLine(); // Var can infer whatever type
            string name = Console.ReadLine(); 
            Console.WriteLine("Greetings " + name);


            Console.WriteLine("type the first number");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("type the first number");
            int x2 = Convert.ToInt32(Console.ReadLine());
            int result = x1 + x2;

            //Console.WriteLine("result: " + result);
            Console.WriteLine($"result: {result}"); // this is another way, like template literals


            // this is a way to work with strings: 
            int age = 22;
            int height = 190;
            string name1 = "Jamecho";
            string infoVar = "the requested info is, name: " + name1 + " heigth: " + height + " age: " + age;
            Console.WriteLine(infoVar);

            infoVar = "the requested info is \n name: " + name1 + "\n heigth: " + height + "\n age: " + age;
            Console.WriteLine(infoVar);

            infoVar = "The requested info is:\n" +
            $"\tUser name = {name1}\n" +
            $"\tUser age = {age}\n" +
            $"\tUser height = {height}";

            Console.WriteLine(infoVar);

            infoVar = $"The requested info is:\nUser name: {name1} \nUser age: {age} \nUser height: {height}";
            Console.WriteLine(infoVar);


        }
    }
}
