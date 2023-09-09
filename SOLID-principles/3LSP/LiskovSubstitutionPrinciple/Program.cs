// 3LSP - Liskov Substitution Principle

namespace LiskovSubstitutionPrinciple
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Freelancer> list = new List<Freelancer>()
            {
                new FreelancerFT("Jamecho", 10, 10),
                new FreelanceContr("Jara", 10)
            };

            // can use this method like this because is static, if not, then an Object (containing the method) should be declared first and then call the method
            displayPay(list);

        }

        public static void displayPay(List<Freelancer> list)
        {
            foreach (Freelancer freelancer in list)
            {
                Console.WriteLine($"{freelancer.Name}: {freelancer.CalculatePay()}");
            }
        }

        // this function verifies if the freelancer is FT or Contractor and is a violation of 3LSP
        // since the implementation
        //void CalculateSalaryPay2(List<Freelancer> employees)
        //{
        //    foreach (var item in employees)
        //    {
        //        decimal salary = item.CalculatePay((item is FreelancerFT));
        //        Console.WriteLine($"The {item.Fullname}'s salary is {salary}");

        //    }
        //}
    }
}
