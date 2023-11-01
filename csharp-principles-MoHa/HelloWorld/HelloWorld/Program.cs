// See https://aka.ms/new-console-template for more information

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int @int = 1;
            Console.WriteLine("Hello, World! ${@int}");
            Console.WriteLine(@int);
            // scoope testing
            {
                byte a = 1;
                Console.WriteLine(a);
                //Console.WriteLine(b);
                //Console.WriteLine(c);
                    {
                    byte b = 2;
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    //Console.WriteLine(c);
                    {
                        byte c = 3;
                        Console.WriteLine(a);
                        Console.WriteLine(b);
                        Console.WriteLine(c);
                    }
                }
            }

            int count = 10;
            float price1 = 2.34f;
            char character = 'A';
            string lastname = "Sanc";
            bool isWorking = false;

            Console.WriteLine(count);
            Console.WriteLine(price1);
            Console.WriteLine(character);
            Console.WriteLine(lastname);
            Console.WriteLine(isWorking);

            var count3 = 10;
            var price3 = 2.34f;
            var character3 = 'A';
            var lastname3 = "Sanc";
            var isWorking3 = true;

            Console.WriteLine(count3);
            Console.WriteLine(price3);
            Console.WriteLine(character3);
            Console.WriteLine(lastname3);
            Console.WriteLine(isWorking3);

            // templates (format string)
            Console.WriteLine("{0} - {1}", byte.MinValue, byte.MaxValue);
            Console.WriteLine("{0} - {1}", float.MinValue, float.MaxValue);

        }
    }
}
