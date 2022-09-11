using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    public class Student: SchoolBaseClass
    {
        // this is inherited from SchoolBaseClass
        //public string UniqueId { get; set; }
        //public string Name { get; set; }

        // If this list is not initialized, it does NOT exist. 
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        public Student() => UniqueId = Guid.NewGuid().ToString();
    }
}
