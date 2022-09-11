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

            // Here, cannot create instances because the SchoolBaseClass is abstract
            // var object1 = new SchoolBaseClass();

        }

        private static void PrintAllCourses(School school)
        {
            Printer.DrawTitle($"SCHOOL: {school.Name}");

            if (school?.ListOfAllCourses != null) 
            {
                Console.WriteLine($"Schoolid: {school.UniqueId}");

                foreach (var course in school.ListOfAllCourses)
                {
                    Console.WriteLine($"Course name: {course.Name} - id: {course.UniqueId}");
                }
            }
            Console.WriteLine("============================");

        }

        private static void PrintOneFullRecord(School x)
        {
            Console.WriteLine($"School Name: {x.Name}");
            Console.WriteLine($"First Course Name: {x.ListOfAllCourses[0].Name}");
            Console.WriteLine($"First Subject Name: {x.ListOfAllCourses[0].Subjects[0].Name}");
            Console.WriteLine($"First Student Name: {x.ListOfAllCourses[0].Students[0].Name}");
            Console.WriteLine("=================================");
            Console.WriteLine($"Number of courses: {x.ListOfAllCourses.Count}");
            //Console.WriteLine($"Number of Courses: {x.ListOfAllCourses.Count}");
            Console.WriteLine($"Number of Subjects in first Course: {x.ListOfAllCourses[0].Subjects.Count}");
            Console.WriteLine($"Number of Students in first Course: {x.ListOfAllCourses[0].Students.Count}");
            Console.WriteLine($"First Evaluation name of the first student: {x.ListOfAllCourses[0].Students[0].Evaluations[0].Name}");
            Console.WriteLine($"Evaluation grade of the first student: {x.ListOfAllCourses[0].Students[0].Evaluations[0].Grade}");
        }

    }
}