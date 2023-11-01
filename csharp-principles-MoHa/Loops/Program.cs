namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("======================for");

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("  {0}", i);
                }
                Console.WriteLine();
            }


            Console.WriteLine("======================foreach");

            var name1 = "jamecho";

            for (int i = 0; i < name1.Length; i++)
            {
                Console.Write("  {0}", name1[i]);
            }
            Console.WriteLine();

            foreach (var letter in name1)
            {
                Console.Write(letter);
            }
            Console.WriteLine();

            Console.WriteLine("======================while");

            var j = 0;
            while(j < 10)
            {
                if(j % 2 == 0)
                    Console.Write(" {0}", j);

                //Console.WriteLine();
                j++;
            }
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("write your name: ");
                var input1 = Console.ReadLine();

                if(input1 != null)
                {
                    Console.WriteLine(input1);
                    break;
                }
                else if (String.IsNullOrWhiteSpace(input1))
                {
                    Console.WriteLine("asd");
                }
                else
                {
                    Console.WriteLine("empty!");
                    break;
                }
            }

            Console.WriteLine("======================random");

            var random1 = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(random1.Next(1,20));
            }
            Console.WriteLine();


            var passwordSize = 10;
            var buffer = new char[passwordSize];

            for (int i = 0;i < passwordSize; i++)
            {
                buffer[i] = (char)('a' + random1.Next(0, 26));
            }
                //Console.Write((char)('a' + random1.Next(0,26)));
                var pass1 = new string(buffer);
            Console.WriteLine(buffer);
        }
    }
}