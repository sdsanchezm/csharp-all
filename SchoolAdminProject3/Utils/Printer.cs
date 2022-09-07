using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchool.Utils
{
    public static class Printer
    {

        public static void DrawLine(int size)
        {
            Console.WriteLine("".PadLeft(size, '='));
        }

        public static void DrawTitle (string title)
        {
            int x = title.Length + 4;
            DrawLine(x);
            Console.WriteLine($"| {title} |");
            DrawLine(x);
        }

        //public static void soundNice()
        //{
        //    var Solb = 185; var Lab = 207; var Sib = 233; var Reb = 277; var Mib = 311; var Fa = 349; var La2 = 329;
        //    var negra = 250;
        //    var blanca = negra * 2;
        //    var corchea = negra / 2;
        //    var dotblanca = blanca + negra;
        //    var dotnegra = negra + corchea;

        //    Console.Beep(Solb, dotnegra);
        //    Console.Beep(Fa, dotnegra);
        //    Console.Beep(Mib, dotnegra);
        //    Console.Beep(Mib, negra);
        //    Console.Beep(Reb, corchea);
        //    //Thread.Sleep(negra);
        //    Console.Beep(Mib, dotnegra);
        //    Console.Beep(Mib, negra);
        //    Console.Beep(Fa, corchea);
        //    Console.Beep(Mib, negra);
        //    Console.Beep(Reb, corchea);
        //    Console.Beep(Sib, negra);
        //    Console.Beep(Lab, corchea);
        //    //Thread.Sleep(negra);
        //    Console.Beep(Sib, dotnegra);
        //    Console.Beep(Fa, dotnegra);
        //    Console.Beep(Mib, dotnegra);
        //    Console.Beep(Mib, negra);
        //    Console.Beep(Reb, corchea);
        //    //Thread.Sleep(negra);
        //    Console.Beep(Mib, dotnegra);
        //    Console.Beep(Mib, negra);
        //    Console.Beep(Fa, corchea);
        //    Console.Beep(Mib, negra);
        //    Console.Beep(Reb, corchea);
        //    Console.Beep(Sib, negra);
        //    Console.Beep(Lab, corchea);
        //    //Thread.Sleep(negra);
        //    Console.Beep(Sib, dotnegra);
        //    Console.Beep(Reb, dotnegra);
        //    Console.Beep(La2, dotblanca);
        //}
    }
}
