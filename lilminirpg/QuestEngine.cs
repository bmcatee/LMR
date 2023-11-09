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
        public static int[] CurrentGameScreen = new int[16];
        public static Enemy[] EnemiesOnScreen = new Enemy[16];

        public static void CreateStageArray()
        {

            CurrentGameLevel = ++CurrentGameLevel;

            for (int i = 0; i < CurrentGameScreen.Length; ++i)
            {
                DiceRoller _diceRoller = new DiceRoller();
                int fillPositionRoll = _diceRoller.RollDice(0, 2);
                int placeEnemyRoll = _diceRoller.RollDice(0, 100);
                int selectEnemyRoll = _diceRoller.RollDice(0, DataLists.EnemiesList.GetLength(0));
                EnemyMaker createdenemy = new EnemyMaker();
                Console.WriteLine($"Roll: {fillPositionRoll}");
                Console.WriteLine($"Roll: {placeEnemyRoll}");

                if (fillPositionRoll == 0 || i <= 3)
                {
                    EnemiesOnScreen[i] = createdenemy.MakeEnemy(0);
                    CurrentGameScreen[i] = 0;
                }
                else if (fillPositionRoll == 1 && i > 3)
                {

                    if (placeEnemyRoll > -1 && placeEnemyRoll < 31)
                    {
                        createdenemy = new EnemyMaker();
                        EnemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                        CurrentGameScreen[i] = 1;
                    }
                    else if (placeEnemyRoll > 30 && placeEnemyRoll < 61)
                    {
                        createdenemy = new EnemyMaker();
                        EnemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                        CurrentGameScreen[i] = 2;
                    }
                    else if (placeEnemyRoll > 60 && placeEnemyRoll <= 99)
                    {
                        createdenemy = new EnemyMaker();
                        EnemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                        CurrentGameScreen[i] = 3;
                    }
                    else
                    {
                        Console.WriteLine($"Roll: {placeEnemyRoll} - YOU SHOULD NOT BE HERE");
                        EnemiesOnScreen[i] = createdenemy.MakeEnemy(0);
                        CurrentGameScreen[i] = 0;
                    }
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
// Console.WriteLine($"Tile: {i} = {CurrentGameScreen[i]} || Enemy on Tile {i}: {EnemiesOnScreen[i].CharacterName}");