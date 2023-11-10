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

        public async static void PlayerPosition(int length, Enemy[] currentEnemies)
        {
            Console.WriteLine($"length = {length} || _playerPos = {_playerPos}");

            for (int i = 0; i < length; ++i)
            {
                if (currentEnemies[_playerPos + 1].CharacterName == "Empty Ground")
                {
                    Console.WriteLine($"Player at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {currentEnemies[_playerPos + 1].CharacterName}");
                }
                else 
                {
                    Enemy currentEnemy = currentEnemies[_playerPos +1];
                    while (currentEnemy.HealthPointsCurrent > 0)
                    {
                        Console.WriteLine($"Player at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {currentEnemy.CharacterName}");
                        Console.WriteLine($"Fight! The {currentEnemies[_playerPos + 1].CharacterName} has {currentEnemy.HealthPointsCurrent} HP.");
                        await PlayerAttack(0, currentEnemies[_playerPos + 1].HealthPointsCurrent, currentEnemy);
                    }
                }
                await PlayerMovement(0);
            }
            _playerPos = 0;
            QuestEngine.CurrentGameLevel = ++QuestEngine.CurrentGameLevel;
            QuestEngine.InitStageArray();
            Console.ReadKey();
        }

        public async static Task PlayerMovement(int delay)
        {
            await Task.Delay(delay * 1000);
            ++_playerPos;
        }

        public async static Task PlayerAttack(int delay, int enemyhp, Enemy currentenemy)
        {
            Console.WriteLine($"Current enemy HP: {enemyhp} - PlayerPos: {_playerPos}");

            if (enemyhp >= 1)
            {
                DiceRoller _diceRoller = new DiceRoller();
                int RollResults = (_diceRoller.RollDice(1, 5));
                enemyhp = enemyhp - RollResults;
                currentenemy.HealthPointsCurrent = enemyhp;
                Console.WriteLine($"You attack for {RollResults} dmg! The {currentenemy.CharacterName} now has {currentenemy.HealthPointsCurrent} HP.");
                await Task.Delay(delay * 1000);
            }
            else if (enemyhp < 1) 
            {
                Console.WriteLine("You win!");
                await Task.Delay(delay * 1000);
            }
        }
    }
}
