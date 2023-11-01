using System.IO.Pipes;

namespace TypesValueAndReference
{
    class Person
    {
        public int Age;
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var a = 12;
            var b = a;
            b++;
            // a and b are independent, because they are different positions in memory, point to different mem address
            // this is different from the logic of classes, classes are reference, so they point to the same memory address
            Console.WriteLine("a: {0} - b: {1}", a, b); // a: 12 - b: 13 


            var array1 = new int[3]{ 2, 4, 5};

            var array2 = array1;

            array2[0] = 99;

            // here, array1 is also modified because they point ot the same memory
            Console.WriteLine("first element: {0}", array1[0]); // 99

            // Another example
            var number = 1;
            Increment1(number);
            // here number is not changing because is value type
            Console.WriteLine("number: {0}", number); // number: 1

            var person1 = new Person();
            person1.Age = 40;
            MakeOld1(person1);
            // here age value is chaning because is by reference
            Console.WriteLine("person1.age: {0}", person1.Age); // person1.Age: 50

        }

        public static void Increment1(int number)
        {
            number += 10;
        }

        public static void MakeOld1(Person person)
        {
            person.Age += 10;
        }
    }
}