namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameMode")]
    public partial class GameMode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GameMode()
        {
            GameModeItem = new HashSet<GameModeItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameModeID { get; set; }

        [Required]
        [StringLength(50)]
        public string GamemodeName { get; set; }

        [Required]
        [StringLength(255)]
        public string Images { get; set; }

        [Required]
        [StringLength(50)]
        public string Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameModeItem> GameModeItem { get; set; }
    }
}
