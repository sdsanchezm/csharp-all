using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace techTest1
{
    class StringMethods2
    {
        string textResult { get; set; }
        private string _textInitial = "";
        public StringMethods2(string text1)
        {
            _textInitial = text1;
        }

        public StringMethods2() { }

        public void invertString1()
        {
            string res2 = "";

            for (int i = _textInitial.Length - 1; i >= 0; i--)
            {
                res2 += _textInitial[i];
            }

            Console.WriteLine(res2);
        }

        public void invertString2()
        {
            var text2 = _textInitial.ToCharArray();
            Array.Reverse(text2);
            string reversedString = new string(text2);
            Console.WriteLine(reversedString);
        }

        public void countCharacters1(char c)
        {
            int counter = 0;
            for (int i = 0; i < _textInitial.Length; i++)
            {
                if(_textInitial[i] == c)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        public void countCharacters2(char c)
        {
            int counter = 0;
            foreach (var item in _textInitial)
            {
                if (item == c)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        public void countCharacters3(char c)
        {
            int count = 0;

            count = _textInitial.Where(p => p == c).Count();

            Console.WriteLine(count);
        }

        public void hammingDistance1(string text1, string text2)
        {
            int counter = 0;

            for (int i = 0; i < text1.Length; i++)
            {
                if (text1[i] != text2[i])
                {
                    counter++;
                }
            }

            System.Console.WriteLine(counter);
        }

        public void counterWords1()
        {
            // var count = text1.Trim().Split().Count();
            int count2 = 0;
            var res1 = _textInitial.Trim().Split();
            foreach (var item in res1)
            {
                if ( item != "" )
                {
                    count2++;
                }
            }

            System.Console.WriteLine(count2);
        }

        public void  counterWords2()
        {
            // in this regex exp, + is 1 or more; * would be none or more
            var res1 = Regex.Replace(_textInitial, @"\s+", " ").Trim();
            var res2 = res1.Split();
            Console.WriteLine(res2.Count());
        }

        public void countNumbersInString1()
        {
            int count = 0;
            for (int i = 0; i < _textInitial.Length; i++)
            {
                if ( char.IsDigit(_textInitial[i]) )
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        public void countNumbersInString2()
        {
            string pattern1 = @"[0-9]";
            var regex1 = new Regex(pattern1);
            var count = regex1.Matches(_textInitial).Count();
            Console.WriteLine(count);
        }

        public void countLowerCaseLetters1()
        {
            string pattern1 = @"[a-z]";
            var regex1 = new Regex(pattern1);
            var count = regex1.Matches(_textInitial).Count();
            Console.WriteLine(count);
        }

        public void countUpperCaseLetters1()
        {
            string pattern1 = @"[A-Z]";
            var regex1 = new Regex(pattern1);
            var count = regex1.Matches(_textInitial).Count();
            Console.WriteLine(count);
        }

        public void countSymbols()
        {
            string pattern1 = @"[^A-Za-z0-9]";
            var regex1 = new Regex(pattern1);
            var count = regex1.Matches(_textInitial).Count();
            Console.WriteLine(count);
        }

    }
}
