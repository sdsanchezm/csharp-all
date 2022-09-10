using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    public class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }

        public Student() => StudentId = Guid.NewGuid().ToString();
    }
}
