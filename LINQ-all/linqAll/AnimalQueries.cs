using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace linqAll
{
    public class AnimalQueries
    {

        private List<Animal> animals = new List<Animal>();

        public AnimalQueries()
        {
            animals.Add(new Animal() { Name = "Hormiga", Color = "Red" });
            animals.Add(new Animal() { Name = "Lobo", Color = "Grey" });
            animals.Add(new Animal() { Name = "Lobo Feroz", Color = "Black" });
            animals.Add(new Animal() { Name = "Elefante", Color = "Grey" });
            animals.Add(new Animal() { Name = "Pantegra", Color = "Black" });
            animals.Add(new Animal() { Name = "Gato", Color = "Black" });
            animals.Add(new Animal() { Name = "Iguana", Color = "Green" });
            animals.Add(new Animal() { Name = "Sapo", Color = "Green" });
            animals.Add(new Animal() { Name = "Camaleon", Color = "Green" });
            animals.Add(new Animal() { Name = "Gallina", Color = "White" });

            
        }

        public void PrintAllAnimals()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} - {animal.Color}");
            }
        }

        public static void PrintAnimals(List<Animal> listAnimal)
        {
            foreach(var animal in listAnimal)
            {
                Console.WriteLine($"{animal.Name} - {animal.Color}");
            }
        }

        public void LobosAll()
        {
            var animalsLocal = animals.Where(item => item.Name.Contains("Lobo"));

            foreach(var animalItem in animalsLocal)
            {
                Console.WriteLine($"Result: {animalItem.Name} - {animalItem.Color} ");
            }
        }

        public void FilterAnimalQuest1()
        {
            List<string> vowels = new List<string>() { "a", "e", "i", "o", "u" };
            var animalsLocal = animals.Where(item => vowels.Any(vowel => item.Name.ToLower().StartsWith(vowel.ToString() ) ) && item.Color.ToLower() == "green");

            foreach (var animalItem in animalsLocal)
            {
                Console.WriteLine($"Result: {animalItem.Name} - {animalItem.Color} ");
            }
        }

        public void FilterAnimalQuest2()
        {
            List<string> vowels = new List<string>() { "a", "e", "i", "o", "u" };

            var animalsLocal = from a in animals
                               where a.Color.ToLower() == "green" && vowels.Any(vowel => a.Name.ToLower().StartsWith(vowel))
                               select a;

            foreach (var animalItem in animalsLocal)
            {
                Console.WriteLine($"Result: {animalItem.Name} - {animalItem.Color} ");
            }
        }

        public void OrderAnimalByName1()
        {
            var animalsLocal = animals.OrderBy(p => p.Name);

            foreach (var animalItem in animalsLocal)
            {
                Console.WriteLine($"Result: {animalItem.Name} - {animalItem.Color} ");
            }
        }

        public void OrderAnimalByName2()
        {
            var animalsLocal = from animal in animals
                               orderby animal.Name ascending
                               select animal;

            foreach (var animalItem in animalsLocal)
            {
                Console.WriteLine($"Result: {animalItem.Name} - {animalItem.Color} ");
            }
        }




    }

    public class Animal
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }

}


