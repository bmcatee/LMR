using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class UI 
    {
        public char CursorSymbol = ' ';
        public int SelectedOption { get; set; }
        public string MenuInput { get; set; }
        public string MenuTracker { get; set; }
        public int MenuLength { get; set; }
        private static int consoleWindowTopRow = 0;
        private static int consoleWindowTopColumn = 0;
        public int CurrentCursorRow;
        public int CurrentCursorColumn;
        public int CursorOffset;

        public UI(int selectedOption = 0, string menuInput = "", string menuTracker = "", int menuLength = 0)
        {
            SelectedOption = selectedOption;
            MenuInput = menuInput;
            MenuTracker = menuTracker;
            MenuLength = menuLength;
        }

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

        public void PrintCursor()
        {
            Console.CursorVisible = false;
            // Sets cursor position to 0
            CurrentCursorRow = Console.CursorLeft;
            CurrentCursorColumn = Console.CursorTop;
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
            Console.SetCursorPosition(CurrentCursorRow, CurrentCursorColumn);
            CurrentCursorRow = 0;
            CurrentCursorColumn = 0;
            Console.CursorVisible = true;
        }

        // Handles movement of menus
        public void UIMovement()
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
        public void UISelectUp()
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
        public void UISelectDown()
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
        public void UICursor(int i)
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
        public int UIGetSelection()
        {
            return SelectedOption;
        }

        // Header/footer
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
    }
}
