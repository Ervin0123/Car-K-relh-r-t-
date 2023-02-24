using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Car_Backend.Models
{
    public partial class carcarelharitoContext : DbContext
    {
        public carcarelharitoContext()
        {
        }

        public carcarelharitoContext(DbContextOptions<carcarelharitoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EladoAuto> EladoAutos { get; set; }
        public virtual DbSet<Megrendelo> Megrendelos { get; set; }
        public virtual DbSet<Szolgaltata> Szolgaltatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=car-carelharito;user=root;password=;sslmode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EladoAuto>(entity =>
            {
                entity.HasKey(e => e.EladoId)
                    .HasName("PRIMARY");

                entity.ToTable("elado_auto");

                entity.Property(e => e.EladoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("elado_id");

                entity.Property(e => e.EladoAr)
                    .HasColumnType("int(20)")
                    .HasColumnName("elado_ar");

                entity.Property(e => e.EladoEvjarat)
                    .HasColumnType("int(4)")
                    .HasColumnName("elado_evjarat");

                entity.Property(e => e.EladoKep)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("elado_kep");

                entity.Property(e => e.EladoKilometer)
                    .HasColumnType("int(10)")
                    .HasColumnName("elado_kilometer");

                entity.Property(e => e.EladoRendszam)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("elado_rendszam");

                entity.Property(e => e.EladoTeljesitmeny)
                    .HasColumnType("int(11)")
                    .HasColumnName("elado_teljesitmeny");

                entity.Property(e => e.EladoUzemanyag)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("elado_uzemanyag");
            });

            modelBuilder.Entity<Megrendelo>(entity =>
            {
                entity.HasKey(e => e.MegrendId)
                    .HasName("PRIMARY");

                entity.ToTable("megrendelo");

                entity.HasIndex(e => e.SzolgId, "szolg_id");

                entity.Property(e => e.MegrendId)
                    .HasColumnType("int(11)")
                    .HasColumnName("megrend_id");

                entity.Property(e => e.MegrendEmail)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("megrend_email");

                entity.Property(e => e.MegrendIdopont)
                    .HasColumnType("date")
                    .HasColumnName("megrend_idopont")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MegrendMegjegyzes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("megrend_megjegyzes");

                entity.Property(e => e.MegrendNev)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("megrend_nev");

                entity.Property(e => e.MegrendRendszam)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("megrend_rendszam");

                entity.Property(e => e.MegrendTel)
                    .HasColumnType("int(11)")
                    .HasColumnName("megrend_tel");

                entity.Property(e => e.SzolgId)
                    .HasColumnType("int(11)")
                    .HasColumnName("szolg_id");

                entity.HasOne(d => d.Szolg)
                    .WithMany(p => p.Megrendelos)
                    .HasForeignKey(d => d.SzolgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("megrendelo_ibfk_2");
            });

            modelBuilder.Entity<Szolgaltata>(entity =>
            {
                entity.HasKey(e => e.SzolgId)
                    .HasName("PRIMARY");

                entity.ToTable("szolgaltatas");

                entity.Property(e => e.SzolgId)
                    .HasColumnType("int(11)")
                    .HasColumnName("szolg_id");

                entity.Property(e => e.SzolgAr)
                    .HasColumnType("int(20)")
                    .HasColumnName("szolg_ar");

                entity.Property(e => e.SzolgIdotartam)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("szolg_idotartam");

                entity.Property(e => e.SzolgNev)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("szolg_nev");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
