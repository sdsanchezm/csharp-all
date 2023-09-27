

namespace linqAll
{
        class LinqQueries2
    {
        static void Main()
        {

            Dictionary<string, int> k1 = new Dictionary<string, int>();

            DictionaryTest d1 = new DictionaryTest();
            
            // sum
            var num1 = d1.UserList.Sum(p => p.Age);

            // count
            var num2 = d1.UserList.Count();

            // average
            var num3 = (float)num1/num2;

            var l1 = d1.UserList
                .Where(p => p.Age > 0)
                .GroupBy(p => p.CarType);


            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(l1);

            foreach (var x in l1)
            {
                Console.WriteLine(x.Key);
                foreach (var y in x)
                {
                    Console.WriteLine($"{y.Name} - {y.Age}");
                }
            };

            var t2 = d1.UserList
                .GroupBy(p => p.CarType)
                .ToDictionary(
                    p => p.Key.ToString(),
                    p => p.Count()
                );

            t2.ToList().ForEach(p =>
            {
            Console.WriteLine($"{p.Key} - {p.Value}");
            });


            var t3 = d1.UserList
                .GroupBy(p => p.CarType)
                .ToDictionary(
                    p => p.Key.ToString(),
                    p => p.Sum(p => p.Age)
                );

            t3.ToList().ForEach(p =>
            {
                Console.WriteLine($"{p.Key} - {p.Value}");
            });


        }
    }
    public class User
    {
        public string Name { get; set; }
        public string CarType { get; set; }
        public int Age { get; set; }
    }

    public class DictionaryTest
    {
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        public List<User> UserList = new List<User>();

        public DictionaryTest()
        {
            //dict1.Add("jamecho", 21);
            //dict1["tiche"] = 42;
            //dict1.Add("amparo", 63);
            //dict1.Add("obama", 84);

            UserList.Add(new User() { Name = "Sap", Age = 3, CarType = "car1" });
            UserList.Add(new User() { Name = "Bur", Age = 8, CarType = "car1" });
            UserList.Add(new User() { Name = "Ran", Age = 6, CarType = "car1" });
            UserList.Add(new User() { Name = "Per", Age = 4, CarType = "car2" });
            UserList.Add(new User() { Name = "Con", Age = 2, CarType = "car2" });
        }
    }

}