using System;
using SchoolAdminProject1.Entities;
//using static System.Console; // this is the make Console.WrinteLine, only WriteLine (shorter)

namespace SchoolAdminProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Kraus Schule", 2021, TypesOfSchool.Secondary,
                country: "Der Schweiss", // thhis is an optional parameter
                city: "Wien" // this is an optional parameter
                );

            //school.Country = "Germany";
            //school.City = "Berlin";


            // ========== Creating an array using indexes: 
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

            // ========== Creating objects from the Course Object: 
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

            // ========== Creating an array 

            Course[] ListOfCourses2 = {
                new Course(){ CourseName = "c201"},
                new Course(){ CourseName = "c202"},
                new Course(){ CourseName = "c203"}
                };

            // another way to create the array: 
            var ListOfCourses3 = new Course[3]{
                new Course(){ CourseName = "c301"},
                new Course(){ CourseName = "c302"},
                new Course(){ CourseName = "c303"}
            };

            // Here the Property of the object school is being used: way 1
            school.ListOfAllCourses = new Course[]
            {
                new Course(){ CourseName = "course 301"},
                new Course(){ CourseName = "course 302"},
                new Course(){ CourseName = "course 303"}
            };

            // Here the Property of the object school is being used: way 2
            //Course[] ListOfAllCoursesX = {
            //    new Course(){ CourseName = "course 401"},
            //    new Course(){ CourseName = "course 402"},
            //    new Course(){ CourseName = "course 403"}
            //};
            //school.ListOfAllCourses = ListOfAllCoursesX;

            // This line is for testing, when the list of courses is null (empty:
            // school.ListOfAllCourses = null;

            // This is another test, if the school is null (empty)
            school = null;

            PrintAllCourses(school);

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

        private static void PrintAllCourses(School school)
        {
            Console.WriteLine("============================");
            Console.WriteLine("Official Courses of the School");

            //if (school != null && school.ListOfAllCourses != null) // this is an option
            if (school?.ListOfAllCourses != null) // this is another option, ListofAllCourses will not be validated until school is validated and not null
            {
                foreach (var course in school.ListOfAllCourses)
                {
                    Console.WriteLine($"Course name: {course.CourseName} - id: {course.CourseId}");
                }
            }
            Console.WriteLine("============================");

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
