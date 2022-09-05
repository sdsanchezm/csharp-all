using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdminProject1.Entities
{
    class School
    {
        // ATTRIBUTE name here, repeat: ATTRIBUTE 
        string name;

        // this PROPERTY enables getters and setters, just like this:
        public string Name
        { 
            get { return "Copy: " + name; }
            set { name = value.ToUpper();  }
        }

        // This is called "Auto-Implemented Property"
        public int YearOfCreation { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        // This is an option but any text can be used here (when it should be a few options) so, there is another way to do it
        // in order to avoid errors, the enumerators. 
        public TypesOfSchool TypeOfSchool { get; set; }

        // this is how the LsitOfAllCourses was defined before
        //public Course[] ListOfAllCourses { get; set; }

        // this is a List, generic of ListOfAllCourses - this is the collection
        public List<Course> ListOfAllCourses { get; set; }

        // Many constructors can be created, to use different parameters
        // this is the constructor: (one of the ways to write it/define the constructor
        public School(string name, int year, string city)
        {
            this.name = name;
            this.YearOfCreation = year;
        }

        // another way to write the constructor
        // this is made by using 'igualacion por tuples' 
        public School(string name, int year) => (Name, YearOfCreation) = (name, year);

        // Another constructor
        public School(string name, int year, TypesOfSchool type, string country="", string city="")
        {
            // country is an optional parameter
            (Name, YearOfCreation) = (name, year);
            Country = country;
            City = city;
        }

        // Overriding a method, in this case the ToString Method: 
        public override string ToString()
        {
            return $"Name: \"{name}\", \nType of School: {TypeOfSchool} \nCountry: {Country} \nCity: {City}";
        }




    }
}
