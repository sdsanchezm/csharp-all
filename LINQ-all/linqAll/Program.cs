using System.Linq;


namespace linqAll
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fruits = new string[] { "apple", "cherry", "strawberry", "blueberry", "pineapple", "passion fruit", "lima", "papaya"};
            var fruitsList = fruits.Where(p => p.StartsWith("pa")).ToList();

            fruitsList.ForEach(p => { Console.WriteLine(p); });



        }
    }
}