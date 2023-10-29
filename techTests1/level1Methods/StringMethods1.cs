using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace techTest1
{
    class StringMethods1
    {
        string textResult { get; set; }
        string textInitial { get; set; }
        public StringMethods1(string text1)
        {
            textInitial = text1;
        }

        public StringMethods1() { }

        public string invertString1(string text1)
        {
            string res2 = "";

            for (int i = text1.Length - 1; i >= 0; i--)
            {
                res2 += text1[i];
            }
            return res2;
        }

        public string invertString2(string text1)
        {
            var text2 = text1.ToCharArray();
            Array.Reverse(text2);
            string reversedString = new string(text2);
            Console.WriteLine(reversedString);
            return reversedString;
        }

        public int countCharacters1(string text1, char c)
        {
            int counter = 0;
            for (int i = 0; i < text1.Length; i++)
            {
                if(text1[i] == c)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int countCharacters2(string text1, char c)
        {
            int counter = 0;
            foreach (var item in text1)
            {
                if (item == c)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int countCharacters3(string text1, char c)
        {
            int count = 0;

            count = text1.Where(p => p == c).Count();

            return count;
        }

        public int hammingDistance1(string text1, string text2)
        {
            int counter = 0;

            for (int i = 0; i < text1.Length; i++)
            {
                if (text1[i] != text2[i])
                {
                    counter++;
                }
            }

            return counter;
        }

        public int counterWords1(string text1)
        {
            // var count = text1.Trim().Split().Count();
            int count2 = 0;
            var res1 = text1.Trim().Split();
            foreach (var item in res1)
            {
                if ( item != "" )
                {
                    count2++;
                }
            }

            return count2;
        }

        public int counterWords2(string text1)
        {
            // in this regex exp, + is 1 or more; * would be none or more
            var res1 = Regex.Replace(text1, @"\s+", " ").Trim();
            var res2 = res1.Split();
            return res2.Count();
        }

        public int countNumbersInString1(string text1)
        {
            int count = 0;
            for (int i = 0; i < text1.Length; i++)
            {
                if ( char.IsDigit(text1[i]) )
                {
                    count++;
                }
                
            }
            return count;
        }

        public int countNumbersInString2(string text1)
        {
            string pattern1 = @"[0-9]";
            var regex1 = new Regex(pattern1);
            var count = regex1.Matches(text1).Count();
            return count;
        }

        public int countLowerCaseLetters1(string text1)
        {
            string pattern1 = @"[a-z]";
            var regex1 = new Regex(pattern1);
            var count = regex1.Matches(text1).Count();
            return count;
        }

        public int countUpperCaseLetters1(string text1)
        {
            string pattern1 = @"[A-Z]";
            var regex1 = new Regex(pattern1);
            var count = regex1.Matches(text1).Count();
            return count;
        }

        public int countSymbols(string text1)
        {
            string pattern1 = @"[^A-Za-z0-9]";
            var regex1 = new Regex(pattern1);
            var count = regex1.Matches(text1).Count();
            return count;
        }

    }
}
