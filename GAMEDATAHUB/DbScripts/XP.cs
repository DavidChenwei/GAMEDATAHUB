namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XP")]
    public partial class XP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int XPId { get; set; }

        [Required]
        public int HeroID { get; set; }

        public int? Total { get; set; }

        public int? Performance { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }
}
