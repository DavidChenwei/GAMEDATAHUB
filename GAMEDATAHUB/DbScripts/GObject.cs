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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GObject()
        {
            GObjectItem = new HashSet<GObjectItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GObjectID { get; set; }

        [Required]
        public int HerolD { get; set; }

        public int? Armed { get; set; }

        public int? Captured { get; set; }

        public int? Neutralized { get; set; }

        public int? Destroyed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GObjectItem> GObjectItem { get; set; }
    }
}
