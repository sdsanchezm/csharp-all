using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class FreelancerFT: Freelancer
    {
        // this implementation is incorrect, because parent class does not contain hoursworked
        //public FreelancerFT(string name, int hoursWorked, int hoursworked) : base (name, hoursWorked, hoursworked) {}

        public int ExtraHours { get; set; }
        public FreelancerFT(string name, int hoursWorked, int extraHours) : base(name, hoursWorked) 
        {
        }

        public override decimal CalculatePay()
        {
            decimal hourValue = 50;
            return hourValue * (ExtraHours + HoursWorked);
        }

    }
}
