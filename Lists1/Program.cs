using System;
using System.Collections.Generic;

namespace Lists1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lists");


            List<string> empanadaShopingList = new List<string>();

            empanadaShopingList.Add("Beef Empanada");
            empanadaShopingList.Add("Chicken Empanada");
            empanadaShopingList.Add("Veggies Empanada");
            empanadaShopingList.Add("4 apple soda");

            for (int empanada = 0; empanada < empanadaShopingList.Count; empanada++)
            {
                Console.WriteLine(empanadaShopingList[empanada]);
            }

            empanadaShopingList.RemoveAt(3);

            for (int empanada = 0; empanada < empanadaShopingList.Count; empanada++)
            {
                Console.WriteLine(empanadaShopingList[empanada]);
            }

            // Using ForEach
            empanadaShopingList.ForEach((x) => Console.WriteLine(x));

        }
    }
}
