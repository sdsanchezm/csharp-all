namespace Functions
{
    class Program
    {
        public static void Main(string[] args)
        {
            var string5 = "this is a test";
            Console.WriteLine($"---------------{string5}-------------");

            Console.WriteLine($"1 + 2 + 3 = : {sum3Numbers(1, 2, 3)}");
            Console.WriteLine($"10 * 10 = : {square(10)}");


            printNumber(11);
            printNumber(21);

        }


        public static int sum3Numbers(int x, int y, int z) =>
            (
                (x + y + z)
            );

        // lambda function
        public static Func<int, int> square = x => x * x;

        // Anonymous method
        public static Action<int> printNumber = delegate (int num) {
            Console.WriteLine(num);
        };


    }
}