using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static lilminirpg.DataLists;

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
            newPlayer.PlayerClass = new DataLists.PlayerClassInfo();
            newPlayer.WornWeapon = new DataLists.PlayerWeaponList();
            newPlayer.WornAccessory = new DataLists.PlayerAccessoryInfo();
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
            UI userInterface = new();

            // Set desired menu, reset other variables to initial values
            userInterface.MenuTracker = menuTracker;
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            List<PlayerClassInfo> _listPlayerClasses = new DataLists().PlayerClasses();
            List<PlayerWeaponList> _listWeapons = new DataLists().WeaponList();
            List<PlayerAccessoryInfo> _listAccessories = new DataLists().AccessoryList();
            int listCount = 0;
            var chosenList = "";
            // string[,] DataListString = DataLists.MenuMain;


            // Clear console, print character info
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"Name: {newPlayer.CharacterName} || Class: {newPlayer.PlayerClass.Name} || PlayerWeaponList: {newPlayer.WornWeapon.Name} || PlayerAccessoryInfo: {newPlayer.WornAccessory.Name}");

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
                    listCount = _listPlayerClasses.Count;
                    userInterface.MenuTracker = "MenuPlayerClass";
                    break;
                case "MenuPlayerWeapon":
                    userInterface.CursorOffset = 4;
                    listCount = _listWeapons.Count;
                    userInterface.MenuTracker = "MenuPlayerWeapon";
                    break;
                case "MenuPlayerAccessory":
                    userInterface.CursorOffset = 4;
                    listCount = _listAccessories.Count;
                    userInterface.MenuTracker = "MenuPlayerAccessory";
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }

            userInterface.MenuLength = listCount;
            Console.WriteLine("Your class choices are:");
                Console.WriteLine("");
                for (int i = 0; i < listCount; ++i)
                {
                userInterface.UICursor(i);
                switch (menuTracker)
                {
                    case "MenuPlayerClass":
                        Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerClasses[i].Name}: {_listPlayerClasses[i].Description}");
                        break;
                    case "MenuPlayerWeapon":
                        Console.WriteLine($"[{userInterface.CursorSymbol}] {_listWeapons[i].Name}: {_listWeapons[i].Description}");
                        break;
                    case "MenuPlayerAccessory":
                        Console.WriteLine($"[{userInterface.CursorSymbol}] {_listAccessories[i].Name}: {_listAccessories[i].Description}");
                        break;
                    default:
                        UI.InvalidSelection();
                        break;
                }
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
            UI userInterface = new();
            List<PlayerClassInfo> _listPlayerClasses = new DataLists().PlayerClasses();
            List<PlayerWeaponList> _listWeapons = new DataLists().WeaponList();
            List<PlayerAccessoryInfo> _listAccessories = new DataLists().AccessoryList();
            int weaponlength = _listWeapons.Count;
            int accessorylength = _listAccessories.Count;

            switch (menuTracker)
            {
                case "MenuPlayerClass":
                    if (selectedOption < _listPlayerClasses.Count)
                    {
                        newPlayer.PlayerClass = _listPlayerClasses[selectedOption];
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
                    if (selectedOption < weaponlength)
                    {
                        newPlayer.WornWeapon = _listWeapons[selectedOption];
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
                    if (selectedOption < accessorylength)
                    {
                        newPlayer.WornAccessory = _listAccessories[selectedOption];
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
            Console.WriteLine($"[*] Class: {newPlayer.PlayerClass.Name}");
            Console.WriteLine($"[*] PlayerWeaponList: {newPlayer.WornWeapon.Name}");
            Console.WriteLine($"[*] PlayerAccessoryInfo: {newPlayer.WornAccessory.Name}");
            SaveLoad.SaveGame(newPlayer);
            Console.WriteLine("");
            Console.WriteLine("Please press Enter to continue.");
            Console.ReadLine();
            Menus.MenuGeneric("MenuMain");
        }
    }
}
