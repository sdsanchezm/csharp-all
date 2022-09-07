using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdminProject3.Entities
{
    class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }

        private Student() => Guid.NewGuid().ToString();
    }
}
