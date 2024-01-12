namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeaponGroup")]
    public partial class WeaponGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeaponGroupID { get; set; }

        [Required]
        public int HeroID { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        [Required]
        [StringLength(50)]
        public string Id { get; set; }

        public int? Kills { get; set; }

        public int? Damage { get; set; }

        public int? BodyKills { get; set; }

        public int? HeadshotKills { get; set; }

        public int? HipfireKills { get; set; }

        public int? MultiKills { get; set; }

        public decimal? Accuracy { get; set; }

        public decimal? KillsPerMinute { get; set; }

        public decimal? DamagePerMinute { get; set; }

        public decimal? Headshots { get; set; }

        public decimal? HitVKills { get; set; }

        public int? ShotsHit { get; set; }

        public int? ShotsFired { get; set; }

        public int? Spawns { get; set; }

        public int? TimeEquipped { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }
}
