// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

namespace controlFlow
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================if");
            int time1 = 10;

            if (time1 < 12)
            {
                Console.WriteLine("morning");
            }
            else if (time1 > 12)
            {
                Console.WriteLine("afternoon");
            }
            else
            {
                Console.WriteLine("night");
            }
            Console.WriteLine("==================ternary");

            bool isGoldCustomer = false;
            float price = isGoldCustomer ? 10.5f : 20.3f;
            Console.WriteLine("price: {0}", price);
            Console.WriteLine("==================switch");

            var seasonCase = Season.Winter;

            switch (seasonCase)
            {
                case Season.Winter:
                    Console.WriteLine("it's too cold!");
                    break;

                case Season.Autum:
                    Console.WriteLine("it's too cold!");
                    break;

                case Season.Summer:
                    Console.WriteLine("it's too cold!");
                    break;

                case Season.Spring:
                    Console.WriteLine("it's too cold!");
                    break;

                default:
                    Console.WriteLine("No season available");
                    break;

            }
        }
    }
}
