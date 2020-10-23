using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentalKendaraan_NIM.Models
{
    public partial class Rental_KendaraanContext : DbContext
    {
        public Rental_KendaraanContext()
        {
        }

        public Rental_KendaraanContext(DbContextOptions<Rental_KendaraanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Jaminan> Jaminan { get; set; }
        public virtual DbSet<JenisKendaraan> JenisKendaraan { get; set; }
        public virtual DbSet<Kendaraan> Kendaraan { get; set; }
        public virtual DbSet<KondisiKendaraan> KondisiKendaraan { get; set; }
        public virtual DbSet<Peminjaman> Peminjaman { get; set; }
        public virtual DbSet<Pengembalian> Pengembalian { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdGender).HasColumnName("ID_Gender");

                entity.Property(e => e.NamaCustomer)
                    .HasColumnName("Nama_Customer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nik)
                    .HasColumnName("NIK")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_HP")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.IdGender);

                entity.Property(e => e.IdGender)
                    .HasColumnName("ID_Gender")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaGender)
                    .HasColumnName("Nama_Gender")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithOne(p => p.Gender)
                    .HasForeignKey<Gender>(d => d.IdGender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gender_Customer");
            });

            modelBuilder.Entity<Jaminan>(entity =>
            {
                entity.HasKey(e => e.IdJaminan);

                entity.Property(e => e.IdJaminan)
                    .HasColumnName("ID_Jaminan")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaJaminan)
                    .HasColumnName("Nama_Jaminan")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdJenisKendaraan);

                entity.ToTable("Jenis_Kendaraan");

                entity.Property(e => e.IdJenisKendaraan)
                    .HasColumnName("ID_Jenis_Kendaraan")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaJenisKendaraan)
                    .HasColumnName("Nama_Jenis_Kendaraan")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKendaraan);

                entity.Property(e => e.IdKendaraan)
                    .HasColumnName("ID_Kendaraan")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdJenisKendaraan).HasColumnName("ID_Jenis_Kendaraan");

                entity.Property(e => e.Ketersediaan)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NamaKendaraan)
                    .HasColumnName("Nama_Kendaraan")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NoPolisi)
                    .HasColumnName("No_Polisi")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoStnk)
                    .HasColumnName("No_STNK")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKendaraanNavigation)
                    .WithOne(p => p.Kendaraan)
                    .HasForeignKey<Kendaraan>(d => d.IdKendaraan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kendaraan_Jenis_Kendaraan");
            });

            modelBuilder.Entity<KondisiKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKondisi);

                entity.ToTable("Kondisi_Kendaraan");

                entity.Property(e => e.IdKondisi)
                    .HasColumnName("ID_Kondisi")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaKondisi)
                    .HasColumnName("Nama_Kondisi")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKondisiNavigation)
                    .WithOne(p => p.KondisiKendaraan)
                    .HasForeignKey<KondisiKendaraan>(d => d.IdKondisi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kondisi_Kendaraan_Pengembalian");
            });

            modelBuilder.Entity<Peminjaman>(entity =>
            {
                entity.HasKey(e => e.IdPeminjaman);

                entity.Property(e => e.IdPeminjaman)
                    .HasColumnName("ID_Peminjaman")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdJaminan).HasColumnName("ID_Jaminan");

                entity.Property(e => e.IdKendaraan).HasColumnName("ID_Kendaraan");

                entity.Property(e => e.TglPeminjaman)
                    .HasColumnName("Tgl_Peminjaman")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdPeminjamanNavigation)
                    .WithOne(p => p.Peminjaman)
                    .HasForeignKey<Peminjaman>(d => d.IdPeminjaman)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peminjaman_Customer");

                entity.HasOne(d => d.IdPeminjaman1)
                    .WithOne(p => p.Peminjaman)
                    .HasForeignKey<Peminjaman>(d => d.IdPeminjaman)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peminjaman_Jaminan");

                entity.HasOne(d => d.IdPeminjaman2)
                    .WithOne(p => p.Peminjaman)
                    .HasForeignKey<Peminjaman>(d => d.IdPeminjaman)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peminjaman_Kendaraan");

                entity.HasOne(d => d.IdPeminjaman3)
                    .WithOne(p => p.Peminjaman)
                    .HasForeignKey<Peminjaman>(d => d.IdPeminjaman)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peminjaman_Pengembalian");
            });

            modelBuilder.Entity<Pengembalian>(entity =>
            {
                entity.HasKey(e => e.IdPengembalian);

                entity.Property(e => e.IdPengembalian)
                    .HasColumnName("ID_Pengembalian")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdKondisi).HasColumnName("ID_Kondisi");

                entity.Property(e => e.IdPeminjaman).HasColumnName("ID_Peminjaman");

                entity.Property(e => e.TglPengembalian)
                    .HasColumnName("Tgl_Pengembalian")
                    .HasColumnType("datetime");
            });
        }
    }
}
