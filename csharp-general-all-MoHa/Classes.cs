

using System;

namespace Classes
{
    public class Worker
    {
        // Property here
        public string Name;

        // method
        public void Introduce(string newWorker)
        {
            Console.WriteLine("Hallo {0}, Ich bin {1}", newWorker, Name);
        }

        // constructor created like this
        public static Worker Parse(string nameWorker)
        {
            var worker = new Worker();
            worker.Name = nameWorker;

            return worker;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // calling the cosntructor should be like this, because it was defined in the class
            var worker = Worker.Parse("Jamecho");
            // calling the method
            worker.Introduce("Tiche");
        }
    }
}
