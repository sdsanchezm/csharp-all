using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace testApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopWatch = new StopWatch();
            stopWatch.ShowMenu();
        }
    }

    public class StopWatch
    {
        public static DateTime TimeStopWatch;
        public static TimeSpan TimeStopWatchSpan;
        public void ShowMenu()
        {
            var optionValue = 0;

            do
            {
                optionValue = PrintMenu();

                switch (optionValue)
                {
                    case 1:
                        Console.WriteLine("Stopwatch started...");
                        Start();
                        break;

                    case 2:
                        Console.WriteLine("Stopwatch stopped...");
                        Stop();
                        break;

                    case 3:
                        Console.WriteLine("time now");
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("bye");
                        break;

                    default:
                        Console.WriteLine("bad request");
                        break;
                }

            } while (optionValue < 4);
        }

        public static int PrintMenu()
        {
            Console.WriteLine("===Stopwatch-Menu===");
            Console.WriteLine("1. start Stopwatch");
            Console.WriteLine("2. stop Stopwatch");
            Console.WriteLine("3. restart");
            Console.WriteLine("4. quit");

            var optionValue = Console.ReadLine();
            return Convert.ToInt32(optionValue);
        }

        public static void Start()
        {
            TimeStopWatch = DateTime.Now;
            Console.WriteLine($"Tiem started at {TimeStopWatch}");
        }

        public static void Stop()
        {
            TimeStopWatchSpan = DateTime.Now - TimeStopWatch;
            Console.WriteLine($"Time: {TimeStopWatchSpan}");
        }
    }
}