namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ribbon")]
    public partial class Ribbon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RibbonID { get; set; }

        [Required]
        public int HeroID { get; set; }

        public int? Total { get; set; }

        public int? Squad { get; set; }

        public int? Combat { get; set; }

        public int? Intel { get; set; }

        public int? Objective { get; set; }

        public int? Support { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }
}
