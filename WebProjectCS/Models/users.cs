namespace WebProjectCS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.users")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            user_games = new HashSet<user_games>();
            user_games1 = new HashSet<user_games>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(45)]
        public string user_name { get; set; }

        [Required]
        [StringLength(45)]
        public string user_password { get; set; }

        [Required]
        [StringLength(45)]
        public string user_email { get; set; }

        [StringLength(100)]
        public string user_pic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? user_birthday { get; set; }

        [StringLength(100)]
        public string user_location { get; set; }

        [StringLength(300)]
        public string user_about { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_games> user_games { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_games> user_games1 { get; set; }
    }
}
