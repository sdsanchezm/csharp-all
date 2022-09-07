using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class School
    {
        public string SchoolId { get; set; } = Guid.NewGuid().ToString();

        string name;

        public string Name
        {
            get { return "Copy: " + name; }
            set { name = value.ToUpper(); }
        }

        public int YearOfCreation { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public TypesOfSchool TypeOfSchool { get; set; }

        public List<Course> ListOfAllCourses { get; set; }

        public School(string name, int year, string city)
        {
            this.name = name;
            this.YearOfCreation = year;
        }

        public School(string name, int year) => (Name, YearOfCreation) = (name, year);

        public School(string name, int year, TypesOfSchool type, string country = "", string city = "")
        {
            (Name, YearOfCreation) = (name, year);
            Country = country;
            City = city;
        }

        public override string ToString()
        {
            return $"Name: \"{name}\", \nType of School: {TypeOfSchool} \nCountry: {Country} \nCity: {City}";
        }

    }
}
