using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class School: SchoolBaseClass
    {
        // These props are inherited from SchoolBaseClass: 
        //public string UniqueId { get; set; } = Guid.NewGuid().ToString();
        //public string Name
        //{
        //    get { return "Copy: " + Name; }
        //    set { Name = value.ToUpper(); }
        //}

        public int YearOfCreation { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public TypesOfSchool TypeOfSchool { get; set; }

        public List<Course> ListOfAllCourses { get; set; }

        public School(string name, int year, string city)
        {
            this.Name = name;
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
            return $"Name: \"{Name}\", \nType of School: {TypeOfSchool} \nCountry: {Country} \nCity: {City}";
        }

    }
}
