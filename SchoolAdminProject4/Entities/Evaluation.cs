using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    public class Evaluation: SchoolBaseClass
    {
        // These props are defined in the parent SchoolBaseClass
        //public string UniqueId { get; set; }
        //public string Name { get; set; }
        //public Evaluation() => UniqueId = Guid.NewGuid().ToString();

        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Grade { get; set; }
    }
}
