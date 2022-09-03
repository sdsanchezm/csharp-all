using System;

namespace Conditionals1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conditionals");


            int points = 5;

            if ( points > 5 )
            {
                Console.WriteLine("is bigger than 5 points");
            }
            else
            {
                Console.WriteLine("is not bigger than 5 points");
            }

            // ternary Operator:
            // Here I'm declaring a function that based on a ternary operator, is returning a string
            string isBiggerThan10(double number1) => number1 > 10.0 ? "Bigger than 10!" : "Not bigger than 10.";

            Console.WriteLine(isBiggerThan10(9.1));  
            Console.WriteLine(isBiggerThan10(22.2));


            // Switch case:

            Console.WriteLine("Please enter your snack: ");
            string caseSwitch = Console.ReadLine();

            switch (caseSwitch)
            {
                case "chips":
                    Console.WriteLine("chips- $13 USD");
                    break;
                case "tostis":
                    Console.WriteLine("tostis  - $11.4 USD");
                    break;
                case "rice":
                    Console.WriteLine("rice snack- $5.5 USD");
                    break;
                case "veg":
                    Console.WriteLine("veggies snack - $10 USD");
                    break;
                default:
                    Console.WriteLine("ERROR: option selection is not valid, please try again.");
                    break;
            }
        }
    }
}
