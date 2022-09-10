using CoreSchool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

            // Loading courses
            LoadCourses();

            // Loading Subjects:
            LoadSubjects();

            // Loading Students
            LoadStudents(10);

            Console.WriteLine($"rand: {RandomIntegerGenerator(3,9)}");

            //LoadEvaluations();


        }

        private void LoadCourses()
        {
            Schoolx.ListOfAllCourses = new List<Course>()
            {
                new Course() { CourseName = "course 301", CourseJornada = TypeOfJornada.Afternoon },
                new Course() { CourseName = "course 302", CourseJornada = TypeOfJornada.Morning },
                new Course() { CourseName = "course 303", CourseJornada = TypeOfJornada.Night },
                new Course() { CourseName = "course 305", CourseJornada = TypeOfJornada.Morning },
                new Course() { CourseName = "course 401", CourseJornada = TypeOfJornada.Night }
            };

            foreach (var item in Schoolx.ListOfAllCourses)
            {
                item.Students = LoadStudents( RandomIntegerGenerator(3, 9) );
            }
        }

        private void LoadEvaluations()
        {
            //throw new NotImplementedException();
        }

        private void LoadSubjects()
        {
            //throw new NotImplementedException();

            foreach (var courseItem in Schoolx.ListOfAllCourses)
            {
                var list1 = new List<Subject>()
                {
                    new Subject{SubjectName = "Math Sci"},
                    new Subject{SubjectName = "Biology Schi"},
                    new Subject{SubjectName = "Chemical Sci"},
                    new Subject{SubjectName = "Physics Sci"}
                };
                courseItem.Subjects = list1;
            }

        }

        private List<Student> LoadStudents( int numberOfStudents )
        {
            string[] names1 = { "Jamecho", "Jara", "Nairo", "Paco", "Tiche", "Obama", "Amparo", };
            string[] names2 = { "Monster", "Maria", "Homer", "Rick", "Morty", };
            string[] lastName1 = { "Kartman", "Marsh", "Reflesk", "Kork", "Nimber", "Gonzo", "Sancl", };

            // LINQ, Language Integrated Queries, this is like 3 nested for loops
            var listRandom1 = from n1 in names1
                              from n2 in names2
                              from ln1 in lastName1
                              select new Student { StudentName = $"{n1} {n2} {ln1}" };

            return listRandom1.OrderBy((item) => item.StudentId ).Take(numberOfStudents).ToList();
        }

        public static int RandomIntegerGenerator(int limitLow, int limitHigh)
        {
            Random rand1 = new Random();
            int randomNumber1 = rand1.Next(limitLow, limitHigh);
            return randomNumber1;
        }

    }
}
