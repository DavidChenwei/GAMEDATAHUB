namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeaponItem")]
    public partial class WeaponItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeaponItemId { get; set; }

        [Required]
        public int WeaponID { get; set; }

        public int? HeroID { get; set; }

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

        [ForeignKey("WeaponID")]
        public virtual Weapon Weapon { get; set; }
    }
}
