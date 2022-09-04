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

        // this is the constructor: 
        //public School(string name, int year)
        //{
        //    this.name = name;
        //    this.YearOfCreation = year;
        //}

        // another way to write the constructor
        // this is made by using 'igualacion por tuples' 
        public School(string name, int year) => (Name, YearOfCreation) = (name, year);

    }
}
