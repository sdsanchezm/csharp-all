
namespace OpenClosePrinciple
{
    interface IFreelancer
    {
        public string Fullname { get; set; }
        public int HoursWorked { get; set; }
        public decimal CalculatePay();
    }

}
