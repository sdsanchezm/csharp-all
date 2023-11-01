using System;

namespace Amazon1
{

    public class RateCalculator
    {
        public int Calculate(Customer customer)
        {
            return 0;
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Promote()
        {
            //var rating = CalculateRating();
            //if (rating == 0)
            //    Console.WriteLine("Ok 1");
            //else
            //    Console.WriteLine("Nope 2");
            var calculator = new RateCalculator();
            var rating = calculator.Calculate(this);
            if (rating != 0)
            {

            }
            Console.WriteLine("promote logic changed");
        }

        //private int CalculateRating()
        protected int CalculateRating()
        {
            return 0;
        }
    }
}
