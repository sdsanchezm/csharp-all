// See https://aka.ms/new-console-template for more information


namespace Lists1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1,2,3,4,5};
            numbers.Add(1); // add 1 at the end of the list
            numbers.AddRange(new int[3] {5,6,1}); // add  at the end of the list
            foreach(var number in numbers )
            {
                Console.Write("  {0}", number);
            }
            Console.WriteLine();

            numbers.IndexOf(4); // returns the index of the element
            numbers.LastIndexOf(5); // returns the last inedx

            Console.WriteLine("Count: " + numbers.Count());

            numbers.Remove(1);
            foreach(var n in numbers)
            {
                Console.Write("  {0}", n);
            }
            Console.WriteLine();

            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == 1)
                {
                    numbers.Remove(numbers[i]);
                }
            }

            PrintArray.prinArrayHere(numbers);

            numbers.Clear(); //clears the list

            PrintArray.prinArrayHere(numbers);
        }
    }

    public static class PrintArray 
    { 
        public static void prinArrayHere(List<int> Array1)
        {
            Console.WriteLine("prinArrayHere===");
            foreach (var i in Array1)
            {
                Console.Write("  {0}", i);
            }
            Console.WriteLine();
        }

    }
}
