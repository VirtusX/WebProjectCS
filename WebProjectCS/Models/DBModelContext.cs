namespace WebProjectCS {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModelContext:DbContext {
        public DBModelContext()
            : base("name=DBContext") {
            }

        public virtual DbSet<games> games { get; set; }
        public virtual DbSet<user_games> user_games { get; set; }
        public virtual DbSet<User> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<games>()
                .Property(e => e.game_name)
                .IsUnicode(false);

            modelBuilder.Entity<games>()
                .Property(e => e.game_authors)
                .IsUnicode(false);

            modelBuilder.Entity<games>()
                .Property(e => e.game_pic)
                .IsUnicode(false);

            modelBuilder.Entity<games>()
                .Property(e => e.game_about)
                .IsUnicode(false);

            modelBuilder.Entity<games>()
                .HasMany(e => e.user_games)
                .WithRequired(e => e.games)
                .HasForeignKey(e => e.game_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<games>()
                .HasMany(e => e.user_games1)
                .WithRequired(e => e.games1)
                .HasForeignKey(e => e.game_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_pic)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_location)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_about)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.user_games)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.user_games1)
                .WithRequired(e => e.users1)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
            }
        }
    }
