using Amazon1;

namespace AccessModifiers
{
    public class GoldCustomer : Customer
    {
        public void OfferVoucher()
        {
            this.CalculateRating();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            //customer.CalculateRating();
            Amazon1.RateCalculator calculator = new RateCalculator();
        }
    }
}