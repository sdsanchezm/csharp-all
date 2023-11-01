
using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void UsingOutModifier()
        {
            try
            {
                var num = int.Parse("sometext");
            }
            catch (Exception)
            {
                Console.WriteLine("failed - conversion not successfull");
            }


            int number;
            var result = int.TryParse("sometext", out number);
            if (result)
                Console.WriteLine(number);
            else
                Console.WriteLine("conversion not successfull.");

        }

        static void UsingParams()
        {
            var sumArray = new SumOfArrayValues();
            Console.WriteLine(sumArray.Add(11, 20));
            Console.WriteLine(sumArray.Add(11, 22, 33));
            Console.WriteLine(sumArray.Add(11, 21, 32, 34));
            // declaring an object int[] type
            Console.WriteLine(sumArray.Add(new int[] { 11, 22, 13, 24, 15 }));
        }

        static void UsingPoints()
        {
            try
            {
                var point = new Point(15, 25);
                point.Move(null);
                Console.WriteLine("Status update. Point is now at ({0}, {1})", point.X, point.Y);
                // moving point and printing the new location
                // i nother words: updating and showing actual status of the object
                point.Move(70, 90);
                Console.WriteLine("Status update. Point is now at ({0}, {1})", point.X, point.Y);
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error occured.");
            }
        }
    }

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // updating the state of the object
        // this function is called by using 2 int parameters (which is a point)
        public void Move(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // Verifying if null, and throwing an exception if so
        // the argument is Point type
        public void Move(Point newLocation)
        {
            if (newLocation == null)
                throw new ArgumentNullException("newLocation");

            Move(newLocation.X, newLocation.Y);
        }
    }

    // this method calcualtes the sum of all int values in an array
    public class SumOfArrayValues
    {
        public int Add(params int[] numbers)
        {
            var count = 0;

            foreach (var value in numbers)
            {
                count += value;
            }

            return count;
        }
    }
}