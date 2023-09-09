

namespace OpenClosePrinciple
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShowPay(new List<Freelancer>() {
                new FreelancerFT("Jamecho", 160),
                new FreelancerContr("TicheMaria", 200)
            });

            ShowPayWithInterfaces(new List<IFreelancer>()
            {
                new FreelancerPT("Jara", 180)
            });
        }

        static void ShowPay(List<Freelancer> freelancer)
        {
            foreach (var item in freelancer)
            {
                Console.WriteLine($"Resource: {item.Fullname}, Total: {item.CalculatePay():C1} ");
            }

        }

        static void ShowPayWithInterfaces(List<IFreelancer> freelancer)
        {
            foreach (var item in freelancer)
            {
                Console.WriteLine($"Resource: {item.Fullname}, Total: {item.CalculatePay():C1} ");
            }

        }

        // The below code violates the 1SPR and do not apply the 2OCP
        // Instead, a parent Freelance class is created and 3 more classes inheriting from it
        // This can also be implemented using interfaces
        //void CalculateSalaryMonthly(List<object> freelancers)
        //{
        //    foreach (var freelancer in freelancers)
        //    {
        //        if (freelancer is freelancerFullTime)
        //        {
        //            decimal hourValue = 30000M;
        //            freelancerFullTime freelancerFullTime = ((freelancerFullTime)freelancer);
        //            decimal salary = hourValue * freelancerFullTime.HoursWorked;
        //            Console.WriteLine($"Empleado: {freelancerFullTime.Fullname}, Pago: {salary:C1} ");
        //        }
        //        else
        //        {
        //            decimal hourValue = 20000M;
        //            freelancerPartTime freelancerPartTime = ((freelancerPartTime)freelancer);
        //            decimal salary = hourValue * freelancerPartTime.HoursWorked;
        //            if (freelancerPartTime.HoursWorked > 160)
        //            {
        //                decimal effortCompensation = 5000M;
        //                int extraDays = freelancerPartTime.HoursWorked - 160;
        //                salary += effortCompensation * extraDays;
        //            }
        //            Console.WriteLine($"Empleado: {freelancerPartTime.Fullname}, Pago: {salary:C1} ");
        //        }
        //    }

        //}
    }
}