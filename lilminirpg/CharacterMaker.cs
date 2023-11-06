﻿using lilminirpg;
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
            characterCreation = true;
            // Player character creation
            while (UI.MenuInput != "Escape")
            {
                SetCharacterName();
            }
        }

        public static void SetCharacterName()
        {
            while (UI.MenuInput != "Escape")
            {
                // Set character name
                Console.Clear();
                UI.MenuTracker = "MenuPlayerName";
                Console.CursorVisible = true;
                UI.UIHeaderGeneric();
                Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
                _player.CharacterName = Console.ReadLine();

                if (characterCreation == true)
                {
                    characterCreationStage = 1;
                    SetCharacterInfo("MenuPlayerClass");
                }
                else
                {
                    Menus.MenuGeneric("MenuMain");
                }
            }
        }

        public static void SetCharacterInfo(string menutracker)
        {
            // Set desired menu, reset other variables to initial values
            UI.MenuTracker = menutracker;
            UI.SelectedOption = 0;
            UI.MenuInput = "";

            while (UI.MenuInput != "Enter")
            {
                // Clear console, print character info; dislike this, would rather the display be more elegant
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon}");
                Console.WriteLine("");

                // Passes to the appropriate menu
                if (menutracker == "MenuPlayerName")
                {
                    SetCharacterName();
                }
                else if (menutracker == "MenuPlayerClass")
                {
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
                    Menus.InvalidSelection();
                }

                UI.UIFooterGeneric();
                UI.UIMovement();
            }

            // Sets the player info
            if (menutracker == "MenuPlayerClass")
            {
                if (UI.SelectedOption < DataLists.PlayerClasses.GetLength(0))
                {
                    _player.ClassName = DataLists.PlayerClasses[UI.SelectedOption, 1];
                }
                else
                {
                    Menus.InvalidSelection();
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
                    Menus.InvalidSelection();
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
                    Menus.InvalidSelection();
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
                    SetCharacterInfo("MenuPlayerName");
                }
                else if (characterCreationStage == 1)
                {
                    SetCharacterInfo("MenuPlayerClass");
                }
                else if (characterCreationStage == 2)
                {
                    SetCharacterInfo("MenuPlayerWeapon");
                }
                else if (characterCreationStage == 3)
                {
                    SetCharacterInfo("MenuPlayerAccessory");
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
            UI.UIMenuSelector("MenuMain");
        }
    }
}
