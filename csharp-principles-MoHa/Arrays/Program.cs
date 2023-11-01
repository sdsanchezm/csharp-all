// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // fixed size
            int[] array1 = new int[3];
            var array1_v2 = new int[3];

            // initialize
            int[] array2 = new int[3] { 21, 24, 26 };
            var array2_v2 = new int[3] { 21, 24, 26 };

            // initialize 3
            int[] array3 = new int[3];
            var array_v2 = new int[3];
            array3[0] = 88;
            array3[1] = 80;
            array3[2] = 81;

            // all arrays initialize in 0
            // all boolean variables are initialzied in false
            var arrayBools1 = new bool[3] { true, true, false };
            var arrayBools_v2 = new bool[3];
            arrayBools_v2[1] = true;

            // array of strings
            var arrayStrings1 = new string[3] { "amparo", "jamecho", "tiche" };
            var arrayStrings1_v2 = new string[3];
            arrayStrings1_v2[0] = "pow";

            // Jagged Arrays
            var arrayJagged1 = new int[3][];
            arrayJagged1[0] = new int[2] {4, 6};
            arrayJagged1[1] = new int[1] {9};
            arrayJagged1[2] = new int[3] {5,5,6};
            Console.WriteLine(arrayJagged1[0][0]);

            // Rectangular Array
            var arrayRectangular1 = new int[3, 5];

            // Array type is a class (part of the System namespace) with its own methods
            // Regular 2 Syntax: 
            var matrix1 = new int[2,3];

            var singleDimentionalArray_v1 = new int[5] { 2, 3, 4, 2, 8 };

            // 2d array (matrix) initialized in other way
            var matrix1_v2 = new int[2, 3]
            {
                {2, 3, 4 },
                {6, 7, 4 }
            };
            // to access it:
            //matrix1_v2[0, 0];
            Console.WriteLine(matrix1_v2.Length);
            //matrix1_v2.Length

            // 3d 
            var matrix1_v3 = new int[3, 3]
            {
                {2, 3, 4 },
                {1, 2, 2 },
                {7, 8, 9 }
            };
            Console.WriteLine(matrix1_v3[0, 0]);


            // Length
            Console.WriteLine("length: " + singleDimentionalArray_v1.Length);

            // IndexOf()
            var res1 = Array.IndexOf(singleDimentionalArray_v1, 8);
            Console.WriteLine("index of 8: " + res1);

            // Clear()
            Array.Clear(singleDimentionalArray_v1, 0, 2);
            foreach(var n in singleDimentionalArray_v1)
                Console.WriteLine("> " + n);

            // Copy()
            var singleDimentionalArray_v2 = new int[5];
            Array.Copy(singleDimentionalArray_v1, singleDimentionalArray_v2, 5);

            foreach(var n in singleDimentionalArray_v2)
                Console.WriteLine("new: " + n);

            // Sort()
            Array.Sort(singleDimentionalArray_v2 );
            foreach(var n in singleDimentionalArray_v2)
                Console.WriteLine("sorted: " + n);

            // documentation here: https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-7.0

        }
    }
}