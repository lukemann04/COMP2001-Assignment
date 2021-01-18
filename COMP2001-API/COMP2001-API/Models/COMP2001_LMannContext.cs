using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class COMP2001_LMannContext : DbContext
    {
        public COMP2001_LMannContext()
        {
        }

        public COMP2001_LMannContext(DbContextOptions<COMP2001_LMannContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseworkPassword> CourseworkPasswords { get; set; }
        public virtual DbSet<CourseworkSession> CourseworkSessions { get; set; }
        public virtual DbSet<CourseworkUser> CourseworkUsers { get; set; }
        public virtual DbSet<LogInCount> LogInCounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_LMann;User Id=LMann; Password=MhrI147+");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<CourseworkPassword>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_Password");

                entity.ToTable("COURSEWORK_Passwords");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.ChangeTime).HasColumnType("datetime");

                entity.Property(e => e.OldPassword)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PasswordID");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.CourseworkPassword)
                    .HasForeignKey<CourseworkPassword>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COURSEWOR__UserI__74AE54BC");
            });

            modelBuilder.Entity<CourseworkSession>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("pk_Session");

                entity.ToTable("COURSEWORK_Sessions");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.SessionTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseworkSessions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__COURSEWOR__UserI__778AC167");
            });

            modelBuilder.Entity<CourseworkUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_User");

                entity.ToTable("COURSEWORK_Users");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogInCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LogInCount");

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
