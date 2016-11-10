namespace WebProjectCS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.user_games")]
    public partial class user_games
    {
        [Key]
        public int g_u_id { get; set; }

        public int user_id { get; set; }

        public int game_id { get; set; }

        public virtual games games { get; set; }

        public virtual games games1 { get; set; }

        public virtual User users { get; set; }

        public virtual User users1 { get; set; }
    }
}
