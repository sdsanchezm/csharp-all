

namespace OpenClosePrinciple
{
    public class FreelancerPT : IFreelancer
    {
        public string Fullname { get; set; }
        public int HoursWorked { get; set; }
        public FreelancerPT(string fullname, int hoursWorked)
        {
            Fullname = fullname;
            HoursWorked = hoursWorked;
        }

        public decimal CalculatePay()
        {
            decimal hourValue = 30000M;
            decimal payLocal = hourValue * HoursWorked;
            return payLocal;
        }
    }
}