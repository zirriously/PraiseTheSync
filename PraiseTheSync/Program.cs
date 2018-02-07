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

            // Load paths from json
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
                else if (value.StartsWith("-"))
                {
                    backupLoc = value.Remove(0, 1);
                }
                else
                {
                    Console.WriteLine("Invalid path | " + value);
                }
            }
            Console.WriteLine($"Finished. Saving to {backupLoc}");

            var saveFiles = new SaveFiles(paths, backupLoc);
            saveFiles.Save();

            Console.ReadKey();

        }
    }
}
