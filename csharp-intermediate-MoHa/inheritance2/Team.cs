

namespace test1
{

    class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
    }

    class Dog : Animal
    {
        public string Breed { get; set; }

        public Dog(string name, string breed) : base(name)
        {
            Breed = breed;
        }

        // this implementation is optional, is already in the parent class
        public new void Eat()
        {
            Console.WriteLine($"{Name} (a {Breed} dog) is eating dog food.");
        }

        public void Bark()
        {
            Console.WriteLine($"{Name} is barking.");
        }
    }

    

}