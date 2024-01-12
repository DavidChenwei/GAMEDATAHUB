namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HeroOverView")]
    public partial class HeroOverView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HeroOverViewId { get; set; }

        [Required]
        public int HeroID { get; set; }

        [Required]
        [StringLength(20)]
        public string BestClass { get; set; }

        public decimal? HumanPercentage { get; set; }

        public int? Kills { get; set; }

        public int? Deaths { get; set; }

        public int? Wins { get; set; }

        public int? Losses { get; set; }

        public decimal? KillsPerMinute { get; set; }

        public decimal? DamagePerMinute { get; set; }

        public decimal? KillsPerMatch { get; set; }

        public decimal? DamagePerMatch { get; set; }

        public int? HeadShots { get; set; }

        public decimal? WinPercent { get; set; }

        public decimal? HeadShotrate { get; set; }

        public decimal? KillDeath { get; set; }

        public decimal? InfantryKillDeath { get; set; }

        public int? Damage { get; set; }

        [Required]
        [StringLength(30)]
        public string TimePlayed { get; set; }

        public decimal? Accuracy { get; set; }

        public int? Revives { get; set; }

        public int? Heals { get; set; }

        public int? Resupplies { get; set; }

        public int? Repairs { get; set; }

        public int? SquadmateRevive { get; set; }

        public int? SquadmateRespawn { get; set; }

        public int? ThrownThrowables { get; set; }

        public int? GadgetsDestoyed { get; set; }

        public int? CallIns { get; set; }

        public int? PlayerTakeDowns { get; set; }

        public int? MatchesPlayed { get; set; }

        public int? SecondsPlayed { get; set; }

        public int? BestSquad { get; set; }

        public int? TeammatesSupported { get; set; }

        public int? SaviorKills { get; set; }

        public int? ShotsFired { get; set; }

        public int? ShotsHit { get; set; }

        public int? KillAssists { get; set; }

        public int? VehiclesDestroyed { get; set; }

        public int? EnemiesSpotted { get; set; }
      
        public int? Mvp { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }
}
