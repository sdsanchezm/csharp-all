using System;
using System.Collections.Generic;

namespace Methods1
{
    class Program
    {

        public void IntegerAddition(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"result is { result }");
        }

        public int IntegerSubstraction(int a, int b)
        {
            return (a - b);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Methods");


            Random rand = new Random();
            Console.WriteLine($"{rand.Next(1, 10)}");

            int x1 = 23;
            Console.WriteLine(x1.Equals(2));
            Console.WriteLine(x1.Equals(23));

            string kk2 = "this Is A Atring";
            Console.WriteLine(kk2);
            Console.WriteLine(kk2.ToUpper());
            Console.WriteLine(kk2.ToLower());

            // Method beep for the console:
            Console.Beep();

            List<int> randomNumbersLists = new List<int>();

            randomNumbersLists.Add(1);
            randomNumbersLists.Add(4);
            randomNumbersLists.Add(7);
            randomNumbersLists.Add(2);

            randomNumbersLists.ForEach( (x) => Console.WriteLine(x));

            // Generic Lists:
            // List<T> list = new List<T>();

            string ClassTopic = "String Methods";
            string School = "superHardwareHeute";

            // Clone and ToString - clone create a copy of the object, but must be converted to String, that's why ToString()
            string SchoolClone = School.Clone().ToString();
            Console.WriteLine(SchoolClone);

            // Compareto() - true if they're the same , false otherwise
            Console.WriteLine(ClassTopic.CompareTo(School));
            Console.WriteLine(School.CompareTo(SchoolClone));

            // Contains() - 
            Console.WriteLine(School.Contains("Stri"));

            // EndsWith() - 
            Console.WriteLine(School.EndsWith("ute"));


            // StartssWith() - 
            Console.WriteLine(School.StartsWith("sup"));


            // Equals() - verifies if it is the same or nopt
            Console.WriteLine(School.Equals(SchoolClone));

            // IndexOf() - Returns an index of letters 
            Console.WriteLine(School.IndexOf("a"));

            // ToLower() y ToUpper() - upper or lower case letters
            Console.WriteLine(ClassTopic.ToLower());
            Console.WriteLine(ClassTopic.ToUpper());

            // Insert() - insert a new string in the last position indicated, 6 in this case
            Console.WriteLine(School.Insert(6, " Effective speed "));

            // LastIndexOf() - report the LAST position of the letter 's' (in case several 's' will return the last one)
            Console.WriteLine(ClassTopic.LastIndexOf("s"));

            // Remove() - remove the element in the nth position
            Console.WriteLine(ClassTopic.Remove(6));

            // Replace() - all 's' will be changed with 'z' 
            Console.WriteLine(ClassTopic.Replace("s", "z"));

            // Split() - Breaks the String in parts, returning a number of strings (eg. "abcdefgabcdefg" will be separated in: a, cdefga, and cdefg)
            string newStringHere = "abcdefgabcdefg";
            string[] split = newStringHere.Split(new char[] { 'b' });
            Console.WriteLine(split[0]);
            Console.WriteLine(split[1]);
            Console.WriteLine(split[2]);

            // Substring() -- return a piece of the string. depending of the index
            Console.WriteLine(ClassTopic.Substring(2, 10));

            // ToCharArray() -- converts string into an array of chars
            School.ToCharArray();

            // Trim() - removes spaces and the bgining and at the end of a string
            string TextWithSpaces = "  hi, there are speces at the beggining and at the end ";
            Console.WriteLine(TextWithSpaces.Trim());


            Program k1 = new Program();
            k1.IntegerAddition(21, 42);

            int result2 = k1.IntegerSubstraction(63, 21);
            Console.WriteLine(result2);


        }
    }
}
