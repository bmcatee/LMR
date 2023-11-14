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
            UI userInterface = new(0, "", "", 0);

            // Set desired menu, reset other variables to initial values
            userInterface.MenuTracker = menuTracker;
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            string[,] DataListString = DataLists.MenuMain;


            // Clear console, print character info; dislike this, would rather the display be more elegant
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"Name: {newPlayer.CharacterName} || Class: {newPlayer.ClassName} || Weapon: {newPlayer.WornWeapon} || Accessory: {newPlayer.WornAccessory}");

            Console.WriteLine("");

            // Passes to the appropriate menu

            switch (menuTracker)
            {
                case "MenuPlayerName":
                    userInterface.MenuTracker = "MenuPlayerName";
                    SetCharacterName();
                    break;
                case "MenuPlayerClass":
                    userInterface.CursorOffset = 4;
                    DataListString = DataLists.PlayerClasses;
                    userInterface.MenuTracker = "MenuPlayerClass";
                    break;
                case "MenuPlayerWeapon":
                    userInterface.CursorOffset = 4;
                    DataListString = DataLists.PlayerWeapons;
                    userInterface.MenuTracker = "MenuPlayerWeapon";
                    break;
                case "MenuPlayerAccessory":
                    userInterface.CursorOffset = 4;
                    DataListString = DataLists.PlayerAccessories;
                    userInterface.MenuTracker = "MenuPlayerAccessory";
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }

            userInterface.MenuLength = DataListString.GetLength(0);
            Console.WriteLine("Your class choices are:");
                Console.WriteLine("");
                for (int i = 0; i < DataListString.GetLength(0); ++i)
                {
                userInterface.UICursor(i);
                    Console.WriteLine($"[{userInterface.CursorSymbol}] {DataListString[i, 0]}: {DataListString[i, 1]}");
                }

            UI.UIFooterGeneric();
            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.UIMovement();
                Console.WriteLine($"CursorOffset {userInterface.CursorOffset} | MenuTracker {userInterface.MenuTracker} | SelectedOption {userInterface.SelectedOption} | MenuInput {userInterface.MenuInput} | MenuLength {userInterface.MenuLength}");

            }
            userInterface.CursorOffset = 0;
            SetCharacterInfo(userInterface.MenuTracker, userInterface.SelectedOption);
        }

        // Sets the player info
        public static void SetCharacterInfo(string menuTracker, int selectedOption)
        {            // Sets the player info
            UI userInterface = new(0, "", "", 0);

            switch (menuTracker)
            {
                case "MenuPlayerClass":
                    if (selectedOption < DataLists.PlayerClasses.GetLength(0))
                    {
                        newPlayer.ClassName = DataLists.PlayerClasses[selectedOption, 0];
                    }
                    else
                    {
                        UI.InvalidSelection();
                    }
                    if (_characterCreation == true)
                    {
                        _characterCreationStage = 2;
                    }
                    break;
                case "MenuPlayerWeapon":
                    if (selectedOption < DataLists.PlayerWeapons.GetLength(0))
                    {
                        newPlayer.WornWeapon = DataLists.PlayerWeapons[selectedOption, 0];
                    }
                    else
                    {
                        UI.InvalidSelection();
                    }
                    if (_characterCreation == true)
                    {
                        _characterCreationStage = 3;
                    }
                    break;
                case "MenuPlayerAccessory":
                    if (selectedOption < DataLists.PlayerAccessories.GetLength(0))
                    {
                        newPlayer.WornAccessory = DataLists.PlayerAccessories[selectedOption, 0];
                    }
                    else
                    {
                        UI.InvalidSelection();
                    }
                    if (_characterCreation == true)
                    {
                        _characterCreationStage = 4;
                    }
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }

            // Moves to next step in character creation
            if (_characterCreation == true)
            {
                switch (_characterCreationStage)
                {
                    case 0:
                        ChooseCharacterInfo("MenuPlayerName");
                        break;
                    case 1:
                        ChooseCharacterInfo("MenuPlayerClass");
                        break;
                    case 2:
                        ChooseCharacterInfo("MenuPlayerWeapon");
                        break;
                    case 3:
                        ChooseCharacterInfo("MenuPlayerAccessory");
                        break;
                    default:
                        EndCharacterCreation();
                        break;
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
