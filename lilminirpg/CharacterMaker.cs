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
        static Player newPlayer = new Player();
        private static bool _characterCreation = false;
        private static int _characterCreationStage = 0;

        public void MakeCharacter()
        {
            // Starts the full player character creation process
            _characterCreation = true;
            newPlayer.ClassName = "";
            newPlayer.WornWeapon = "";
            newPlayer.WornAccessory = "";
            SetCharacterName();
        }

        // Set character name
        public static void SetCharacterName()
        {
            Console.Clear();
            UI.MenuTracker = "MenuPlayerName";
            Console.CursorVisible = true;
            UI.UIHeaderGeneric();
            if (_characterCreation == true)
            {
                Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
            }
            else
            {
                Console.WriteLine("Please type your character's name and press Enter:");
            };

            newPlayer.CharacterName = Console.ReadLine();

            if (_characterCreation == true)
            {
                _characterCreationStage = 1;
                ChooseCharacterInfo("MenuPlayerClass");
            }
            else
            {
                Menus.MenuGeneric("MenuMain");
            }
        }

        public static void ChooseCharacterInfo(string menuTracker)
        {
            // Set desired menu, reset other variables to initial values
            UI.MenuTracker = menuTracker;
            UI.SelectedOption = 0;
            UI.MenuInput = "";


            // Clear console, print character info; dislike this, would rather the display be more elegant
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"Name: {newPlayer.CharacterName} || Class: {newPlayer.ClassName} || Weapon: {newPlayer.WornWeapon} || Accessory: {newPlayer.WornAccessory}");
            Console.WriteLine("");

            // Passes to the appropriate menu
            if (menuTracker == "MenuPlayerName")
            {
                SetCharacterName();
            }
            else if (menuTracker == "MenuPlayerClass")
            {
                UI.CursorOffset = 4;
                UI.MenuTracker = "MenuPlayerClass";
                UI.MenuLength = DataLists.PlayerClasses.GetLength(0);
                Console.WriteLine("Your class choices are:");
                Console.WriteLine("");
                for (int i = 0; i < DataLists.PlayerClasses.GetLength(0); ++i)
                {
                    UI.UICursor(i);
                    Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.PlayerClasses[i, 0]}: {DataLists.PlayerClasses[i, 1]}");
                }
            }
            else if (menuTracker == "MenuPlayerWeapon")
            {
                UI.CursorOffset = 4;
                UI.MenuTracker = "MenuPlayerWeapon";
                UI.MenuLength = DataLists.PlayerWeapons.GetLength(0);
                Console.WriteLine("Please choose a weapon:");
                Console.WriteLine("");
                for (int i = 0; i < DataLists.PlayerWeapons.GetLength(0); ++i)
                {
                    UI.UICursor(i);
                    Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.PlayerWeapons[i, 0]}: {DataLists.PlayerWeapons[i, 1]}");
                }
            }
            else if (menuTracker == "MenuPlayerAccessory")
            {
                UI.CursorOffset = 4;
                UI.MenuTracker = "MenuPlayerAccessory";
                UI.MenuLength = DataLists.PlayerAccessories.GetLength(0);
                Console.WriteLine("Please choose an accessory.");
                Console.WriteLine("");
                for (int i = 0; i < DataLists.PlayerAccessories.GetLength(0); ++i)
                {
                    UI.UICursor(i);
                    Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.PlayerAccessories[i, 0]}: {DataLists.PlayerAccessories[i, 1]}");
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
            SetCharacterInfo(menuTracker);
        }
        public static void SetCharacterInfo(string menuTracker)
        {
            // Sets the player info
            if (menuTracker == "MenuPlayerClass")
            {
                if (UI.SelectedOption < DataLists.PlayerClasses.GetLength(0))
                {
                    newPlayer.ClassName = DataLists.PlayerClasses[UI.SelectedOption, 0];
                }
                else
                {
                    UI.InvalidSelection();
                }
                if (_characterCreation == true)
                {
                    _characterCreationStage = 2;
                }
            }
            else if (menuTracker == "MenuPlayerWeapon")
            {
                if (UI.SelectedOption < DataLists.PlayerWeapons.GetLength(0))
                {
                    newPlayer.WornWeapon = DataLists.PlayerWeapons[UI.SelectedOption, 0];
                }
                else
                {
                    UI.InvalidSelection();
                }
                if (_characterCreation == true)
                {
                    _characterCreationStage = 3;
                }
            }
            else if (menuTracker == "MenuPlayerAccessory")
            {
                if (UI.SelectedOption < DataLists.PlayerAccessories.GetLength(0))
                {
                    newPlayer.WornAccessory = DataLists.PlayerAccessories[UI.SelectedOption, 0];
                }
                else
                {
                    UI.InvalidSelection();
                }
                if (_characterCreation == true)
                {
                    _characterCreationStage = 4;
                }
            }

            // Moves to next step in character creation
            if (_characterCreation == true)
            {
                if (_characterCreationStage == 0)
                {
                    ChooseCharacterInfo("MenuPlayerName");
                }
                else if (_characterCreationStage == 1)
                {
                    ChooseCharacterInfo("MenuPlayerClass");
                }
                else if (_characterCreationStage == 2)
                {
                    ChooseCharacterInfo("MenuPlayerWeapon");
                }
                else if (_characterCreationStage == 3)
                {
                    ChooseCharacterInfo("MenuPlayerAccessory");
                }
                else if (_characterCreationStage == 4)
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
            _characterCreation = false;
            _characterCreationStage = 0;
            Console.Clear();
            UI.UIHeaderGeneric();
            Console.WriteLine("You have selected:");
            Console.WriteLine($"[*] Name: {newPlayer.CharacterName}");
            Console.WriteLine($"[*] Class: {newPlayer.ClassName}");
            Console.WriteLine($"[*] Weapon: {newPlayer.WornWeapon}");
            Console.WriteLine($"[*] Accessory: {newPlayer.WornAccessory}");
            SaveLoad.SaveGame(newPlayer.CharacterName, newPlayer.ClassName, newPlayer.WornWeapon, newPlayer.WornAccessory);
            Console.WriteLine("Please press Enter to continue.");
            Menus.MenuGeneric("MenuMain");
        }
    }
}
