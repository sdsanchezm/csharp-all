using System;
using SchoolAdminProject1.Entities;

namespace SchoolAdminProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Kraus School", 2021);
            school.Country = "Germany";
            school.City = "Berlin";
            school.TypeOfSchool = TypesOfSchool.Secondary;
            Console.WriteLine(school);

            
        }
    }
}
