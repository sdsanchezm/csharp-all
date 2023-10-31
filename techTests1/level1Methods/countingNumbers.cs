using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace techTest1
{
    class countingNumbers
    {
        int[] intInitial { get; set; }
        public countingNumbers(int[] intArray1)
        {
            intInitial = intArray1;
        }

        public void Count1()
        {
            int total1 = 0;
            int[] x1 = { 1, 2, 1, 2, 1, 3, 2 };

            int n = x1.Length;
            var temp1 = new List<int>();

            foreach (var item in x1)
            {
                if (temp1.Contains(item))
                {
                    Console.WriteLine("----");
                    continue;
                }
                else
                {
                    temp1.Add(item);
                    total1 += x1.Where(p => p == item).Count();
                }
            }

            Console.WriteLine(total1 / 2);
        }

        public int Count2()
        {
            int tempSock = 0;
            var temp1 = new List<int>();
            int[] array1 = { 1, 2, 1, 2, 1, 3, 2 };

            foreach (var item in array1)
            {
                if (temp1.Contains(item))
                {
                    continue;
                }
                else
                {
                    temp1.Add(item);
                    tempSock += array1.Where(p => p == item).Count() / 2;
                }
            }

            return tempSock;
        }

        public void Count3()
        {
            int[] x = { 1, 1, 1, 3, 2, 3, 1, 2 };

            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            foreach (int num in x)
            {
                if (numberCounts.ContainsKey(num))
                {
                    numberCounts[num]++;
                }
                else
                {
                    numberCounts[num] = 1;
                }
            }

            foreach (var item in numberCounts)
            {
                int number = item.Key;
                int count = item.Value;
                int pairs = count / 2;

                Console.WriteLine($"Num {number}: {pairs} ");
            }
        }

    }
}


