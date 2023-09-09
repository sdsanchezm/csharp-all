using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public abstract class Freelancer
    {
        public string Name { get; set; }
        public int HoursWorked { get; set; }

        // this is incorrect, because in this exercise, not all childs can have extraHours, so should be removed
        //public Freelancer(string name, int hoursWorked, int extraHours)
        //{
        //    Name = name;
        //    HoursWorked = hoursWorked;
        //}


        // Correct method here:
        public Freelancer(string name, int hoursWorked)
        {
            Name = name;
            HoursWorked = hoursWorked;
        }

        // 3LSP establish that types in parent classes, should be compatible with child classes
        // so an implementation here do not apply under 3LSP
        public abstract decimal CalculatePay();
    }
}
