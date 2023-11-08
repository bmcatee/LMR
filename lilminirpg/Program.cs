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

        public static void PrintLists()
        {
            for (int i = 0; i < DataLists.EnemiesList.GetLength(0); ++i)
            {
                for (int j = 0; j < DataLists.EnemiesList.GetLength(1); ++j)
                {
                    Console.WriteLine($"{DataLists.EnemiesList[i, j]}");
                }
            }
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
