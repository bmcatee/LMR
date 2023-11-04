﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class SaveLoad
    {
        // Save game method
        public static void SaveGame(string charactername, string classname, string wornweapon, string wornaccessory)
        {
            string[] savedata = { $"{charactername}", $"{classname}", $"{wornweapon}", $"{wornaccessory}" };
            string folder = "C:\\Users\\bmcat\\Documents\\Projects\\lilminirpg\\";
            string filename = "lmr_save_001.txt";
            string savepath = folder + filename;
            using (StreamWriter outputFile = new StreamWriter(savepath))
                foreach (string s in savedata)
                {
                    outputFile.WriteLine(s);
                }
            Console.WriteLine("");
            Console.WriteLine("Your data has been saved! Press Enter to continue.");
            Console.ReadLine();
            UI.MenuInput = "";
        }

        [STAThread]
        public static void LoadGame()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\bmcat\\Documents\\Projects\\lilminirpg\\lmr_save_001.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine($"{line}");
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing Finally Block.");
            }

        }
    }
}
