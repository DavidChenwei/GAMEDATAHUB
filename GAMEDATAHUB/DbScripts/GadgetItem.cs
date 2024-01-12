namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GadgetItem")]
    public partial class GadgetItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GadgetItemId { get; set; }

        [Required]
        public int? GadgetID { get; set; }

        [Required]
        public int HeroID { get; set; }
       
        public int? Kills { get; set; }
       
        public int? Spawns { get; set; }

        public int? Damage { get; set; }

        public int? Uses { get; set; }

        public int? Multikills { get; set; }

        public int? VehiclesDestroyedWith { get; set; }

        public decimal? KPM { get; set; }

        public decimal? DPM { get; set; }

        public int? SecondsPlayed { get; set; }

        [ForeignKey("GadgetID")]
        public virtual Gadget Gadget { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }
}
