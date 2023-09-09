

namespace OpenClosePrinciple
{
    public class FreelancerContr : Freelancer
    {
        public FreelancerContr(string fullname, int hoursWorked)
        {
            Fullname = fullname;
            HoursWorked = hoursWorked;
        }
        public override decimal CalculatePay()
        {
            decimal hourValue = 50000M;
            decimal payLocal = hourValue * HoursWorked;
            return payLocal;
        }
    }

}