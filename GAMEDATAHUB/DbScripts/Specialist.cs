namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Specialist")]
    public partial class Specialist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialist()
        {
            SpecialistItem = new HashSet<SpecialistItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecialistID { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }

        [Required]
        [StringLength(50)]
        public string CharacterName { get; set; }

        [Required]
        [StringLength(50)]
        public string StatName { get; set; }

        [Required]
        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [StringLength(255)]
        public string AvatarImage1 { get; set; }

        [Required]
        [StringLength(255)]
        public string AvatarImage2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecialistItem> SpecialistItem { get; set; }
    }
}
