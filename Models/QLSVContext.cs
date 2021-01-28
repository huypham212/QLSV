using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLSV.Models
{
    public partial class QLSVContext : DbContext
    {
        public QLSVContext()
        {
        }

        public QLSVContext(DbContextOptions<QLSVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }

        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<HeDaoTao> HeDaoTaos { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-ASTSTHD;Database=QLSV;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("pk_cv_macv");

                entity.ToTable("CHUC_VU");

                entity.Property(e => e.MaCv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaCV");

                entity.Property(e => e.TenCv)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("TenCV");
            });

            modelBuilder.Entity<ChuyenNganh>(entity =>
            {
                entity.HasKey(e => e.MaCn)
                    .HasName("pk_cn_macn");

                entity.ToTable("CHUYEN_NGANH");

                entity.Property(e => e.MaCn)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaCN");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TenCn)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("TenCN");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.ChuyenNganhs)
                    .HasForeignKey(d => d.MaKhoa)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_cn_makhoa");
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasKey(e => new { e.MaSv, e.MaMh, e.MaGv })
                    .HasName("pk_diem_masv_mamh_magv");

                entity.ToTable("DIEM");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaMH");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.DiemCc)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("DiemCC");

                entity.Property(e => e.DiemGk)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("DiemGK");

                entity.Property(e => e.DiemTb)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("DiemTB");

                entity.Property(e => e.DiemThi).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DiemTx)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("DiemTX");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_diem_magv");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_diem_mamh");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MaSv)
                    .HasConstraintName("fk_diem_masv");
            });

            modelBuilder.Entity<GiangVien>(entity =>
            {
                entity.HasKey(e => e.MaGv)
                    .HasName("pk_gv_magv");

                entity.ToTable("GIANG_VIEN");

                entity.Property(e => e.MaGv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaGV");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("(N'Nam')")
                    .IsFixedLength(true);

                entity.Property(e => e.MaCv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaCV");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenGv)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("TenGV");

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.GiangViens)
                    .HasForeignKey(d => d.MaCv)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_gv_macv");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.GiangViens)
                    .HasForeignKey(d => d.MaKhoa)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_gv_macn");
            });

            modelBuilder.Entity<HeDaoTao>(entity =>
            {
                entity.HasKey(e => e.MaHdt)
                    .HasName("pk_hdt_mahdt");

                entity.ToTable("HE_DAO_TAO");

                entity.Property(e => e.MaHdt)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaHDT");

                entity.Property(e => e.TenHdt)
                    .HasMaxLength(20)
                    .HasColumnName("TenHDT");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("pk_khoa_makhoa");

                entity.ToTable("KHOA");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TenKhoa)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop)
                    .HasName("pk_lop_malop");

                entity.ToTable("LOP");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaHdt)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaHDT");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NamBatDau).HasDefaultValueSql("(datepart(year,getdate()))");

                entity.Property(e => e.TenLop)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaHdtNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaHdt)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_lop_mahdt");

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaKhoa)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_lop_makkhoa");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("pk_monhoc_mamh");

                entity.ToTable("MON_HOC");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaMH");

                entity.Property(e => e.MaCn)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaCN");

                entity.Property(e => e.SoTc).HasColumnName("SoTC");

                entity.Property(e => e.TenMh)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenMH");

                entity.HasOne(d => d.MaCnNavigation)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.MaCn)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_monhoc_macn");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv)
                    .HasName("pk_sinhvien_masv");

                entity.ToTable("SINH_VIEN");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaSV");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("(N'Nam')");

                entity.Property(e => e.HocPhi).HasMaxLength(10);

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NamNhapHoc).HasDefaultValueSql("(datepart(year,getdate()))");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenSv)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("TenSV");

                entity.Property(e => e.TinhTrang)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaLop)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_sinhvien_malop");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
