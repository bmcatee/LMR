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
        Player _player = new Player();
        bool CharacterCreation = false;

        public void MakeCharacter()
        {
            CharacterCreation = true;
            // Player character creation
            while (UI.MenuInput != "Escape")
            {
                SetCharacterName();
            }
        }

        public void SetCharacterName()
        {
            while (UI.MenuInput != "Escape")
            {
                // Set character name
                Console.Clear();
                UI.MenuTracker = "MenuPlayerName";
                Console.CursorVisible = true;
                Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
                _player.CharacterName = Console.ReadLine();

                if (CharacterCreation == true)
                {
                    SetCharacterClass();
                }
                else
                {
                    Menus.MenuMain();
                }
            }
        }
        public void SetCharacterClass()
        {
            UI.SelectedOption = 0;
            UI.MenuInput = "";
            UI.MenuTracker = "MenuPlayerClass";
            UI.MenuLength = ItemLists.PlayerClasses.GetLength(0);

            while (UI.MenuInput != "Enter")
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"Name: {_player.CharacterName}");
                Console.WriteLine("");
                Console.WriteLine($"Hello {_player.CharacterName}! Next you will choose your class, a weapon, and an accessory.");

                Menus.MenuPlayerClass();

                UI.MenuInput = Console.ReadKey(true).Key.ToString();
                if (UI.MenuInput == "UpArrow")
                {
                    UI.SelectUp();
                }
                else if (UI.MenuInput == "DownArrow")
                {
                    UI.SelectDown();
                }
            }
            if (UI.SelectedOption < ItemLists.PlayerClasses.GetLength(0))
            {
                _player.ClassName = ItemLists.PlayerClasses[UI.SelectedOption, 1];
            }
            else
            {
                Menus.InvalidSelection();
            }
            if (CharacterCreation == true)
            {
                SetCharacterWeapon();
            }
            else
            {
                Menus.MenuMain();
            }
        }

        public void SetCharacterWeapon()
        {
            UI.SelectedOption = 0;
            UI.MenuInput = "";
            UI.MenuTracker = "MenuWeapon";
            UI.MenuLength = ItemLists.PlayerWeapons.GetLength(0);

            while (UI.MenuInput != "Enter")
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName}");
                Console.WriteLine("");

                Menus.MenuPlayerWeapon();

                UI.MenuInput = Console.ReadKey().Key.ToString();
                if (UI.MenuInput == "UpArrow")
                {
                    UI.SelectUp();
                }
                else if (UI.MenuInput == "DownArrow")
                {
                    UI.SelectDown();
                }
            }
            if (UI.SelectedOption < ItemLists.PlayerWeapons.GetLength(0))
            {
                _player.WornWeapon = ItemLists.PlayerWeapons[UI.SelectedOption, 1];
            }
            else
            {
                Menus.InvalidSelection();
            }
            if (CharacterCreation == true)
            {
                SetCharacterAccessory();
            }
            else
            {
                Menus.MenuMain();
            }
        }
        public void SetCharacterAccessory() 
        {
            UI.SelectedOption = 0;
            UI.MenuInput = "";
            UI.MenuTracker = "MenuPlayerAccessory";
            UI.MenuLength = ItemLists.PlayerAccessories.GetLength(0);

            while (UI.MenuInput != "Enter")
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon}");
                Console.WriteLine("");

                Menus.MenuPlayerAccessory();

                UI.MenuInput = Console.ReadKey(true).Key.ToString();
                if (UI.MenuInput == "UpArrow")
                {
                    UI.SelectUp();
                }
                else if (UI.MenuInput == "DownArrow")
                {
                    UI.SelectDown();
                }
            }
                if (UI.SelectedOption < ItemLists.PlayerAccessories.GetLength(0))
                {
                    _player.WornAccessory = ItemLists.PlayerAccessories[UI.SelectedOption, 1];
                }
                else
                {
                    Menus.InvalidSelection();
                }
                if (CharacterCreation == true)
                {
                    EndCharacterCreation();
                }
                else
                {
                    Menus.MenuMain();
                }
            }
        public void EndCharacterCreation()
        {
            UI.SelectedOption = 0;
            UI.MenuInput = "";
            UI.MenuTracker = "";
            UI.MenuLength = 0;

            Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon} || Accessory: {_player.WornAccessory}");
            Program.SaveGame(_player.CharacterName, _player.ClassName, _player.WornWeapon, _player.WornAccessory);
            CharacterCreation = false;
        }
    }
}
