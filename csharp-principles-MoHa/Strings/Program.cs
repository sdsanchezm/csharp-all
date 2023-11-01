

using System.Text;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var string1 = "This Is a Nice Text";
            Console.WriteLine(string1.ToLower());

            var stringNumbers1 = "1234";
            int i = int.Parse(stringNumbers1);
            int j = Convert.ToInt32(stringNumbers1);

            // c or C => Curency
            // d or D => Decimal
            // e or E => Exponential
            // f or F => Fixed Point
            // x or X => Hexadecimal

            // Trim
            var name1 = " Jamecho Sanc ";
            Console.WriteLine("with no trim: '{0}'", name1);
            Console.WriteLine("trimmed named: '{0}'", name1.Trim());

            // toUpper
            Console.WriteLine("trimmed named: '{0}'", name1.ToUpper());

            // toLower
            Console.WriteLine("trimmed named: '{0}'", name1.ToLower());

            // split
            var newName = name1.Trim().Split(' ');
            Console.WriteLine("FirstName: '{0}'", newName[0]);
            Console.WriteLine("LastName: '{0}'", newName[1]);

            Console.WriteLine("first name: '{0}'", name1.Split(' ')[0]);
            Console.WriteLine("first name: '{0}'", name1.Split(' ')[1]);

            // splie another way
            var index = name1.Trim().IndexOf(' ');
            var firstName1 = name1.Trim().Substring(0, index);
            var lastName1 = name1.Trim().Substring(index + 1);
            Console.WriteLine("firstname1: '{0}'", firstName1);
            Console.WriteLine("lastname1: '{0}'", lastName1);

            // Replace
            Console.WriteLine(name1.Replace("Sanc", "Kraus"));

            // string validation
            if (String.IsNullOrEmpty(""))
            {
                Console.WriteLine("Invalid here! - empty");
            }

            if (String.IsNullOrEmpty(" ".Trim()))
            {
                Console.WriteLine("Invalid here! - empty");
            }

            if (String.IsNullOrEmpty(null))
            {
                Console.WriteLine("Invalid here! - null");
            }

            if (String.IsNullOrWhiteSpace(" "))
            {
                Console.WriteLine("Invalid here!");
            }

            // Formatting

            var price = "23";
            var age = Convert.ToByte(price);
            Console.WriteLine("age: " + age);

            float price2 = 24.55f;
            //Console.WriteLine("price: {0}", price2.ToString("B"));
            //Console.WriteLine("price: {0}", price2.ToString("b"));
            Console.WriteLine("price: {0}", price2.ToString("C"));
            Console.WriteLine("price: {0}", price2.ToString("C0"));
            Console.WriteLine("price: {0}", price2.ToString("E"));
            Console.WriteLine("price: {0}", price2.ToString("E2"));

            // Documentation at https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings


            // Exercise: summarizing text

            var sentence1 = "this is going to be a really really really really really really really long text.";
            const int maxLenSentence = 35;

            var summarizedText1 = SummarizeText(sentence1);
            Console.WriteLine(summarizedText1);

            var summarizedText2 = SummarizeText(sentence1, maxLenSentence);
            Console.WriteLine(summarizedText2);

            // String Builder ========================
            Console.WriteLine("=========================String Builder");
            var builder1 = new StringBuilder();
            builder1.Append('-', 10);
            builder1.AppendLine();
            builder1.Append("Title Here");
            builder1.AppendLine();
            builder1.Append('-', 10);
            builder1.Replace('-', '+');
            builder1.Remove(0, 5);
            builder1.Insert(0, new String('=', 10));

            Console.WriteLine(builder1);

            var builder2 = new StringBuilder("Another String here");

            builder2
                .AppendLine()
                .Append('-', 10)
                .Replace('-', '_')
                .AppendLine();

            // no methods for search or string manipul;ation in string builder

            Console.WriteLine(builder2);
            Console.WriteLine("first character: {0}", builder2[0]);
            Console.WriteLine("====================================");
        }

        static string SummarizeText(string text, int maxLen = 20)
        {
            if (text.Length < maxLen)
            {
                return text;
            }

            var numberOfChars = 0;
            var summary1 = new List<string>();

            var text2 = text.Split(' ');

            foreach (string word in text2) 
            {
                //// first way to do it
                //numberOfChars += word.Length + 1;
                //if (numberOfChars < maxLen)
                //{
                //    summary1.Add(word);
                //}
                //else
                //{
                //    break;
                //}

                //Another simpler way to do it:
                summary1.Add(word);

               numberOfChars += word.Length + 1;
                if (numberOfChars > maxLen)
                    break;
            }

            return String.Join(" ", summary1) + "...";

        }
    }
}