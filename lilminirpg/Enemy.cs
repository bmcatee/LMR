﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Enemy : Character
    {
        public string MonsterPerk1 { get; set; } = "";
        public string MonsterPerk2 { get; set; } = "";
        public string MonsterPerk3 { get; set; } = "";
        public string AttackStat1 { get; set; } = "";
        public int AttackPercent1 { get; set; } = 0;
        public string AttackStat2 { get; set; } = "";
        public int AttackPercent2 { get; set; } = 0;
        public int GoldDropped { get; set; } = 0;
        public int XPDropped { get; set; } = 0;
        public string MonsterFamily { get; set; } = "";
        public string MonsterEnvironment { get; set; } = "";
        public string MonsterRank { get; set; } = "";
    }
    public class EnemyMethods
    {
        public class EnemiesList
        {
            public List<EnemiesList>? Enemies { get; set; }
        }
        public static List<Enemy> FetchEnemies()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "EnemiesList.json";
            List<Enemy> playerEnemies = new List<Enemy>();
            using (StreamReader sr = new StreamReader(Path.Combine(folder, filename)))
            {
                while (!sr.EndOfStream)
                {
                    string json = sr.ReadToEnd();
                    playerEnemies = JsonSerializer.Deserialize<List<Enemy>>(json);
                }
            }
            return playerEnemies;
        }
        // This makes a random enemy out of all the enemies available in the list
        // Eventually this will spawn enemies based on groupings (family, rank, environment, etc.)
        // This also should be moved into the DB
        public static Enemy CreateRandomEnemy(int stagelevel)
        {
            List<Enemy> enemieslist = FetchEnemies();
            Enemy currentenemy = new Enemy();
            int enemylistposition = DiceRoller.RollDice(0, enemieslist.Count);
            currentenemy = enemieslist[enemylistposition];
            currentenemy = SetEnemyStats(currentenemy, stagelevel);
            return currentenemy;
        }
        // Makes a patch of "Empty Ground" dummy data
        public static Enemy CreateDummy()
        {
            List<Enemy> enemieslist = FetchEnemies();
            Enemy currentenemy = enemieslist[0];
            return currentenemy;
        }
        // Sets the enemy's stats & level to the current stage level
        public static Enemy SetEnemyStats(Enemy currentenemy, int stagelevel)
        {
            currentenemy.CurrentLevel = stagelevel;
            currentenemy.CurrentStage = stagelevel;
            currentenemy.HealthPointsMax = currentenemy.HealthPointsMax * stagelevel;
            currentenemy.HealthPointsCurrent = currentenemy.HealthPointsMax;
            currentenemy.StatStrength = currentenemy.StatStrength * stagelevel;
            currentenemy.StatDexterity = currentenemy.StatDexterity * stagelevel;
            currentenemy.StatIntelligence = currentenemy.StatIntelligence * stagelevel;
            currentenemy.StatLuck = currentenemy.StatLuck * stagelevel;
            currentenemy.XPDropped = currentenemy.XPDropped * stagelevel;
            return currentenemy;
        }
    }
}
