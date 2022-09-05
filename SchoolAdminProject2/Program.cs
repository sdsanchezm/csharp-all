using System;
using System.Collections.Generic;
using SchoolAdminProject1.Entities;

namespace SchoolAdminProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Kraus Schule", 2021, TypesOfSchool.Secondary,
               country: "Der Schweiss",
               city: "Wien" 
               );

            // This is a preview of a collection generic here
            // System.Collections.Generic

            // it must be optimized for an specific type of data, 'Course' in this case what is inside of the < >

            school.ListOfAllCourses = new List<Course>()
            { 
                new Course() { CourseName = "course 301" },
                new Course() { CourseName = "course 302" },
                new Course() { CourseName = "course 303" }
            };


            school.ListOfAllCourses.Add( new Course() { CourseName="course 304", CourseJornada=TypeOfJornada.Morning} );
            school.ListOfAllCourses.Add( new Course() { CourseName="course 305", CourseJornada=TypeOfJornada.Afternoon} );

            var otherCollection = new List<Course>()
            {
                new Course(){ CourseName = "course 401"},
                new Course(){ CourseName = "course 402"},
                new Course(){ CourseName = "course 403"}
            };

            Course tempcourse = new Course()
            {
                CourseName = "vacational temp 001",
                CourseJornada = TypeOfJornada.Night
            };
            school.ListOfAllCourses.Add(tempcourse);

            // This way another collection is added to our list
            school.ListOfAllCourses.AddRange(otherCollection);

            // Remove all members of the collection
            //school.ListOfAllCourses.Clear();

            //school.ListOfAllCourses.Remove();

            PrintAllCourses(school);

            school.ListOfAllCourses.Remove(tempcourse);

            PrintAllCourses(school); 

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
