using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdminProject1.Entities
{
    class School
    {
        // this is the ATTRIBUTE name
        string name;

        // this is the PROPERTY that enables the getters and setters
        public string Name
        { 
            get { return "Copy: " + name; }
            set { name = value.ToUpper();  }
        }

        public int YearOfCreation { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        // This is an option but amny text can be used here so, there is another way to do it
        // in order to avoid errors, the enumerators. 
        public TypesOfSchool TypeOfSchool { get; set; }


        // this is the constructor: (one of the ways to write it/define the constructor
        //public School(string name, int year)
        //{
        //    this.name = name;
        //    this.YearOfCreation = year;
        //}


        // another way to write the constructor
        // this is made by using 'igualacion por tuples' 
        public School(string name, int year) => (Name, YearOfCreation) = (name, year);

        // Overriding a method, in this case the ToString Method: 
        public override string ToString()
        {
            return $"Name: {name}, \nType of School: {TypeOfSchool} \nCountry: {Country} \nCity: {City}";
        }


    }
}
