using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    public class Course
    {
        public string CourseId { get; private set; }
        public string CourseName { get; set; }
        public TypeOfJornada CourseJornada { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }

        //public Course()
        //{
        //    CourseId = Guid.NewGuid().ToString();
        //}

        public Course() => CourseId = Guid.NewGuid().ToString();
        

    }
}
