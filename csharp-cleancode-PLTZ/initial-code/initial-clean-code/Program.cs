using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TL { get; set; }

        static void Main(string[] args)
        {
            TL = new List<string>();
            int variable = 0;
            do
            {
                variable = ShowMainMenu();
                if (variable == 1)
                {
                    ShowMenuAdd();
                }
                else if (variable == 2)
                {
                    ShowSecondMenu();
                }
                else if (variable == 3)
                {
                    ShowThirdMenu();
                }
            } while (variable != 4);
        }

        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option selected by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("---------------Task-List-Console-App-------------------------");
            Console.WriteLine("Enter a number to select an option: ");
            Console.WriteLine("1. New Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. List Tasks");
            Console.WriteLine("4. Exit");

            // Read option
            string option = Console.ReadLine();
            return Convert.ToInt32(option);
        }

        public static void ShowSecondMenu()
        {
            try
            {
                Console.WriteLine("Enter the Task number to remove: ");
                // Show current taks
                for (int i = 0; i < TL.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + TL[i]);
                }
                Console.WriteLine("----------------------------------------");

                string record = Console.ReadLine();
                // Remove one task
                int indexToRemove = Convert.ToInt32(record) - 1;
                if (indexToRemove > -1)
                {
                    if (TL.Count > 0)
                    {
                        string task = TL[indexToRemove];
                        TL.RemoveAt(indexToRemove);
                        Console.WriteLine("Task " + task + " deleted");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Enter the name of the Task: ");
                string taskName = Console.ReadLine();
                TL.Add(taskName);
                Console.WriteLine("Task Registered----");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowThirdMenu()
        {
            if (TL == null || TL.Count == 0)
            {
                Console.WriteLine("No-pending-Tasks----");
            }
            else
            {
                Console.WriteLine("-Lists-Of-Tasks-Start--------------------------");
                for (int i = 0; i < TL.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + TL[i]);
                }
                Console.WriteLine("-Lists-Of-Tasks-End----------------------------");
            }
        }
    }
}
