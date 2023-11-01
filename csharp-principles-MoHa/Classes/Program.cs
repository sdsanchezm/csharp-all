// See https://aka.ms/new-console-template for more information

using Classes.Math;
using System.Security.Cryptography.X509Certificates;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            // this way is possible because the class is public
            Calculator calc1 = new Calculator();
            //Console.WriteLine(calc1.sum1(7, 4));

            // sum1 must be static and public in order to be used like this
            Console.WriteLine(Calculator.sum1(7, 4));

            // if sum1 is not static we CANNOT use this way
            //Console.WriteLine(Calculator.sum1(1, 3));

            // one way:
            //Person person = new();
            //Person person1 = person;

            //another way:
            Person person1 = new();

            // another way:
            Person person2 = new Person();

            // another way
            var person4 = new Person();

        }
    }
    // struct definition
    public struct RgbColor 
    {
        public int Red;
        public int Green;
        public int Blue;

    }


}