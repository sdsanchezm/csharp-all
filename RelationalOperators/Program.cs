using System;

namespace RelationalOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Control/Relational Operators");

            int value1 = 2;
            int value2 = 18;
            int value3 = -4;
            int value4 = 18;

            bool result1 = value2 == value2;
            bool result2 = value4 != value4;
            bool result3 = value2 < value1;
            bool result4 = value2 > value2;
            bool result5 = value3 >= value4;
            bool result6 = value2 <= value2;

            //== Igual a
            //!= No igual a
            //> Mayor que
            //< Menor que
            //>= Mayor o igual que
            //<= Menor o igual que

            Console.WriteLine($"value2 == value2: {value2 == value2}");
            Console.WriteLine($"value4 >= value2: {value4 >= value2}");

        }
    }
}
