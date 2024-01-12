namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameModeItem")]
    public partial class GameModeItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameModeItemId { get; set; }

        [Required]
        public int GameModeID { get; set; }

        [Required]
        public int HeroID { get; set; }

        public int? Kills { get; set; }

        public int? Assists { get; set; }

        public int? Revives { get; set; }

        public int? BestSquad { get; set; }

        public int? Wins { get; set; }

        public int? Losses { get; set; }

        public int? Mvp { get; set; }

        public int? Matches { get; set; }

        public int? SectorDefend { get; set; }

        public int? ObjectivesArmed { get; set; }

        public int? ObjectivesDisarmed { get; set; }

        public int? ObjectivesDefended { get; set; }

        public int? ObjectivesDestroyed { get; set; }

        public int? ObjetiveTime { get; set; }

        public decimal? KPM { get; set; }

        public decimal? WinPercent { get; set; }

        public int? SecondsPlayed { get; set; }

        [ForeignKey("GameModeID")]
        public virtual GameMode GameMode { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }
}
