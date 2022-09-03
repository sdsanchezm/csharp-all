using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arrays in C sharp");

            String[] carBrands;
            float[] chessePrices;

            carBrands = new string[] { "Lambo", "Ferrari", "Pontiac", "Honda"};
            chessePrices = new float[] { 1.5f, 2.3f, 6.6f, 1.1f };

            Console.WriteLine($"{carBrands.Length}");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"item {i} {carBrands[i]}: {chessePrices[i]}");
            }

            // Using ForEach
            carBrands.ForEach((x) => Console.WriteLine(x));

        }
    }
}
