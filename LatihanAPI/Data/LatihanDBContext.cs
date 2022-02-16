using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LatihanAPI.Models;

namespace LatihanAPI.Data
{
    public partial class LatihanDBContext : DbContext
    {
        public LatihanDBContext()
        {
        }

        public LatihanDBContext(DbContextOptions<LatihanDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MMateri> MMateris { get; set; }
        public virtual DbSet<MUser> MUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Materi_Description");

                entity.Property(e => e.MateriTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Materi_Title");
            });

            modelBuilder.Entity<MUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.ToTable("M_User");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
