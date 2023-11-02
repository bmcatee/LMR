using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal static class UI 
    {
        public static char Cursor = ' ';
        public static int SelectedOption { get; set; }
        public static string MenuInput { get; set; }
        public static string MenuTracker { get; set; }
        public static int MenuLength { get; set; }

        public static void SelectUp()
        {
            if (SelectedOption > 0)
            {
                Console.Clear();
                --SelectedOption;
            }
            else if (SelectedOption == 0)
            {
                Console.Clear();
                SelectedOption = MenuLength -1;
            }
        }

        public static void SelectDown()
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
        public static int GetSelection()
        {
            return SelectedOption;
        }
        public static void ShowCursor()
        {

        }
        public static void MenuSelector()
        {
                if (MenuTracker == "MenuMain")
                {
                    Menus.MenuMain();
                }
                else if (MenuTracker == "MenuPlayerClass")
                {
                    Menus.MenuPlayerClass();
                }
                else if (MenuTracker == "MenuWeapon")
                {
                    Menus.MenuWeapon();                }
                else if (MenuTracker == "MenuAccessory")
                {
                    Menus.MenuAccessory();
                }            
        }
    }
}
