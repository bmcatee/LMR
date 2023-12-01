﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Weapon
    {
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public string? AttackType { get; set; } = "";
        public string? ElementType { get; set; } = "";
        public string? AttackStat1 { get; set; } = "";
        public int AttackPercent1 { get; set; } = 0;
        public string? AttackStat2 { get; set; } = "";
        public int AttackPercent2 { get; set; } = 0;
        public int HealthPointsMax { get; set; } = 0;
        public int StatStrength { get; set; } = 0;
        public int StatDexterity { get; set; } = 0;
        public int StatIntelligence { get; set; } = 0;
        public int StatLuck { get; set; } = 0;
        public int MoveSpeed { get; set; } = 0;
        public int AttackSpeed { get; set; } = 0;
        public string? WeaponPerk { get; set; } = "";
    }
    public class WeaponMethods
    {
        public class WeaponList
        {
            public List<WeaponList>? playerWeapons { get; set; }
        }
        // As mentioned elsewhere these lists should all be moved into the DB later
        public static List<Weapon> FetchWeapons()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "WeaponsList.json";
            List<Weapon> playerWeapons = new List<Weapon>();
            using (StreamReader sr = new StreamReader(Path.Combine(folder, filename)))
            {
                while (!sr.EndOfStream)
                {
                    string json = sr.ReadToEnd();
                    playerWeapons = JsonSerializer.Deserialize<List<Weapon>>(json);
                }
            }
            return playerWeapons;
        }

        // Sets the player's active weapon
        public async static Task<Player> SetPlayerWeapon(Player currentPlayer)
        {
            Console.Clear();
            UI userInterface = new();
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            userInterface.CursorOffset = 9;

            List<Weapon> _listPlayerWeapons = FetchWeapons();

            UI.UIHeaderGeneric();
            Console.WriteLine("");
            UI.UICharacterInfo(currentPlayer);

            if (CharacterMaker._characterCreation)
            {
                userInterface.MenuLength = _listPlayerWeapons.Count;
            }
            else
            {
                userInterface.MenuLength = _listPlayerWeapons.Count + 1;
            }

            Console.WriteLine("Your Weapon choices are:");
            Console.WriteLine("");

            for (int i = 0; i < _listPlayerWeapons.Count; ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerWeapons[i].Name}: {_listPlayerWeapons[i].Description}");
            }
            if (!CharacterMaker._characterCreation)
            {
                Console.WriteLine($"[ ] Return to Character Menu");
            }
            else
            {

            }

            UI.UIFooterGeneric();
            Console.WriteLine("");

            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.PrintItemInfo(_listPlayerWeapons);
                userInterface.UIMovement();
            }
            if (userInterface.SelectedOption < _listPlayerWeapons.Count)
            {
                currentPlayer.WornWeapon = _listPlayerWeapons[userInterface.SelectedOption];
            }
            else if(userInterface.SelectedOption < _listPlayerWeapons.Count + 1)
            {
                await Menus.EditCharacterMenu();
            }
            else
            {
                string location = "WeaponMenu";
                Program.LogException(userInterface.SelectedOption, location);
                UI.InvalidSelection();
            }
            if (CharacterMaker._characterCreation != true)
            {
                await SaveLoad.SaveGame(currentPlayer);
            }
            return currentPlayer;
        }
    }
}

