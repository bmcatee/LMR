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
                Console.Clear();
                --SelectedOption;
            }
            else if (SelectedOption == 0)
            {
                Console.Clear();
                SelectedOption = MenuLength - 1;
            }
        }

        // Menu selection DOWN
        public static void UISelectDown()
        {
            if (SelectedOption < MenuLength - 1)
            {
                Console.Clear();
                ++SelectedOption;
            }
            else if (SelectedOption == MenuLength - 1)
            {
                Console.Clear();
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

        // Called when switching menus; I know there has to be a better way of doing this, and maybe I'll figure it out later. :P
        public static void UIMenuSelector(string menutracker)
        {
            MenuTracker = menutracker;

            if (MenuTracker == "MenuMain")
            {
                MenuLength = ItemLists.MenuMain.GetLength(0);
                Menus.MenuGeneric("MenuMain");
            }
            else if (MenuTracker == "MenuPlayerName")
            {
                CharacterMaker.SetCharacterName();
            }
            else if (MenuTracker == "MenuPlayerClass")
            {
                MenuLength = ItemLists.PlayerClasses.GetLength(0);
                Menus.MenuGeneric("MenuPlayerClass");
            }
            else if (MenuTracker == "MenuPlayerWeapon")
            {
                MenuLength = ItemLists.PlayerWeapons.GetLength(0);
                Menus.MenuGeneric("MenuPlayerWeapon");
            }
            else if (MenuTracker == "MenuPlayerAccessory")
            {
                MenuLength = ItemLists.PlayerAccessories.GetLength(0);
                Menus.MenuGeneric("MenuPlayerAccessory");
            }
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
        }
    }
}
