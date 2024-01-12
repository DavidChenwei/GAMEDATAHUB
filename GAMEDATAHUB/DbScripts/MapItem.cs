namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MapItem")]
    public partial class MapItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MapItemId { get; set; }

        [Required]
        public int MapID { get; set; }

        [Required]
        public int HeroID { get; set; }

        public int? Wins { get; set; }

        public int? Losses { get; set; }

        public int? Matches { get; set; }

        public decimal? WinPercent { get; set; }

        public int? SecondsPlayed { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
        [ForeignKey("MapID")]
        public virtual Map Map { get; set; }
    }
}
