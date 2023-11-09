using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class QuestEngine
    {
        public static int CurrentGameLevel = 0;
        private static Random _randombool = new Random();
        public static bool[] NewGameScreen = new bool[16];
        public static int[] CurrentGameScreen = new int[16];
        public static Enemy[] EnemiesOnScreen = new Enemy[16];
        

        // Create an array and fill it with on/off statements (first 4 slots are always 'off')
        public static void CreateStageArray()
        {
            CurrentGameLevel = ++CurrentGameLevel;
            Console.WriteLine($"                    Generating Level {CurrentGameLevel}");

            for (int i = 0; i < NewGameScreen.Length; ++i)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3)
                {
                    NewGameScreen[i] = false;
                    Console.WriteLine($"NewGameScreen {i} = {NewGameScreen[i]}");
                }
                else
                {
                    NewGameScreen[i] = _randombool.Next(2) == 1;
                    Console.WriteLine($"NewGameScreen {i} = {NewGameScreen[i]}");
                }
            }

            Console.WriteLine($"                    Filling Level {CurrentGameLevel}");
            FillStageArray(CurrentGameLevel);
        }

        // Fills the stage array with objects
        public static void FillStageArray(int level)
        {
            var createdenemy0 = new EnemyMaker();

            // fill with dummy data first
            for (int i = 0; i < NewGameScreen.Length; ++i)
            {
                EnemiesOnScreen[i] = createdenemy0.MakeEnemy(0);
                Console.WriteLine($"NewGameScreen {i} = {CurrentGameScreen[i]} || Enemy on Tile {i}: {EnemiesOnScreen[i].CharacterName}");
            }

            // now populate
            for (int i = 0; i < NewGameScreen.Length; ++i)
            {
                if (NewGameScreen[i] == false)
                {
                    CurrentGameScreen[i] = 0;
                    Console.WriteLine($"NewGameScreen {i} = {CurrentGameScreen[i]} || Enemy on Tile {i}: {EnemiesOnScreen[i].CharacterName}");
                }
                else if (NewGameScreen[i] == true)
                {
                    DiceRoller.RollDice(1, 99);
                    if (DiceRoller.RollResults > -1 && DiceRoller.RollResults < 31)
                    {
                        var createdenemy1 = new EnemyMaker();
                        EnemiesOnScreen[i] = createdenemy1.MakeEnemy(1);
                        CurrentGameScreen[i] = 1;
                        Console.WriteLine($"Roll Result was: {DiceRoller.RollResults} (0-30)");
                        Console.WriteLine($"Tile: {i} = {CurrentGameScreen[i]} || Enemy on Tile {i}: {EnemiesOnScreen[i].CharacterName}");
                    }
                    else if (DiceRoller.RollResults > 30 && DiceRoller.RollResults < 61)
                    {
                        var createdenemy2 = new EnemyMaker();
                        EnemiesOnScreen[i] = createdenemy2.MakeEnemy(2);
                        CurrentGameScreen[i] = 2;
                        Console.WriteLine($"Roll Result was: {DiceRoller.RollResults} (31-64)");
                        Console.WriteLine($"Tile: {i} = {CurrentGameScreen[i]} || Enemy on Tile {i}: {EnemiesOnScreen[i].CharacterName}");
                    }
                    else if (DiceRoller.RollResults > 60 && DiceRoller.RollResults <= 99)
                    {
                        var createdenemy3 = new EnemyMaker();
                        EnemiesOnScreen[i] = createdenemy3.MakeEnemy(3);
                        CurrentGameScreen[i] = 3;
                        Console.WriteLine($"Roll Result was: {DiceRoller.RollResults} (65-99)");
                        Console.WriteLine($"Tile: {i} = {CurrentGameScreen[i]} || Enemy on Tile {i}: {EnemiesOnScreen[i].CharacterName}");
                    }
                    //for (int j = 0; j < EnemiesOnScreen.Length; j++)
                    //{
                    //    Console.WriteLine($"Enemy on Current Tile {j}: {EnemiesOnScreen[j].CharacterName}");
                    //}
                }
            }

            for (int i = 0; i < EnemiesOnScreen.Length; i++)
            {
                Console.WriteLine($"Enemy on Current Tile {i}: {EnemiesOnScreen[i].CharacterName}");
            }
            Console.WriteLine($"Press Enter to continue");
            Console.ReadLine();
            PlayerMoveThroughScreen();
        }

        public static void PlayerMoveThroughScreen()
        {
            Movement.PlayerPosition(CurrentGameScreen.Length - 1);
        }
    }
}

// TESTS
// Console.WriteLine($"Array filled with {CurrentGameScreen[i]}");
// Console.WriteLine($"Roll Result was: {DiceRoller.RollResults} (0-70)");
