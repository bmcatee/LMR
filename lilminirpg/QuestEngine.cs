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
        public Enemy[] EnemiesOnScreen = new Enemy[16];

        public static void InitStageArray()
        {
            Enemy[] _enemiesOnScreen = CreateStageArray(CurrentGameLevel);
            for (int i = 0; i < _enemiesOnScreen.Length; i++)
            {
                Console.WriteLine($"Enemy on Current Tile {i}: {_enemiesOnScreen[i].CharacterName} - HP = {_enemiesOnScreen[i].HealthPointsMax}");
            }
            Console.WriteLine($"Press Enter to continue");
            Console.ReadLine();
            PlayerMoveThroughScreen(_enemiesOnScreen);
        }

        public static Enemy[] CreateStageArray(int gamelevel)
        {
            Enemy[] _enemiesOnScreen = new Enemy[16];
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
                    _enemiesOnScreen[i] = createdenemy.MakeEnemy(0);
                    CurrentGameScreen[i] = 0;
                }
                else if (fillPositionRoll == 1 && i > 3)
                {
                    createdenemy = new EnemyMaker();

                    switch (placeEnemyRoll)
                    {
                        case int n when (n > -1 && n < 31):
                            _enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                            CurrentGameScreen[i] = 1;
                            break;
                        case int n when (n > 30 && n < 61):
                            _enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                            CurrentGameScreen[i] = 2;
                            break;
                        case int n when (n > 60 && n <= 99):
                            _enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                            CurrentGameScreen[i] = 3;
                            break;
                        default:
                            Console.WriteLine($"Roll: {placeEnemyRoll} - YOU SHOULD NOT BE HERE");
                            _enemiesOnScreen[i] = createdenemy.MakeEnemy(0);
                            CurrentGameScreen[i] = 0;
                            break;
                    }
                }
            }
                return _enemiesOnScreen;
        }

        public static void PlayerMoveThroughScreen(Enemy[] createdEnemies)
        {
            Movement.PlayerPosition(CurrentGameScreen.Length - 1, createdEnemies);
        }

        public static void IncrementStageLevel()
        {
            CurrentGameLevel = ++CurrentGameLevel;
        }
    }
}

// TESTS
// Console.WriteLine($"Array filled with {CurrentGameScreen[i]}");
// Console.WriteLine($"Roll Result was: {DiceRoller.RollResults} (0-70)");
// Console.WriteLine($"Tile: {i} = {CurrentGameScreen[i]} || Enemy on Tile {i}: {EnemiesOnScreen[i].CharacterName}");