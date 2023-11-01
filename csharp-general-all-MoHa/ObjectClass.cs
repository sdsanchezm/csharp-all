namespace ObjectClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "I am car s1";
            string s2 = "I am car s2";

            Console.WriteLine(s1 == s2);
            Console.WriteLine(s1.Equals(s2));

            var car1 = new Auto() {Id = 11};
            var car2 = new Auto() {Id = 22};

            Console.WriteLine(car1 == car2);
            Console.WriteLine(car1.Equals(car2));
        }
    }

    public class Auto
    {
        public int Id { get; set; }
    }
}