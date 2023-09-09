

namespace OpenClosePrinciple
{
    public abstract class Freelancer
    {
        public string Fullname { get; set; }
        public int HoursWorked { get; set; }

        public abstract decimal CalculatePay();
    }

}