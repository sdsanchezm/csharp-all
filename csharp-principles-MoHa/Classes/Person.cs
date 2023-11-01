// See https://aka.ms/new-console-template for more information

namespace Classes
{
    public class Person
    {
        public string FirstName;
        public string LastName;

        public void Introduce()
        {
            Console.WriteLine("Mein name ist " + FirstName + " " + LastName);
        }
    }
}