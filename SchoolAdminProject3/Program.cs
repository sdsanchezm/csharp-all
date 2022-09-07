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

            

        }

        private static void PrintAllCourses(School school)
        {
            Printer.DrawTitle("SCHOOL DETAILS");

            if (school?.ListOfAllCourses != null) // this is another option, ListofAllCourses will not be validated until school is validated and not null
            {
                foreach (var course in school.ListOfAllCourses)
                {
                    Console.WriteLine($"Course name: {course.CourseName} - id: {course.CourseId}");
                }
            }
            Console.WriteLine("============================");

        }


    }
}
