using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    public class Course: SchoolBaseClass
    {
        // These props are inherited from SchoolBaseClass
        //public string UniqueId { get; private set; }
        //public string Name { get; set; }
        //public Course() => UniqueId = Guid.NewGuid().ToString();

        public TypeOfJornada CourseJornada { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }

        //public Course()
        //{
        //    UniqueId = Guid.NewGuid().ToString();
        //}

        

    }
}
