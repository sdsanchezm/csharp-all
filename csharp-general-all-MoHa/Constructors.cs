using System;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car("A1B2C3");
        }
    }

    public class Vehicle
    {
        private readonly string _registrationValue;

//        public Vehicle()
//        {
//            Console.WriteLine("Vehicle is initializing...");
//        }

        // int this method we are initializing the private field (passing it through the argument)
        public Vehicle(string registrationValue)
        {
            _registrationValue = registrationValue;

            Console.WriteLine($"Vehicle with value {registrationValue} is initializing...");
        }
    }


    // the constructor is not inherited here
    public class Car : Vehicle
    {
        public Car(string registrationValue)
            : base(registrationValue) // re-use the code in the Vehicle constructor
        {
            Console.WriteLine($"Car with value {registrationValue} is initializing...");
        }
    }
}

