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
        public static void InitStageArray(Player currentplayer)
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

        public static Enemy[] CreateStageArray(int currentStage)
        {
            int[] currentGameScreen = new int[16];
            Enemy[] enemiesOnScreen = new Enemy[16];
            for (int i = 0; i < currentGameScreen.Length; ++i)
            {
                int fillPositionRoll = DiceRoller.RollDice(0, 2);
                //int placeEnemyRoll = DiceRoller.RollDice(0, 100);
                //int selectEnemyRoll = DiceRoller.RollDice(0, DataLists.EnemiesList.GetLength(0));
                Enemy dummyenemy = EnemyMethods.CreateDummy();
                Enemy createdenemy = EnemyMethods.CreateRandomEnemy(currentStage);
                //                Console.WriteLine($"Position Roll: {fillPositionRoll}");
                //                Console.WriteLine($"Enemy Roll: {placeEnemyRoll}");

                if (fillPositionRoll == 0 || i <= 3)
                {
                    enemiesOnScreen[i] = dummyenemy;
                }
                else if (fillPositionRoll == 1 && i > 3)
                {
                    enemiesOnScreen[i] = createdenemy;
                    //switch (placeEnemyRoll)
                    //{
                    //    case int n when (n > -1 && n < 31):
                    //        enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll, currentStage);
                    //        currentGameScreen[i] = 1;
                    //        break;
                    //    case int n when (n > 30 && n < 61):
                    //        enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll, currentStage);
                    //        currentGameScreen[i] = 2;
                    //        break;
                    //    case int n when (n > 60 && n <= 99):
                    //        enemiesOnScreen[i] = createdenemy.MakeEnemy(selectEnemyRoll, currentStage);
                    //        currentGameScreen[i] = 3;
                    //        break;
                    //    default:
                    //        Console.WriteLine($"Roll: {placeEnemyRoll} - YOU SHOULD NOT BE HERE");
                    //        enemiesOnScreen[i] = createdenemy.MakeEnemy(0, currentStage);
                    //        currentGameScreen[i] = 0;
                    //        break;
                    //}
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