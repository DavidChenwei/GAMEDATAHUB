
namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rank")]
    public partial class Rank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RankID { get; set; }

        public int? HeroID { get; set; }

        [Required]
        public decimal KDRank { get; set; }

        [Required]
        public decimal HSRank { get; set; }

        [Required]
        public decimal WinPercentRank { get; set; }

        [Required]
        public decimal HumanKDRank { get; set; }

        [Required]
        public decimal DeathRank { get; set; }

        [Required]
        public decimal KPMRank { get; set; }

        [Required]
        public decimal KPMatchRank { get; set; }

        [Required]
        public decimal WinRank { get; set; }

        [Required]
        public decimal LostRank { get; set; }

        [Required]
        public decimal DamageRank { get; set; }

        [Required]
        public decimal DPMRank { get; set; }

        [Required]
        public decimal VehiclesDestroyedRank { get; set; }

        [Required]
        public decimal HSAmountRank { get; set; }

        [Required]
        public decimal RoadKillRank { get; set; }

        [Required]
        public decimal MeleeKillRank { get; set; }

        [Required]
        public decimal VehicleKillRank { get; set; }

        [Required]
        public decimal ScopedKillRank { get; set; }

        [Required]
        public decimal HipfireKillRank { get; set; }

        [Required]
        public decimal HumanKillRank { get; set; }

        [Required]
        public decimal AIKillRank { get; set; }

        [Required]
        public decimal ObjectiveTimeRank { get; set; }

        [Required]
        public decimal DisarmedObjectRank { get; set; }

        [Required]
        public decimal CapturedObjectiRank { get; set; }

        [Required]
        public decimal ObjectivesDeutralizeRank { get; set; }

        [Required]
        public decimal SectorsDefendeRank { get; set; }

        [Required]
        public decimal SectorsCapturedRank { get; set; }

        [Required]
        public decimal AttackedObjectRank { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }

}