namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleItem")]
    public partial class VehicleItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleItemId { get; set; }

        [Required]
        public int VehicleID { get; set; }

        [Required]
        public int HeroID { get; set; }

        public int? Kills { get; set; }

        public int? Damage { get; set; }

        public int? Roadkills { get; set; }

        public int? Spawns { get; set; }

        public int? DriverAssists { get; set; }

        public int? PassengerAssists { get; set; }

        public int? Multikills { get; set; }

        public int? DistanceTraveled { get; set; }

        public decimal? KillsPerMinute { get; set; }

        public int? VehiclesDestroyedWith { get; set; }

        public int? Assists { get; set; }

        public int? Callins { get; set; }

        public int? DamageTo { get; set; }

        public int? Destroyed { get; set; }

        public int? Timeln { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }

        [ForeignKey("VehicleID")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
