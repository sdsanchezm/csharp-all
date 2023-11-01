

namespace test1
{
    class Program
    {
        static void Main()
        {
            Dog myDog = new Dog("Buddy", "Golden Retriever");

            Console.WriteLine($"Name: {myDog.Name}");
            Console.WriteLine($"Breed: {myDog.Breed}");

            myDog.Eat();
            myDog.Bark();
        }
    }
}