﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> retroDict = new List<string>();
            Random randomchar = new Random();

            var alphabet = new[]
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
                var randomSelection = (from c in alphabet orderby randomchar.Next() select c).Take(5);
                var dictEntryList = randomSelection.ToList();
                retroDict.Add(dictEntryList[0] + dictEntryList[1] + dictEntryList[2] + dictEntryList[3] +
                              dictEntryList[4]);

            }
   
            //combine and format for CSV from alphabet strings
            var csv = new StringBuilder();
            foreach (var variable in retroDict.Distinct())
            {
                var record = variable.ToString();
                var delimiter = ",";
                var newRecord = string.Format("{0}", record);
                csv.AppendLine(string.Concat(newRecord, delimiter));
                Console.WriteLine(record);
            }
            //Write textFile
            File.WriteAllText(@"RetroRabitDictResult.txt", csv.ToString().Substring(0, csv.Length - 3));
            //info
            Console.WriteLine("Carrots(String) in the txt file generated......\n\n\n");
            Console.WriteLine("Retro Rabbit File Created......\n\n");

        
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press enter to open bucket of carrots....");
            Console.ForegroundColor = ConsoleColor.White;

      

            Console.ReadLine();

            //Open File in Notepad
            var OpenGeneratedDict = new ProcessStartInfo(@"RetroRabitDictResult.txt")
            {
                WindowStyle = ProcessWindowStyle.Maximized,
                Arguments = @"RetroRabitDictResult.txt"
            };

            Process.Start(OpenGeneratedDict);


            //Call Search Function
            Console.WriteLine(SearchFile());
            Console.ReadLine();





        }

        public static string SearchFile()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Use one of the Carrots(string) in the bucket and to throw it in the Rabbit Hole! \nLet's see if we can find the Rabbit !!! \n\n");
            Console.Write("Rabit Hole :  ");
            Console.ForegroundColor = ConsoleColor.White;
            var search = Console.ReadLine() ?? "";
            using (var sr = new StreamReader(@"RetroRabitDictResult.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var find = false;
                    if (line.Length == 6)
                    {
                         find = string.Equals(line.Substring(0, line.Length - 1), search.ToUpper());
                    }
                    else
                    {
                        find = string.Equals(line, search.ToUpper());
                    }
                   

                    if (find)
                    {
                        rabbitImage();
                        
                      
                        return "\n\nFound the Rabbit   :   " + line.Substring(0, line.Length - 1) + "\n\n\nDone !\nPress any key to exit.";
                       
                    }
                }
            }


            Console.ForegroundColor = ConsoleColor.Red;
            return "Can't find the Rabbit." + "\n\n\nDone !\nPress any key to exit.";
            ;
        }

        public static void rabbitImage()
        {



            string rabbit =


                @"  ** **" + "\n" +
                @" * *   **" + "\n" +
                @" **   **         ****" + "\n" +
                @" * *   **       **   ****" + "\n" +
                @" **  **       *   **   **" + "\n" +
                @" * *  *      *  **  ***  **" + "\n" +
                @"   **  *    *  **     **  *" + "\n" +
                @"   * * **  ** **        **" + "\n" +
                @"    **   **  **" + "\n" +
                @"   *           *" + "\n" +
                @"  *             *" + "\n" +
                @" *    0     0    *" + "\n" +
                @" *   /   @   \   *" + "\n" +
                @" *   \__/ \__/   *" + "\n" +
                @"   *     W     *" + "\n" +
                @"    * *     **" + "\n" +
                @"       *****" + "\n";
            
             Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(rabbit);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    }



    
