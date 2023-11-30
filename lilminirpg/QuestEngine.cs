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
            Enemy[] enemiesOnScreen = CreateStageArray(currentplayer.CurrentStage);
            for (int i = 0; i < enemiesOnScreen.Length; i++)
            {
                Console.WriteLine($"Level: {currentplayer.CurrentStage} - Enemy on Current Tile {i}: {enemiesOnScreen[i].Name} - HP = {enemiesOnScreen[i].HealthPointsMax}");
            }
            //Console.WriteLine($"Press Enter to continue");
            //Console.ReadLine();
            Movement.MoveThroughScreen(currentplayer, enemiesOnScreen);
        }

        public static Enemy[] CreateStageArray(int currentStage)
        {
            Enemy[] enemiesOnScreen = new Enemy[16];
            // This is assuming the game screen is always 16; will want to make this non-hardcoded later
            int totalMonsters = DiceRoller.RollDice(5, enemiesOnScreen.Length - 5);

            for (int i = 0; i < enemiesOnScreen.Length; ++i)
            {
                enemiesOnScreen[i] = EnemyMethods.CreateDummy();
            }

            while (totalMonsters > 0)
            {
                int tile = DiceRoller.RollDice(5, enemiesOnScreen.Length -1);
                if (enemiesOnScreen[tile].Name == "Empty Ground")
                {
                    enemiesOnScreen[tile - 1] = EnemyMethods.CreateRandomEnemy(currentStage);
                    enemiesOnScreen[tile - 1].StageTile = tile -1;
                    --totalMonsters;
                }
            }
            return enemiesOnScreen;
        }
    }
}