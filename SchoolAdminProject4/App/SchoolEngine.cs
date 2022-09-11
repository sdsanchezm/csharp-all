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

            Console.WriteLine($"rand int: { RandomIntegerGenerator(3,9) }");
            Console.WriteLine($"rand float: { RandomFloatGenerator() }");

            // Loading Evaluations
            LoadEvaluations();


        }

        private void LoadCourses()
        {
            Schoolx.ListOfAllCourses = new List<Course>()
            {
                new Course() { Name = "course 301", CourseJornada = TypeOfJornada.Afternoon },
                new Course() { Name = "course 302", CourseJornada = TypeOfJornada.Morning },
                new Course() { Name = "course 303", CourseJornada = TypeOfJornada.Night },
                new Course() { Name = "course 305", CourseJornada = TypeOfJornada.Morning },
                new Course() { Name = "course 401", CourseJornada = TypeOfJornada.Night }
            };

            foreach (var item in Schoolx.ListOfAllCourses)
            {
                item.Students = LoadStudents( RandomIntegerGenerator(3, 9) );
            }
        }

        private void LoadEvaluations()
        {
            foreach (var courseItem in Schoolx.ListOfAllCourses)
            {
                foreach (var subjectItem in courseItem.Subjects)
                {
                    foreach (var studentItem in courseItem.Students)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var evalTemp = new Evaluation
                            {
                                Subject = subjectItem,
                                Student = studentItem,
                                Name = $"Eval-{i + 1}-{subjectItem.Name}",
                                Grade = RandomFloatGenerator()
                            };
                            studentItem.Evaluations.Add(evalTemp);
                        }
                    }
                }
            }
        }

        private void LoadSubjects()
        {
            //throw new NotImplementedException();

            foreach (var courseItem in Schoolx.ListOfAllCourses)
            {
                var list1 = new List<Subject>()
                {
                    new Subject{Name = "Math Sci"},
                    new Subject{Name = "Biology Schi"},
                    new Subject{Name = "Chemical Sci"},
                    new Subject{Name = "Physics Sci"}
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
                              select new Student { Name = $"{n1} {n2} {ln1}" };

            return listRandom1.OrderBy((item) => item.UniqueId ).Take(numberOfStudents).ToList();
        }

        public static int RandomIntegerGenerator(int limitLow, int limitHigh)
        {
            Random rand1 = new Random();
            int randomNumber1 = rand1.Next(limitLow, limitHigh);
            return randomNumber1;
        }

        public static float RandomFloatGenerator()
        {
            Random randFloat = new Random();
            float randomFloat1 = (float)Math.Round( ( 5 * randFloat.NextDouble() ), 2);
            return randomFloat1;
        }

    }
}
