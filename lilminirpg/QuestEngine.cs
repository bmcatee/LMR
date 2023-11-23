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
        public async static Task InitStageArray(Player currentplayer)
        {
            int currentStage = currentplayer.CurrentStage;
            Enemy[] enemiesOnScreen = CreateStageArray(currentStage);
            for (int i = 0; i < enemiesOnScreen.Length; i++)
            {
                Console.WriteLine($"Level: {currentStage} - Enemy on Current Tile {i}: {enemiesOnScreen[i].Name} - HP = {enemiesOnScreen[i].HealthPointsMax}");
            }
            Console.WriteLine($"Press Enter to continue");
            Console.ReadLine();
            int[] CurrentGameScreen = new int[16];
            Movement.MoveThroughScreen(currentplayer,enemiesOnScreen);
        }

        public static Enemy[] CreateStageArray(int gamestage)
        {
            int[] currentGameScreen = new int[16];
            Enemy[] enemiesOnScreen = new Enemy[16];
            for (int i = 0; i < currentGameScreen.Length; ++i)
            {
                DiceRoller _diceRoller = new DiceRoller();
                int fillPositionRoll = _diceRoller.RollDice(0, 2);
                int placeEnemyRoll = _diceRoller.RollDice(0, 100);
                int selectEnemyRoll = _diceRoller.RollDice(0, DataLists.EnemiesList.GetLength(0));
                EnemyMaker createdenemy = new EnemyMaker();
//                Console.WriteLine($"Position Roll: {fillPositionRoll}");
//                Console.WriteLine($"Enemy Roll: {placeEnemyRoll}");

                if (fillPositionRoll == 0 || i <= 3)
                {
                    enemiesOnScreen[i] = createdenemy.MakeEnemy(0);
                    currentGameScreen[i] = 0;
                }
                else if (fillPositionRoll == 1 && i > 3)
                {
                    createdenemy = new EnemyMaker();

                    switch (placeEnemyRoll)
                    {
                        case int n when (n > -1 && n < 31):
                            enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                            currentGameScreen[i] = 1;
                            break;
                        case int n when (n > 30 && n < 61):
                            enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                            currentGameScreen[i] = 2;
                            break;
                        case int n when (n > 60 && n <= 99):
                            enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll);
                            currentGameScreen[i] = 3;
                            break;
                        default:
                            Console.WriteLine($"Roll: {placeEnemyRoll} - YOU SHOULD NOT BE HERE");
                            enemiesOnScreen[i] = createdenemy.MakeEnemy(0);
                            currentGameScreen[i] = 0;
                            break;
                    }
                }
            }
                return enemiesOnScreen;
        }
    }
}

// TESTS
// Console.WriteLine($"Array filled with {CurrentGameScreen[i]}");
// Console.WriteLine($"Roll Result was: {DiceRoller.RollResults} (0-70)");
// Console.WriteLine($"Tile: {i} = {CurrentGameScreen[i]} || Enemy on Tile {i}: {EnemiesOnScreen[i].CharacterName}");