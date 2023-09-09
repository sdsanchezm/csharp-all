

namespace OpenClosePrinciple
{
    public class FreelancerFT: Freelancer
    {

        public FreelancerFT(string fullname, int hoursWorked)
        {
            Fullname = fullname;
            HoursWorked = hoursWorked;
        }

        public override decimal CalculatePay()
        {
            decimal hourValue = 30000M;
            decimal payLocal = hourValue * HoursWorked;
            return payLocal;
        }
    }
    
}