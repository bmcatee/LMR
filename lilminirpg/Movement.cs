using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lilminirpg
{

    internal class Movement
    {
        private static int _playerPos = 0;

        public async static Task PlayerPosition(int length, Enemy[] currentEnemies)
        {
            Player currentPlayer = SaveLoad.LoadGame();
            Console.WriteLine($"length = {length} || _playerPos = {_playerPos}");

            for (int i = 0; i < length; ++i)
            {
                Console.WriteLine($"{currentPlayer.Name} the {currentPlayer.PlayerClass.Name} at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {currentEnemies[_playerPos + 1].Name}");
                if (currentEnemies[_playerPos + 1].Name == "Empty Ground")
                {
                    await PlayerMovement(1, currentPlayer);
                }
                else 
                {
                    Enemy currentEnemy = currentEnemies[_playerPos +1];
                    while (currentEnemy.HealthPointsCurrent > 0)
                    {
                        Console.WriteLine($"Fight! The {currentEnemies[_playerPos + 1].Name} has {currentEnemy.HealthPointsCurrent} HP.");
                        await PlayerAttack(1, currentEnemies[_playerPos + 1].HealthPointsCurrent, currentEnemy, currentPlayer);
                    }
                    await PlayerMovement(1, currentPlayer);
                }
            }
            _playerPos = 0;
            currentPlayer.CurrentStage = currentPlayer.CurrentStage + 1;
            QuestEngine.InitStageArray(currentPlayer);
            Console.ReadLine();
        }

        public async static Task PlayerMovement(int delay, Player currentplayer)
        {
            ++_playerPos;
            SaveLoad.SaveGame(currentplayer);
            await Task.Delay(delay * 1000);
        }

        public async static Task PlayerAttack(int delay, int enemyhp, Enemy currentenemy, Player currentplayer)
        {
            Console.WriteLine($"Current enemy HP: {enemyhp} - PlayerPos: {_playerPos}");

                DiceRoller _diceRoller = new DiceRoller();
                int RollResults = (_diceRoller.RollDice(1, 5));
                enemyhp = enemyhp - RollResults;
                currentenemy.HealthPointsCurrent = enemyhp;
                Console.WriteLine($"You attack with your {currentplayer.WornWeapon.Name} for {RollResults} dmg! The {currentenemy.Name} now has {currentenemy.HealthPointsCurrent} HP.");
            if (enemyhp < 1) 
            {
                Console.WriteLine("You win!");
                Console.WriteLine($"{currentplayer.Name} the {currentplayer.PlayerClass.Name} at position {_playerPos}, moving to {_playerPos + 1}");
            }
            await Task.Delay(delay * 1000);
        }
    }
}
