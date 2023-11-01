using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuOption = 0;
            do
            {
                menuOption = ShowMainMenu();

                if ((MenuOptions)menuOption == MenuOptions.AddOption)
                {
                    ShowMenuAdd();
                }
                else if ((MenuOptions)menuOption == MenuOptions.RemoveOption)
                {
                    ShowMenuRemove();
                }
                else if ((MenuOptions)menuOption == MenuOptions.ListOption)
                {
                    ShowListTasks();
                }
            } while ((MenuOptions)menuOption != MenuOptions.ExitOption);
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

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Enter the Task number to remove: ");

                // show pending tasks
                PrintListOfPendingTasks();

                string taskOptionToRemove = Console.ReadLine();
                // Remove one task
                int indexToRemove = Convert.ToInt32(taskOptionToRemove) - 1;

                if (indexToRemove < 0 && indexToRemove > (TaskList.Count - 1) )
                {
                    Console.WriteLine("Invalid option...");
                }
                else
                {
                    if (indexToRemove >  -1 && TaskList.Count > 0) // validates if tasks are more than 0 and if selected option is positive
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Task '" + task + "' deleted");
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occurred when deleting tasks: ", ex);
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Enter the name of the Task: ");
                string newTaskName = Console.ReadLine();
                TaskList.Add(newTaskName);
                Console.WriteLine("Task Registered----");
            }
            catch (Exception)
            {
                Console.WriteLine("error occurred");
            }
        }

        public static void ShowListTasks()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No-Tasks----");
            }
            else
            {
                Console.WriteLine("-Lists-Of-Tasks-Start--------------------------");

                var listCount = 1;
                TaskList.ForEach(x => Console.WriteLine($"{listCount++}-- {x}"));

                Console.WriteLine("-Lists-Of-Tasks-End----------------------------");
            }
        }

        public static void PrintListOfPendingTasks()
        {
            // Show current taks
            Console.WriteLine("--TasksList-Start-----------------------");
            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + TaskList[i]);
            }
            Console.WriteLine("--TasksList-End-------------------------");
        }

        public enum MenuOptions
        {
            AddOption = 1,
            RemoveOption = 2,
            ListOption = 3,
            ExitOption = 4
        }
    }
}
