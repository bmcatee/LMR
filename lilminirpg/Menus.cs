using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public static class Menus
    {
        public static void MenuMain()
        {
            {
                {
                    while (UI.MenuInput != "Enter")
                    {
                        Console.WriteLine("Now playing: lil mini rpg");
                        Console.WriteLine("");
                        for (int i = 0; i < UI.MenuLength; i++)
                        {
                            if (i == UI.SelectedOption)
                            {
                                UI.Cursor = '*';
                            }
                            else
                            {
                                UI.Cursor = ' ';
                            }
                            Console.WriteLine($"[{UI.Cursor}] {ItemLists.MainMenu[i, 1]}");
                        }

                        Console.WriteLine("");
                        Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
                        Console.WriteLine($"SelectedOption = {UI.SelectedOption} || MenuLength = {UI.MenuLength}");

                        UI.MenuInput = Console.ReadKey(true).Key.ToString();
                        if (UI.MenuInput == "UpArrow")
                        {
                            UI.SelectUp();
                        }
                        else if (UI.MenuInput == "DownArrow")
                        {
                            UI.SelectDown();
                        }
                        if (UI.SelectedOption == 0 && UI.MenuInput == "Enter")
                        {
                            CharacterMaker _charactermaker = new CharacterMaker();
                            _charactermaker.MakeCharacter();
                        }
                        else
                        {
                            Menus.InvalidSelection();
                        }
                    }
                }
            }
        }
        public static void MenuPlayerClass()
        {
            Console.WriteLine("Your class choices are:");
            Console.WriteLine("");
            for (int i = 0; i < UI.MenuLength; i++)
            {
                if (i == UI.SelectedOption)
                {
                    UI.Cursor = '*';
                }
                else
                {
                    UI.Cursor = ' ';
                }
                Console.WriteLine($"[{UI.Cursor}] {ItemLists.PlayerClasses[i, 1]}: {ItemLists.PlayerClasses[i, 2]}");
            }
            Console.WriteLine("");
            Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
        }
        public static void MenuWeapon()
        {
            Console.WriteLine("Now please choose a weapon:");
            Console.WriteLine("");
            for (int i = 0; i < UI.MenuLength; i++)
            {
                if (i == UI.SelectedOption)
                {
                    UI.Cursor = '*';
                }
                else
                {
                    UI.Cursor = ' ';
                }
                Console.WriteLine($"[{UI.Cursor}] {ItemLists.PlayerWeapons[i, 1]}: {ItemLists.PlayerWeapons[i, 2]}");
            }
            Console.WriteLine("");
            Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
        }
        public static void MenuAccessory()
        {
            Console.WriteLine("Now please choose an accessory.");
            Console.WriteLine("");
            for (int i = 0; i < UI.MenuLength; i++)
            {
                if (i == UI.SelectedOption)
                {
                    UI.Cursor = '*';
                }
                else
                {
                    UI.Cursor = ' ';
                }
                Console.WriteLine($"[{UI.Cursor}] {ItemLists.PlayerAccessories[i, 1]}: {ItemLists.PlayerAccessories[i, 2]}");
            }
            Console.WriteLine("");
            Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
        }
        public static void InvalidSelection()
        {
            Console.WriteLine("You have entered an invalid selection. Please try again.");
        }
    }
}

