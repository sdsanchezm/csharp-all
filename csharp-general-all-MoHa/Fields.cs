
using System;

namespace Fields
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(1);
            client.Orders.Add(new Order());
            client.Orders.Add(new Order());

            client.Promote();

            Console.WriteLine(client.Orders.Count);

        }
    }
}

namespace Fields
{
    public class Client
    {
        public int Id;
        public string Name;
        // this is another way of initializing the class (no constructor):
        // this will initialize with an empty list
            // List<Order> Orders = new List<Order>();
        // the folowing will only initialize once: (because is readonly)
            // public readonly List<Order> Orders = new List<Order>();
        // the advantage of initializing here is that it will not be in the constructor
        public readonly List<Order> Orders = new List<Order>();

        // Always have to make sure the main constructor is called first
        // some fields can be initialized in the constructor some others not, it depends on the way of coding
        public Client(int id)
        {
            this.Id = id;
        }

        public Client(int id, string name)
            : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            // ....
        }
    }
}

namespace Fields
{
    public class Order
    {
        
    }
}
