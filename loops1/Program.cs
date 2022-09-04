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

            // Do While
            bool runVerify1 = false;

            do
            {
                Console.WriteLine("Wish to keep your app running? type 1 if so, 0 otherwise");
                int appRunning = Convert.ToInt16(Console.ReadLine());
                if (appRunning == 1)
                {
                    Console.WriteLine("The app is running");
                    runVerify1 = true;
                }
                else if (appRunning == 0)
                {
                    Console.WriteLine("This is the last time this app is running");
                    runVerify1 = false;
                }
                else
                    Console.WriteLine("Invalid input, Try Again.");
            } while (runVerify1 == true);

            // While
            int i1 = 0;
            while (i1 < 5)
            {
                Console.WriteLine(i1);
                i1++;
            }

            //var ListOfCourses = new int();
            int[] ListOfCourses = { 1001, 3011, 6011, 2002};
            // Foreach can also be used 
            foreach (var item in ListOfCourses)
            {
                Console.WriteLine($"{item}");
            }

        }
    }
}
