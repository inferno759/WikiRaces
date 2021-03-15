using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dal
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
        public virtual DbSet<Leaderboard> Leaderboards { get; set; }
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
                    .HasConstraintName("FK__Friends__FriendI__6E01572D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Friends__UserID__6D0D32F4");
            });

            modelBuilder.Entity<Leaderboard>(entity =>
            {
                entity.ToTable("Leaderboard");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Leaderboards)
                    .HasForeignKey(d => d.RaceId)
                    .HasConstraintName("FK__Leaderboa__RaceI__66603565");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Leaderboards)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Leaderboa__UserI__6754599E");
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
                    .HasConstraintName("FK__PathStep__Leader__6A30C649");
            });

            modelBuilder.Entity<Race>(entity =>
            {
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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Races__AuthorID__5EBF139D");
            });

            modelBuilder.Entity<User>(entity =>
            {
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
