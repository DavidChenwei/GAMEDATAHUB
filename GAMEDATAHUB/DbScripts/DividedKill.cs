
namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DividedKill
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DividedKillID { get; set; }

        [Required]
        public int HeroID { get; set; }

        public int? MultiKills { get; set; }

        public int? HeadShotAmount { get; set; }

        public int? RoadKills { get; set; }

        public int? MeleeKills { get; set; }

        public int? VechileKills { get; set; }

        public int? GrenadesKills { get; set; }

        public int? HipfireKills { get; set; }

        public int? AIKills { get; set; }

        public int? HumanKills { get; set; }

        public int? ScopedKills { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }

    }
}
