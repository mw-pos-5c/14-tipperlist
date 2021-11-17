using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TipsDb
{
    public partial class TipsContext : DbContext
    {
        public TipsContext()
        {
        }

        public TipsContext(DbContextOptions<TipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MatchTip> MatchTips { get; set; }
        public virtual DbSet<MatchWithResult> MatchWithResults { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Tipper> Tippers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("data source=C:\\_PR\\CSharp\\PR5\\Tips\\TipsDb\\tips.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchTip>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.MatchWithResult)
                    .WithMany(p => p.MatchTips)
                    .HasForeignKey(d => d.MatchWithResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tipper)
                    .WithMany(p => p.MatchTips)
                    .HasForeignKey(d => d.TipperId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MatchWithResult>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Datum)
                    .IsRequired()
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Team1Id).HasColumnName("Team1_Id");

                entity.Property(e => e.Team2Id).HasColumnName("Team2_Id");

                entity.HasOne(d => d.Team1)
                    .WithMany(p => p.MatchWithResultTeam1)
                    .HasForeignKey(d => d.Team1Id);

                entity.HasOne(d => d.Team2)
                    .WithMany(p => p.MatchWithResultTeam2)
                    .HasForeignKey(d => d.Team2Id);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tipper>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
