// See https://aka.ms/new-console-template for more information

namespace TypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = 1;
            int i = (byte) b;
            Console.WriteLine(i);

            // data loss here and it's not possible
            var number = "1234";
            //int i = (int)number;
            Console.WriteLine(i);

            // data loss here
            var number2 = "1234";
            int j = Convert.ToInt32(number2);
            Console.WriteLine(j);

            try
            {
                var number3 = "1234";
                int k = Convert.ToByte(number3);
                Console.WriteLine(k);
            }
            catch (Exception)
            {
                Console.WriteLine("not converted");
                //throw;
            }

        }
    }
}