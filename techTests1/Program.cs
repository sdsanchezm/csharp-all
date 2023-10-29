using System;

namespace techTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting app");
            var x1 = new StringMethods1();
            var y = x1.invertString1("asd");
            Console.WriteLine(y);

            x1.invertString2("qwe");

            string s1 = "thisisarandomcharactersStringthat123x1345wantToUse";
            string s2 = "phisisarandomcharactersStringthat123x1345wantToUpp";
            string s3 = "phisisarandomcharactersStringthat123x1345wantToUpp#@";

            var total1 = x1.countCharacters1("thisisarandomcharactersStringthat123I345wantToUse", 'c');
            Console.WriteLine(total1);

            var total2 = x1.countCharacters1("thisisarandomcharactersStringthat123I345wantToUse", 'c');
            Console.WriteLine(total2);

            var total3 = x1.countCharacters1("thisisarandomcharactersStringthat123I345wantToUse", 'c');
            Console.WriteLine(total3);

            var distance1 = x1.hammingDistance1(s1, s2);
            Console.WriteLine(distance1);

            var numberOfwords1 = x1.counterWords1("this  is  a test    ");
            Console.WriteLine(numberOfwords1);

            var numberOfwords2 = x1.counterWords2("this  is  a test    ");
            Console.WriteLine(numberOfwords2);

            var numberOfNumbers1 = x1.countNumbersInString1("123qweasdzx1c1223qweasdzx1c");
            System.Console.WriteLine(numberOfNumbers1);

            var numberOfNumbers2 = x1.countNumbersInString2("123qweasdzx1c123eqweasdzx1c");
            System.Console.WriteLine(numberOfNumbers2);

            var countLowerCase = x1.countLowerCaseLetters1(s1);
            System.Console.WriteLine(countLowerCase);

            var countUpperCase = x1.countUpperCaseLetters1(s1);
            System.Console.WriteLine(countUpperCase);

            var countSymbols = x1.countSymbols(s3);
            Console.WriteLine(countSymbols);

            var x2 = new StringMethods2(s3);
            x2.invertString1();
            x2.invertString2();
            x2.countCharacters1('c');
            x2.countCharacters2('c');
            x2.countCharacters3('c');
            x2.counterWords1();
            x2.counterWords2();
            x2.countNumbersInString1();
            x2.countNumbersInString2();
            x2.countLowerCaseLetters1();
            x2.countUpperCaseLetters1();
            x2.countSymbols();

        }
    }
}

