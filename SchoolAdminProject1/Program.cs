using System;
using SchoolAdminProject1.Entities;

namespace SchoolAdminProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Kraus Schule", 2021, TypesOfSchool.Secondary,
                country:"Der Schweiss", // thhis is an optional parameter
                city: "Wien" // this is an optional parameter
                );

            //school.Country = "Germany";
            //school.City = "Berlin";

            var ListOfCourses = new Course[3];

            ListOfCourses[0] = new Course()
            {
                CourseName = "201"
            };

            ListOfCourses[1] = new Course()
            {
                CourseName = "202"
            };

            ListOfCourses[2] = new Course()
            {
                CourseName = "203"
            };

            var course1 = new Course()
            {
                CourseName = "101"
                //CourseId = "jajaja"; // this cant be modified if the setter is private
            };

            var course2 = new Course()
            {
                CourseName = "102"
            };
            
            var course3 = new Course()
            {
                CourseName = "103"
            };

            //school.TypeOfSchool = TypesOfSchool.Secondary;
            Console.WriteLine(school);

            Console.WriteLine($"{course1.CourseName}: {course1.CourseId}");
            Console.WriteLine($"{course2.CourseName}: {course2.CourseId}");
            Console.WriteLine($"{course3.CourseName}: {course3.CourseId}");

            Console.WriteLine("=======================");
            PrintCourses(ListOfCourses);
            Console.WriteLine("=======================");

            // Foreach can also be used here
            foreach (var item in ListOfCourses)
            {
                Console.WriteLine($"{item.CourseName} - {item.CourseId}");
            }

        }

        private static void PrintCourses(Course[] arrayCourses)
        {
            int counter = 0;
            while (counter < arrayCourses.Length)
            {
                Console.WriteLine($"Course Name: \"{arrayCourses[counter].CourseName}\" - Course Id: \"{arrayCourses[counter].CourseId}\"");
                counter++;
            }
        }
    }
}
