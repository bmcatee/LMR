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
                Enemy dummyenemy = EnemyMethods.CreateDummy();
                Enemy createdenemy = EnemyMethods.CreateRandomEnemy(currentStage);

                if (fillPositionRoll == 0 || i <= 3)
                {
                    enemiesOnScreen[i] = dummyenemy;
                }
                else if (fillPositionRoll == 1 && i > 3)
                {
                    enemiesOnScreen[i] = createdenemy;
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