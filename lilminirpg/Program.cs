using lilminirpg;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace lilminirpg
{
    internal class Program
    { 
        public async static Task Main()
        {
            // Goto main menu
            using (var ctx = new PlayerMethods.PlayerContext())
            {
                //var playerone = ctx.Players.Single(b => b.CharacterKey == 1);
                if (ctx.Players.Any() == false)
                {
                    Console.WriteLine("Initializing database, please wait.");
                    SaveLoad.AddNewPlayerToDB();
                }
                await Menus.MenuGeneric("MenuMain");
            }
        }

        public async static Task PrintLists()
        {
            //for (int i = 0; i < DataLists.EnemiesList.GetLength(0); ++i)
            //{
            //    for (int j = 0; j < DataLists.EnemiesList.GetLength(1); ++j)
            //    {
            //        Console.Write($"{DataLists.EnemiesList[i, j]} - ");
            //    }
            //    Console.WriteLine("");
            //}
            //Console.WriteLine($"Press Enter to continue");
            //Console.ReadLine();
            //await Menus.TestMenu();
        }
        public static void PrintColorList()
        {
            ConsoleColor[] consoleColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Console.WriteLine("List of available " + "Console Colors:");

            for (int i = 0; i < consoleColors.Length; ++i)
            {
                Console.ForegroundColor = consoleColors[i];
                Console.WriteLine($"Hello, World: {consoleColors[i]}");
            }
            Console.WriteLine($"Press Enter to continue");
            Console.ReadLine();
            Menus.TestMenu();
        }
    }
}