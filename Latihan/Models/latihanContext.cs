using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Latihan.Models
{
    public partial class latihanContext : DbContext
    {
        public latihanContext()
        {
        }

        public latihanContext(DbContextOptions<latihanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MMateri> MMateri { get; set; }
        public virtual DbSet<MUser> MUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LatihanDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MMateri>(entity =>
            {
                entity.HasKey(e => e.MateriId);

                entity.ToTable("M_Materi");

                entity.Property(e => e.MateriId).HasColumnName("Materi_ID");

                entity.Property(e => e.MateriDescription)
                    .HasColumnName("Materi_Description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MateriTitle)
                    .HasColumnName("Materi_Title")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("M_User");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
