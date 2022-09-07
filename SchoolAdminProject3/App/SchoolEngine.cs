using CoreSchool.Entities;
using System;
using System.Collections.Generic;

namespace CoreSchool
{
    public class SchoolEngine
    {
        public School Schoolx { get; set; }

        public SchoolEngine()
        {

        }

        public void InitializeSchool()
        {
            Schoolx = new School("Kraus Schule", 2021, TypesOfSchool.Secondary,
                country: "Der Schweiss",
                city: "Wien"
            );

            Schoolx.ListOfAllCourses = new List<Course>()
            {
                new Course() { CourseName = "course 301", CourseJornada = TypeOfJornada.Afternoon },
                new Course() { CourseName = "course 302", CourseJornada = TypeOfJornada.Morning },
                new Course() { CourseName = "course 303", CourseJornada = TypeOfJornada.Night },
                new Course() { CourseName = "course 305", CourseJornada = TypeOfJornada.Morning },
                new Course() { CourseName = "course 401", CourseJornada = TypeOfJornada.Night }
            };
        }
    }
}
