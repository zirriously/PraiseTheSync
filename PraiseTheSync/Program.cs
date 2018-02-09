using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace PraiseTheSync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching saves...");

            // Load paths from ..\paths.txt
            List<string> paths = new List<string>();
            string backupLoc = String.Empty;

            string[] lines = File.ReadAllLines(@"C:\Repos\Projects\PraiseTheSync\PraiseTheSync\Paths.txt");

            foreach (var value in lines)
            {
                if (value.StartsWith("+"))
                {
                    string temp = value.Remove(0, 1);
                    paths.Add(temp);
                    Console.WriteLine($"Added {temp}");
                }
                else if (value.StartsWith("."))
                {
                    backupLoc = value.Remove(0, 1);
                    Console.WriteLine($"Backup folder located at {backupLoc}\n");
                }
                else
                {
                    if (!value.StartsWith("/"))
                        Console.WriteLine("Invalid path | " + value);
                }
            }
            
            UserInput();

            var saveFiles = new SaveFiles(paths, backupLoc);
            saveFiles.Save();

            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine($"Exiting in {i} seconds...");
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }

            Console.ReadKey();
        }

        private static void UserInput()
        {
            while (true)
            {
                Console.WriteLine($"\nWould you like to backup these folders? Y/N");
                ConsoleKeyInfo ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.N)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("Exiting in 1 second...");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(0);
                }
                else if (ckey.Key == ConsoleKey.Y)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("Saving folders...");
                }
                else
                {
                    continue;
                }
                break;
            }
        }
    }
}
