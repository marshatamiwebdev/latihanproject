using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LatihanAPI.Models;

#nullable disable

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

        public virtual DbSet<Mmateri> Mmateris { get; set; }
        public virtual DbSet<Mstudent> Mstudents { get; set; }
        public virtual DbSet<Mteacher> Mteachers { get; set; }
        public virtual DbSet<Muser> Musers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LatihanDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mmateri>(entity =>
            {
                entity.HasKey(e => e.MateriId)
                    .HasName("PK_M_Materi");

                entity.ToTable("MMateri");

                entity.Property(e => e.MateriId).HasColumnName("Materi_ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MateriDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Materi_Description");

                entity.Property(e => e.MateriTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Materi_Title");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Mstudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK_M_Student");

                entity.ToTable("MStudent");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StudentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Mteacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.ToTable("MTeacher");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Muser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.ToTable("MUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
