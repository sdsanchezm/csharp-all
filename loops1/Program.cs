using System;

namespace loops1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loops");

            // Size: 3 in this case

            // these 2 variables are not variables, they're constants
            const int size2 = 2;
            const int size3 = 3;

            // 2 dimensional array - no size specific
            int[,] matrix = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            // 2 dimensional array - size specific
            // size2 and size3 are constants
            int[,] array2Da = new int[size2, size3] { { 1, 2, 3 }, { 5, 3, 4 }};

            // Three-dimensional array.
            int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };

            // The same array with dimensions specified.
            int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                       { { 7, 8, 9 }, { 10, 11, 12 } } };

            for (int i = 0; i < size2; i++)
            {
                for (int j = 0; j < size3; j++)
                {
                    //Console.WriteLine($" r: {array2Da[i,j]}");
                    Console.Write($" {array2Da[i, j]} ");
                }
                Console.Write("\n");
            }

        }
    }
}
