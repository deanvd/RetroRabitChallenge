using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestApplication
{
    class Program
    {
       
        static Random _rabitran = new Random();

       

        static void Main(string[] args)
        {
            List<string> RetroDict = new List<string>();
            Random randomchar = new Random();

            var Alphabet = new[]
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
                "V", "W", "X", "Y", "Z"
            };


            //Lets Cleanup
            if (System.IO.File.Exists(@"RetroRabitDictResult.txt"))
                System.IO.File.Delete(@"RetroRabitDictResult.txt");


            //shuffel alphabet and generate string for csv 
            for (var x = 0; x < 50; x++)
            {
                var randomSelection = (from c in Alphabet orderby randomchar.Next() select c).Take(5);
                var DictEntryList = randomSelection.ToList();
                RetroDict.Add(DictEntryList[0] + DictEntryList[1] + DictEntryList[2] + DictEntryList[3] +
                              DictEntryList[4]);

            }
   
            //combine and format for CSV from alphabet strings
            var csv = new StringBuilder();
            foreach (var VARIABLE in RetroDict.Distinct())
            {
                var Record = VARIABLE.ToString();
                var delimiter = ",";
                var NewRecord = string.Format("{0}", Record);
                csv.AppendLine(string.Concat(NewRecord, delimiter));
                Console.WriteLine(Record);

            }

            File.WriteAllText(@"RetroRabitDictResult.txt", csv.ToString().Substring(0, csv.Length - 3));

            Console.WriteLine("Values in the txt file generater......\n\n\n");

            Console.WriteLine("Retro Rabit File Created......\n\n");

            Console.WriteLine(SearchFile());
            Console.ReadLine();





        }

        public static string SearchFile()
        {
            Console.Write("Enter Keyword: ");
            var Search = Console.ReadLine() ?? "";
            var find = false;
            using (var sr = new StreamReader(@"RetroRabitDictResult.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Length == 6)
                    {
                         find = string.Equals(line.Substring(0, line.Length - 1), Search.ToUpper());
                    }
                    else
                    {
                        find = string.Equals(line, Search.ToUpper());
                    }
                   

                    if (find)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        return "\n\nString Found!!   :   " + line.Substring(0, line.Length - 1) + "\n\n\nDone ! Press any key to exit.";
                       
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "String Not Found" + "\n\n\nDone ! Press any key to exit.";
            ;
        }
    }


}


    
