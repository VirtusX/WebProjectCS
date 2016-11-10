namespace WebProjectCS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.games")]
    public partial class games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public games()
        {
            user_games = new HashSet<user_games>();
            user_games1 = new HashSet<user_games>();
        }

        [Key]
        public int game_id { get; set; }

        [Required]
        [StringLength(45)]
        public string game_name { get; set; }

        [Required]
        [StringLength(45)]
        public string game_authors { get; set; }

        [StringLength(200)]
        public string game_pic { get; set; }

        [StringLength(500)]
        public string game_about { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_games> user_games { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_games> user_games1 { get; set; }
    }
}
