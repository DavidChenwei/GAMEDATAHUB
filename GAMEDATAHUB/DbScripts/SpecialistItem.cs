namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpecialistItem")]
    public partial class SpecialistItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecialistItemID { get; set; }

        [Required]
        public int SpecialistID { get; set; }

        [Required]
        public int HeroID { get; set; }

        public int? Kills { get; set; }

        public int? Deaths { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? KMP { get; set; }

        public int? Spawns { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? KillDeath { get; set; }

        public int? Revives { get; set; }

        public int? Assists { get; set; }

        public int? HazardZoneStreaks { get; set; }

        public int? SecondsPlayed { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }

        [ForeignKey("SpecialistID")]
        public virtual Specialist Specialist { get; set; }
    }
}
