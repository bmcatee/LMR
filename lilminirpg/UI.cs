using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal static class UI
    {
        public static char CursorSymbol = ' ';
        public static int SelectedOption { get; set; }
        public static string MenuInput { get; set; }
        public static string MenuTracker { get; set; }
        public static int MenuLength { get; set; }
        public static int consoleWindowTopRow = 0;
        public static int consoleWindowTopColumn = 0;
        public static int CurrentCursorRow;
        public static int CurrentCursorColumn;
        public static int CursorOffset;

        public static void WriteFromTop(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(consoleWindowTopColumn + x, consoleWindowTopRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void PrintCursor()
        {
            Console.CursorVisible = false;
            // Sets cursor position to 0
            UI.CurrentCursorRow = Console.CursorLeft;
            UI.CurrentCursorColumn = Console.CursorTop;
            Console.SetCursorPosition(consoleWindowTopColumn, consoleWindowTopRow);

            // Draws the cursor at the selected coordinates
            for (int i = 0; i < MenuLength; ++i)
            {
                if (i == SelectedOption)
                {
                    WriteFromTop("*", 1, (SelectedOption + CursorOffset));

                }
                else if (i != SelectedOption)
                {
                    WriteFromTop(" ", 1, (i + CursorOffset));
                }
            }
            Console.SetCursorPosition(UI.CurrentCursorRow, UI.CurrentCursorColumn);
            UI.CurrentCursorRow = 0;
            UI.CurrentCursorColumn = 0;
            Console.CursorVisible = true;
        }

        // Handles movement of menus
        public static void UIMovement()
        {
            MenuInput = Console.ReadKey(true).Key.ToString();
            if (MenuInput == "UpArrow")
            {
                UISelectUp();
            }
            else if (MenuInput == "DownArrow")
            {
                UISelectDown();
            }
        }

        // Menu selection UP
        public static void UISelectUp()
        {
            if (SelectedOption > 0)
            {
                PrintCursor();
                --SelectedOption;
            }
            else if (SelectedOption == 0)
            {
                PrintCursor();
                SelectedOption = MenuLength - 1;
            }
        }

        // Menu selection DOWN
        public static void UISelectDown()
        {
            if (SelectedOption < MenuLength - 1)
            {
                PrintCursor();
                ++SelectedOption;
            }
            else if (SelectedOption == MenuLength - 1)
            {
                PrintCursor();
                SelectedOption = 0;
            }
        }

        // What the cursor looks like
        public static void UICursor(int i)
        {
            if (i == SelectedOption)
            {
                CursorSymbol = '*';
            }
            else
            {
                CursorSymbol = ' ';
            }
        }

        // Choose selected menu item
        public static int UIGetSelection()
        {
            return SelectedOption;
        }

        public static void UIHeaderGeneric()
        {
            Console.WriteLine("Now playing: lil mini rpg");
            Console.WriteLine("");
        }

        public static void UIFooterGeneric()
        {
            Console.WriteLine("");
            Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
            //            Console.WriteLine($"UI.CursorSymbol = {UI.CursorSymbol} || UI.MenuTracker = {UI.MenuTracker} || UI.SelectedOption = {UI.SelectedOption} || UI.MenuInput = {UI.MenuInput} || UI.MenuLength = {UI.MenuLength}");
        }

        // Default method for any invalid selections/bugs
        public static void InvalidSelection()
        {
            Console.WriteLine("You have entered an invalid selection. Please press enter to restart.");
            Console.ReadLine();
            Program.Main();
        }





        //public static void PrintColorList()
        //{
        //    ConsoleColor[] consoleColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        //    Console.WriteLine("List of available " + "Console Colors:");

        //    for (int i = 0; i < consoleColors.Length; ++i)
        //    {
        //        Console.ForegroundColor = consoleColors[i];
        //        Console.WriteLine($"Hello, World: {consoleColors[i]}");
        //    }
        //    Console.ReadLine();
        //}
    }
}
