using System;
using System.Collections.Generic;
using CoreSchool.Entities;
using CoreSchool.Utils;


namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SchoolEngine();

            engine.InitializeSchool();

            PrintAllCourses(engine.Schoolx);

            PrintOneFullRecord(engine.Schoolx);

        }

        private static void PrintAllCourses(School school)
        {
            Printer.DrawTitle($"SCHOOL: {school.Name}");

            if (school?.ListOfAllCourses != null) // this is another option, ListofAllCourses will not be validated until school is validated and not null
            {
                Console.WriteLine($"Schoolid: {school.SchoolId}");

                foreach (var course in school.ListOfAllCourses)
                {
                    Console.WriteLine($"Course name: {course.CourseName} - id: {course.CourseId}");
                }
            }
            Console.WriteLine("============================");

        }

        private static void PrintOneFullRecord(School x)
        {
            Console.WriteLine($"School Name: {x.Name}");
            Console.WriteLine($"First Course Name: {x.ListOfAllCourses[0].CourseName}");
            Console.WriteLine($"First Subject Name: {x.ListOfAllCourses[0].Subjects[0].SubjectName}");
            Console.WriteLine($"First Student Name: {x.ListOfAllCourses[0].Students[0].StudentName}");
            Console.WriteLine("=================================");
            Console.WriteLine($"Number of courses: {x.ListOfAllCourses.Count}");
            //Console.WriteLine($"Number of Courses: {x.ListOfAllCourses.Count}");
            Console.WriteLine($"Number of Subjects in first Course: {x.ListOfAllCourses[0].Subjects.Count}");
            Console.WriteLine($"Number of Students in first Course: {x.ListOfAllCourses[0].Students.Count}");
        }


    }
}
