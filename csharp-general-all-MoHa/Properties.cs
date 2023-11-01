
using System;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiating a new User object with a date of birth of 11/11/2000
            var user = new User(new DateTime(2000, 11, 11));
            Console.WriteLine(user.Age);
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        // set is private here
        public DateTime Birthdate { get; private set; }

        public User(DateTime birthdate)
        {
            Birthdate = birthdate;
        }

        // Age field is declared here and the get property as well (adding some logic)
        public int Age
        {
            get
            {
                // calculating the number of years as of today
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;

                return years;
            }
        }
    }
}