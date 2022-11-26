using EnocaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Persistence
{
    public partial class EnocaContext : DbContext
    {
        public EnocaContext()
        {
        }

        public EnocaContext(DbContextOptions<EnocaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FilmTbl> FilmTbls { get; set; }

        public virtual DbSet<GösterimTbl> GösterimTbls { get; set; }

        public virtual DbSet<SalonTbl> SalonTbls { get; set; }
        public virtual DbSet<Admin_Tbl> AdminTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=.;Database=Enoca;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmTbl>(entity =>
            {
                entity.HasKey(e => e.FilmId);

                entity.ToTable("Film_tbl");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");
                entity.Property(e => e.FilmAd).HasMaxLength(100);
                entity.Property(e => e.FilmYapımyıl).HasMaxLength(50);
            });

            modelBuilder.Entity<GösterimTbl>(entity =>
            {
                entity.ToTable("Gösterim_tbl");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.FilmId).HasColumnName("FilmID");
                entity.Property(e => e.GösterimTarihi).HasMaxLength(50);
                entity.Property(e => e.SalonId).HasColumnName("SalonID");

                entity.HasOne(d => d.Film).WithMany(p => p.GösterimTbls)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_Gösterim_tbl_Film_tbl");

                entity.HasOne(d => d.Salon).WithMany(p => p.GösterimTbls)
                    .HasForeignKey(d => d.SalonId)
                    .HasConstraintName("FK_Gösterim_tbl_Salon_tbl");
            });

            modelBuilder.Entity<SalonTbl>(entity =>
            {
                entity.HasKey(e => e.SalonId);

                entity.ToTable("Salon_tbl");

                entity.Property(e => e.SalonId).HasColumnName("SalonID");
                entity.Property(e => e.SalonAd).HasMaxLength(50);
            });

            modelBuilder.Entity<Admin_Tbl>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("Admin_tbl");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");
                entity.Property(e => e.AdminName).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
