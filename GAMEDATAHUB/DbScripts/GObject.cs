namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GObject")]
    public partial class GObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GObjectID { get; set; }

        [Required]
        public int HeroID { get; set; }

        public int? ObjectTotal { get; set; }

        public int? AttackedTotal { get; set; }

        public int? DefendedTotal { get; set; }

        public int? Defused { get; set; }

        public int? Destroyed { get; set; }

        public int? Armed { get; set; }

        public int? Captured { get; set; }

        public int? Neutralized { get; set; }

        public int? AttackedSector { get; set; }

        public int? DefendedSector { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }

    }
}
