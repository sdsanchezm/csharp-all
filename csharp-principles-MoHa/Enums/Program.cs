

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            var method1 = ShipingMethods1.Express;
            Console.WriteLine((int)method1); // 3

            var method2 = 3;
            Console.WriteLine((ShipingMethods1)method2); // Express

            // can be converted to strings
            Console.WriteLine(method1.ToString());

            // tring to enums
            var method3 = "Email";
            var ShippingMethod2 = (ShipingMethods1)Enum.Parse(typeof(ShipingMethods1), method3);
        }

        public enum ShipingMethods1 : byte
        {
            RegularMail = 1,
            RegisteredMail = 2,
            Express = 3
        }
    }
}