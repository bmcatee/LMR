using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Character
    {

        [Key]
        public int CharacterKey { get; set; }
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public int CurrentStage { get; set; } = 0;
        public int StageTile { get; set; } = 0;
        public int CurrentLevel { get; set; } = 0;
        public int HealthPointsMax { get; set; } = 0;
        public int HealthPointsCurrent { get; set; } = 0;
        public int StatStrength { get; set; } = 0;
        public int StatDexterity { get; set; } = 0;
        public int StatIntelligence { get; set; } = 0;
        public int StatLuck { get; set; } = 0;
        public int StatMoveSpeed { get; set; } = 0;
        public int StatAttackSpeed { get; set; } = 0;
        public int FrameMove { get; set; } = 0;
        public int FrameAttack { get; set; } = 0;
        public string? AttackWord { get; set; } = "";
    }

    public class Player : Character
    {
        public int XPCurrent { get; set; } = 0;
        public int XPToLevel { get; set; } = 20;
        public int XPBanked { get; set; } = 0;
        public int GoldCurrent { get; set; } = 0;
        public int TilesMoved { get; set; } = 0;
        public int MaximumStage { get; set; } = 0;
        public Job? PlayerJob { get ; set; }
        public Weapon? WornWeapon { get; set; }
//        public DataLists.Clothing WornClothing { get; set; }
        public Accessory? WornAccessory { get; set; }
    }

    public class PlayerMethods
    {
        public class CharacterStatList
        {
            public ICollection<CharacterStatList>? CharacterStats { get; set; }
        }

        public class PlayerContext: DbContext
        {
            public PlayerContext(): base()
            {

            }
            public DbSet<Player> Players { get; set; }
        }

        public static Player PlayerLevelUp(Player currentplayer)
        {
            currentplayer.XPBanked += currentplayer.XPCurrent;
            currentplayer.XPCurrent = 0;
            currentplayer.XPToLevel = 20 * currentplayer.CurrentLevel;
            currentplayer.HealthPointsMax += currentplayer.PlayerJob.HealthPointsGrowth;
            currentplayer.HealthPointsCurrent = currentplayer.HealthPointsCurrent + currentplayer.PlayerJob.HealthPointsGrowth;
            currentplayer.StatStrength += currentplayer.PlayerJob.StrengthGrowth;
            currentplayer.StatDexterity += currentplayer.PlayerJob.DexterityGrowth;
            currentplayer.StatIntelligence += currentplayer.PlayerJob.IntelligenceGrowth;
            currentplayer.StatLuck += currentplayer.PlayerJob.LuckGrowth;
            return currentplayer;
        }
    }
}
