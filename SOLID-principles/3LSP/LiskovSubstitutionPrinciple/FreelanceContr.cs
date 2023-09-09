namespace LiskovSubstitutionPrinciple
{
    public class FreelanceContr: Freelancer
    {
        // Contractor Freelancer in this case will not have extraHours, so it's different
        public FreelanceContr(string name, int hoursWorked) : base(name, hoursWorked)
        {
        }

        public override decimal CalculatePay()
        {
            decimal rateHour = 40;
            return rateHour * (HoursWorked);
        }

    }
}
