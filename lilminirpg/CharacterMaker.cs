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
        public void MakeCharacter()
        {
            // Begin character creation
            while (UI.MenuInput != "Escape")
            {
                // Set character name
                Console.Clear();
                UI.MenuTracker = "MenuPlayerName";
                Console.CursorVisible = true;
                Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
                _player.CharacterName = Console.ReadLine();

                // Cleanup before moving to setting the character class
                UI.SelectedOption = 0;
                UI.MenuInput = "";
                UI.MenuTracker = "MenuPlayerClass";
                UI.MenuLength = ItemLists.PlayerClasses.GetLength(0);

                // TEST
                //Console.WriteLine($"UI.MenuTracker = {UI.MenuTracker} || UI.MenuInput = {UI.MenuInput} || UI.MenuLength = {UI.MenuLength}");
                //Console.ReadLine();
            
                // Set character class
                while (UI.MenuInput != "Enter")
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine($"Name: {_player.CharacterName}");
                    Console.WriteLine("");
                    Console.WriteLine($"Hello {_player.CharacterName}! Next you will choose your class, a weapon, and an accessory.");

                    UI.MenuSelector();

                    // TEST
                    //Console.WriteLine($"SelectedOption = {UI.SelectedOption} || MenuLength = {UI.MenuLength}");

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

                // Set player weapon
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

                    UI.MenuSelector();

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

                // Set player accessory
                UI.SelectedOption = 0;
                UI.MenuInput = "";
                UI.MenuTracker = "MenuAccessory";
                UI.MenuLength = ItemLists.PlayerAccessories.GetLength(0);

                while (UI.MenuInput != "Enter")
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: { _player.WornWeapon}");
                    Console.WriteLine("");

                    UI.MenuSelector();

                    UI.MenuInput = Console.ReadKey(true).Key.ToString();
                    if (UI.MenuInput == "UpArrow")
                    {
                        UI.SelectUp();
                    }
                    else if (UI.MenuInput == "DownArrow")
                    {
                        UI.SelectDown();
                    }
                    if (UI.SelectedOption < ItemLists.PlayerAccessories.GetLength(0))
                    {
                        _player.WornAccessory = ItemLists.PlayerAccessories[UI.SelectedOption, 1];
                    }
                    else
                    {
                        Menus.InvalidSelection();
                    }
                }
                Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon} || Accessory: {_player.WornAccessory}");
                UI.SelectedOption = 0;
                UI.MenuInput = "";
                UI.MenuTracker = "";
                UI.MenuLength = 0;

                Program.SaveGame(_player.CharacterName, _player.ClassName, _player.WornWeapon, _player.WornAccessory);
                return;
            }
            
        }

    }
}
