namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GObjectItem")]
    public partial class GObjectItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GObjectItemId { get; set; }

        [Required]
        public int HeroID { get; set; }

        [Required]
        public int GObjectID { get; set; }

        public int? Total { get; set; }

        public int? Attacked { get; set; }

        public int? Defended { get; set; }

        [ForeignKey("GObjectID")]
        public virtual GObject GObject { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }
}
