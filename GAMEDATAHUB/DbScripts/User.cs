namespace GAMEDATAHUB.DbScripts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public int? HeroID { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserEmail { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserHashedPassword { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserSalt { get; set; }

        [Required]
        public bool IsPremium { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? DeleteTime { get; set; }

        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
    }
}