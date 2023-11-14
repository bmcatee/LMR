using lilminirpg;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace lilminirpg
{
    internal class Program
    {
        public static void Main()
        {
            // Goto main menu
            Menus.MenuGeneric("MenuMain");
        }

        //public static Player NewPlayer()
        //{
        //    Player newPlayer = new Player();
        //    return newPlayer;
        //}

        //public static void PrintPlayer()
        //{
            
        //}

        public static void PrintLists()
        {
            for (int i = 0; i < DataLists.EnemiesList.GetLength(0); ++i)
            {
                for (int j = 0; j < DataLists.EnemiesList.GetLength(1); ++j)
                {
                    Console.Write($"{DataLists.EnemiesList[i, j]} - ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine($"Press Enter to continue");
            Console.ReadLine();
            Menus.TestMenu();
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



// TESTS

// Console.WriteLine($"Doop!");
// Console.ReadLine();
// Console.WriteLine($"Doop! {characterCreation} + {characterCreationStage}");
// Console.WriteLine($"local menutracker = {menutracker}");
// Console.WriteLine($"curL: {Console.CursorLeft}, curT: {Console.CursorTop}");
// Console.WriteLine($"UI.CursorOffset {UI.CursorOffset} | UI.MenuTracker {UI.MenuTracker} | UI.SelectedOption {UI.SelectedOption} | UI.MenuInput {UI.MenuInput} | UI.MenuLength {UI.MenuLength}");
