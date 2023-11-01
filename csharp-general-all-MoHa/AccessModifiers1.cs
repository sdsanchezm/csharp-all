
using System;

namespace AccessModifiers
{
    public class User
    {
        // private, 
        private DateTime _birthdate;

        // Setter here
        public void SetBirthdate(DateTime birthdate)
        {
            _birthdate = birthdate;
        }

        // Getter here
        public DateTime GetBirthdate()
        {
            return _birthdate;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // instantiating a new object User
            var user = new User();
            // including a new DateTime object
            user.SetBirthdate(new DateTime(2000, 11, 11));
            // using the getter to get information 
            Console.WriteLine(user.GetBirthdate());

        }
    }
}
