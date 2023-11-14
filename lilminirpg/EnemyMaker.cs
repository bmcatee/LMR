using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class EnemyMaker
    {
        public Enemy MakeEnemy(int enemyBaseID)
        {
            Enemy createdEnemy = new Enemy();

            createdEnemy.CurrentLevel = 0;
            for (int i = 0; i < DataLists.EnemiesList.GetLength(1); ++i)
            {
                SetStat(enemyBaseID, i, createdEnemy);
            }
            return createdEnemy;
        }
        private static void SetStat(int enemyBaseID, int statPosition, Enemy createdEnemy)
        {
            switch (statPosition)
            {
                case 0:
                    createdEnemy.CharacterName = DataLists.EnemiesList[enemyBaseID, statPosition];
//                    Console.WriteLine($"Creating: {createdEnemy.CharacterName}");
                    break;
                case 1:
                    // Nothing to see here...
                    break;
                case 2:
                    createdEnemy.HealthPointsMax = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
                    createdEnemy.HealthPointsCurrent = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"HPMax: {createdEnemy.HealthPointsMax} - HPCurrent: {createdEnemy.HealthPointsCurrent}");
                    break;
                case 3:
                    createdEnemy.StatStrength = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"Str: {createdEnemy.StatStrength}");
                    break;
                case 4:
                    createdEnemy.StatAtkSpeed = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"AtkSpd: {createdEnemy.StatAtkSpeed}");
                    break;
                case 5:
                    createdEnemy.MonsterPerk1 = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"MPerk1: {createdEnemy.MonsterPerk1}");
                    break;
                case 6:
                    createdEnemy.MonsterPerk2 = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"MPerk2: {createdEnemy.MonsterPerk2}");
                    break;
                case 7:
                    createdEnemy.MonsterPerk3 = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"MPerk3: {createdEnemy.MonsterPerk3}");
                    break;
                case 8:
                    createdEnemy.GoldDropped = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"GoldDropped:{createdEnemy.GoldDropped}");
                    break;
                case 9:
                    createdEnemy.XPDropped = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"XPDropped: {createdEnemy.XPDropped}");
                    break;
                case 10:
                    createdEnemy.MonsterFamily = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"MonsterFam: {createdEnemy.MonsterFamily}");
                    break;
                case 11:
                    createdEnemy.MonsterEnvironment = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"MonsterEnv: {createdEnemy.MonsterEnvironment}");
                    break;
                case 12:
                    createdEnemy.MonsterRank = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
//                    Console.WriteLine($"MonsterRank: {createdEnemy.MonsterRank}");
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }
         }
    }
}

