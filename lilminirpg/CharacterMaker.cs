using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class CharacterMaker
    {
        static Player _player = new Player();
        static bool characterCreation = false;
        static int characterCreationStage = 0;

        public void MakeCharacter()
        {
            // Starts the full player character creation process
            characterCreation = true;
            _player.ClassName = "";
            _player.WornWeapon = "";
            _player.WornAccessory = "";
            SetCharacterName();
        }

        // Set character name
        public static void SetCharacterName()
        {
            Console.Clear();
            UI.MenuTracker = "MenuPlayerName";
            Console.CursorVisible = true;
            UI.UIHeaderGeneric();
            if (characterCreation == true)
            {
                Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
            }
            else
            {
                Console.WriteLine("Please type your character's name and press Enter:");
            };

            _player.CharacterName = Console.ReadLine();

            if (characterCreation == true)
            {
                characterCreationStage = 1;
                ChooseCharacterInfo("MenuPlayerClass");
            }
            else
            {
                Menus.MenuGeneric("MenuMain");
            }
        }

        public static void ChooseCharacterInfo(string menutracker)
        {
            // Set desired menu, reset other variables to initial values
            UI.MenuTracker = menutracker;
            UI.SelectedOption = 0;
            UI.MenuInput = "";


            // Clear console, print character info; dislike this, would rather the display be more elegant
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon} || Accessory: {_player.WornAccessory}");
            Console.WriteLine("");

            // Passes to the appropriate menu
            if (menutracker == "MenuPlayerName")
            {
                SetCharacterName();
            }
            else if (menutracker == "MenuPlayerClass")
            {
                UI.CursorOffset = 4;
                UI.MenuTracker = "MenuPlayerClass";
                UI.MenuLength = DataLists.PlayerClasses.GetLength(0);
                Console.WriteLine("Your class choices are:");
                Console.WriteLine("");
                for (int i = 0; i < DataLists.PlayerClasses.GetLength(0); ++i)
                {
                    UI.UICursor(i);
                    Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.PlayerClasses[i, 1]}: {DataLists.PlayerClasses[i, 2]}");
                }
            }
            else if (menutracker == "MenuPlayerWeapon")
            {
                UI.CursorOffset = 4;
                UI.MenuTracker = "MenuPlayerWeapon";
                UI.MenuLength = DataLists.PlayerWeapons.GetLength(0);
                Console.WriteLine("Please choose a weapon:");
                Console.WriteLine("");
                for (int i = 0; i < DataLists.PlayerWeapons.GetLength(0); ++i)
                {
                    UI.UICursor(i);
                    Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.PlayerWeapons[i, 1]}: {DataLists.PlayerWeapons[i, 2]}");
                }
            }
            else if (menutracker == "MenuPlayerAccessory")
            {
                UI.CursorOffset = 4;
                UI.MenuTracker = "MenuPlayerAccessory";
                UI.MenuLength = DataLists.PlayerAccessories.GetLength(0);
                Console.WriteLine("Please choose an accessory.");
                Console.WriteLine("");
                for (int i = 0; i < DataLists.PlayerAccessories.GetLength(0); ++i)
                {
                    UI.UICursor(i);
                    Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.PlayerAccessories[i, 1]}: {DataLists.PlayerAccessories[i, 2]}");
                }
            }
            else
            {
                UI.InvalidSelection();
            }

            UI.UIFooterGeneric();
            while (UI.MenuInput != "Enter")
            {
                UI.PrintCursor();
                UI.UIMovement();
            }
            UI.CursorOffset = 0;
            SetCharacterInfo(menutracker);
        }
        public static void SetCharacterInfo(string menutracker)
        {
            // Sets the player info
            if (menutracker == "MenuPlayerClass")
            {
                if (UI.SelectedOption < DataLists.PlayerClasses.GetLength(0))
                {
                    _player.ClassName = DataLists.PlayerClasses[UI.SelectedOption, 1];
                }
                else
                {
                    UI.InvalidSelection();
                }
                if (characterCreation == true)
                {
                    characterCreationStage = 2;
                }
            }
            else if (menutracker == "MenuPlayerWeapon")
            {
                if (UI.SelectedOption < DataLists.PlayerWeapons.GetLength(0))
                {
                    _player.WornWeapon = DataLists.PlayerWeapons[UI.SelectedOption, 1];
                }
                else
                {
                    UI.InvalidSelection();
                }
                if (characterCreation == true)
                {
                    characterCreationStage = 3;
                }
            }
            else if (menutracker == "MenuPlayerAccessory")
            {
                if (UI.SelectedOption < DataLists.PlayerAccessories.GetLength(0))
                {
                    _player.WornAccessory = DataLists.PlayerAccessories[UI.SelectedOption, 1];
                }
                else
                {
                    UI.InvalidSelection();
                }
                if (characterCreation == true)
                {
                    characterCreationStage = 4;
                }
            }

            // Moves to next step in character creation
            if (characterCreation == true)
            {
                if (characterCreationStage == 0)
                {
                    ChooseCharacterInfo("MenuPlayerName");
                }
                else if (characterCreationStage == 1)
                {
                    ChooseCharacterInfo("MenuPlayerClass");
                }
                else if (characterCreationStage == 2)
                {
                    ChooseCharacterInfo("MenuPlayerWeapon");
                }
                else if (characterCreationStage == 3)
                {
                    ChooseCharacterInfo("MenuPlayerAccessory");
                }
                else if (characterCreationStage == 4)
                {
                    EndCharacterCreation();
                }
            }
            else
            {
                Menus.MenuGeneric("MenuMain");
            }
        }

        // Resets variables, prints selection, saves game, goes back to Main Menu
        public static void EndCharacterCreation()
        {
            UI.SelectedOption = 0;
            UI.MenuInput = "";
            UI.MenuTracker = "";
            UI.MenuLength = 0;
            UI.CursorOffset = 0;
            characterCreation = false;
            characterCreationStage = 0;
            Console.Clear();
            UI.UIHeaderGeneric();
            Console.WriteLine("You have selected:");
            Console.WriteLine($"[*] Name: {_player.CharacterName}");
            Console.WriteLine($"[*] Class: {_player.ClassName}");
            Console.WriteLine($"[*] Weapon: {_player.WornWeapon}");
            Console.WriteLine($"[*] Accessory: {_player.WornAccessory}");
            SaveLoad.SaveGame(_player.CharacterName, _player.ClassName, _player.WornWeapon, _player.WornAccessory);
            Console.WriteLine("Please press Enter to continue.");
            Menus.MenuGeneric("MenuMain");
        }
    }
}
