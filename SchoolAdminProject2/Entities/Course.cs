using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdminProject1.Entities
{
    class Course
    {
        public string CourseId { get; private set; } // this is because i dont want anyone to generate the id, only inside of the class
        public string CourseName { get; set; }
        public TypeOfJornada CourseJornada { get; set; }

        public Course()
        {
            CourseId = Guid.NewGuid().ToString();
        }

        

    }
}
