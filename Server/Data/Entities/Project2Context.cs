using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Entities
{
    public partial class Project2Context : DbContext
    {
        public Project2Context()
        {
        }

        public Project2Context(DbContextOptions<Project2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<LeaderboardLine> LeaderboardLines { get; set; }
        public virtual DbSet<PathStep> PathSteps { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FriendNavigation)
                    .WithMany(p => p.FriendFriendNavigations)
                    .HasForeignKey(d => d.FriendId)
                    .HasConstraintName("FK_Friends_Friend");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Friends_User");
            });

            modelBuilder.Entity<LeaderboardLine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.LeaderboardLines)
                    .HasForeignKey(d => d.RaceId)
                    .HasConstraintName("FK_Leaderboard_Races");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LeaderboardLines)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Leaderboard_Users");
            });

            modelBuilder.Entity<PathStep>(entity =>
            {
                entity.ToTable("PathStep");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CurrentPage)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LeaderboardId).HasColumnName("LeaderboardID");

                entity.HasOne(d => d.Leaderboard)
                    .WithMany(p => p.PathSteps)
                    .HasForeignKey(d => d.LeaderboardId)
                    .HasConstraintName("FK_PathStep_Leaderboard");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasIndex(e => e.Title, "UQ__Races__2CB664DC65B01FEA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.EndPage)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.StartPage)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Races_AuthorId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E48C0116FE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
