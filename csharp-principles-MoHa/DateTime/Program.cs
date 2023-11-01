//using System;

namespace Datetime1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateTime1 = new DateTime(2015, 1, 1);
            var now1 = DateTime.Now;
            var today1= DateTime.Today;
            Console.WriteLine("DateTime.Now: {0}", now1);
            Console.WriteLine("day: {0}", now1.Day);
            Console.WriteLine("DateTime.Today: {0}", today1);
            Console.WriteLine("year: {0}", today1.Year);
        
            var tomorrow1 = now1.AddDays(1);
            var yesterday1 = now1.AddDays(-1);

            Console.WriteLine(tomorrow1.ToLongDateString() );
            Console.WriteLine(tomorrow1.ToShortDateString() );
            Console.WriteLine(tomorrow1.ToLongTimeString() );
            Console.WriteLine(tomorrow1.ToShortTimeString() );
            Console.WriteLine(tomorrow1.ToString("yyyy-MM-dd HH:mm") );

            // documentation at: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings

            Console.WriteLine("======================TimeSpan");

            var timeSpan1 = new TimeSpan(1, 2, 3); // 1 hour 2 min 3 secs
            var timeSpan2 = new TimeSpan(1, 0, 0);
            var timeSpan3 = new TimeSpan(1, 2, 3);
            var timeSpan4 = TimeSpan.FromHours(1);

            var start1 = DateTime.Now;
            var end1 = DateTime.Now.AddMinutes(2);
            var duration1 = end1 - start1;

            Console.WriteLine("duration " + duration1);
            Console.WriteLine("duration " + duration1.Minutes + " mins");

            // properties

            Console.WriteLine("total Minutes: " + timeSpan1.TotalMinutes);
            Console.WriteLine("total Seconds: " + timeSpan1.TotalSeconds);
            Console.WriteLine("total miliSeconds: " + timeSpan1.TotalMilliseconds);

            // Add 
            Console.WriteLine("======================TimeSpan - Add");
            Console.WriteLine("original: " + timeSpan1);
            Console.WriteLine("plus: " + TimeSpan.FromMinutes(2));
            Console.WriteLine("add: " + timeSpan1.Add(TimeSpan.FromMinutes(2)));

            // substract
            Console.WriteLine("======================TimeSpan - Substract");
            Console.WriteLine("original: " + timeSpan1);
            Console.WriteLine("minus: " + TimeSpan.FromMinutes(2));
            Console.WriteLine("substracted: " + timeSpan1.Subtract(TimeSpan.FromMinutes(2)));

            // to sing
            Console.WriteLine("toString" + timeSpan1.ToString());

            // parse
            Console.WriteLine("toString" + TimeSpan.Parse("01:02:03"));


        }
    }
}