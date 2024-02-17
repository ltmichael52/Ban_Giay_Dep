using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShoesStore.Models;

public partial class ShoesDbContext : DbContext
{
    public ShoesDbContext()
    {
    }

    public ShoesDbContext(DbContextOptions<ShoesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietphieudat> Chitietphieudats { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phieudat> Phieudats { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MICHAEL;Initial Catalog=ShoesStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietphieudat>(entity =>
        {
            entity.HasKey(e => new { e.Idpd, e.Idsp }).HasName("PK__CHITIETP__F3FB9B27CF54D311");

            entity.ToTable("CHITIETPHIEUDAT");

            entity.Property(e => e.Idpd).HasColumnName("IDPD");
            entity.Property(e => e.Idsp).HasColumnName("IDSP");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TONGTIEN");

            entity.HasOne(d => d.IdpdNavigation).WithMany(p => p.Chitietphieudats)
                .HasForeignKey(d => d.Idpd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETPHI__IDPD__48CFD27E");

            entity.HasOne(d => d.IdspNavigation).WithMany(p => p.Chitietphieudats)
                .HasForeignKey(d => d.Idsp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETPHI__IDSP__49C3F6B7");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Idkh).HasName("PK__KHACHHAN__B87DC1A7CB39008C");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.Idkh).HasColumnName("IDKH");
            entity.Property(e => e.Diachi)
                .HasMaxLength(255)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh).HasColumnName("GIOITINH");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("NGAYSINH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(255)
                .HasColumnName("SDT");
            entity.Property(e => e.Tenkh)
                .HasMaxLength(255)
                .HasColumnName("TENKH");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KHACHHANG__EMAIL__398D8EEE");
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.Idloai).HasName("PK__LOAI__0CDEF519CBA4AE7B");

            entity.ToTable("LOAI");

            entity.HasIndex(e => e.Tenloai, "UQ__LOAI__BF45B9967472A113").IsUnique();

            entity.Property(e => e.Idloai).HasColumnName("IDLOAI");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(255)
                .HasColumnName("TENLOAI");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Idnv).HasName("PK__NHANVIEN__B87DC9B2BB746F56");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Idnv).HasColumnName("IDNV");
            entity.Property(e => e.Diachi)
                .HasMaxLength(255)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh).HasColumnName("GIOITINH");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("NGAYSINH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(255)
                .HasColumnName("SDT");
            entity.Property(e => e.Tennv)
                .HasMaxLength(255)
                .HasColumnName("TENNV");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NHANVIEN__EMAIL__3C69FB99");
        });

        modelBuilder.Entity<Phieudat>(entity =>
        {
            entity.HasKey(e => e.Idpd).HasName("PK__PHIEUDAT__B87C5B0D773093A2");

            entity.ToTable("PHIEUDAT");

            entity.Property(e => e.Idpd).HasColumnName("IDPD");
            entity.Property(e => e.Ghichu).HasColumnName("GHICHU");
            entity.Property(e => e.Idkh).HasColumnName("IDKH");
            entity.Property(e => e.Idnv).HasColumnName("IDNV");
            entity.Property(e => e.Lydohuydon)
                .HasMaxLength(255)
                .HasColumnName("LYDOHUYDON");
            entity.Property(e => e.Ngaydat)
                .HasColumnType("datetime")
                .HasColumnName("NGAYDAT");
            entity.Property(e => e.Phuongthucthanhtoan)
                .HasMaxLength(255)
                .HasColumnName("PHUONGTHUCTHANHTOAN");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(255)
                .HasColumnName("TINHTRANG");

            entity.HasOne(d => d.IdkhNavigation).WithMany(p => p.Phieudats)
                .HasForeignKey(d => d.Idkh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PHIEUDAT__IDKH__44FF419A");

            entity.HasOne(d => d.IdnvNavigation).WithMany(p => p.Phieudats)
                .HasForeignKey(d => d.Idnv)
                .HasConstraintName("FK__PHIEUDAT__IDNV__45F365D3");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Idsp).HasName("PK__SANPHAM__B87C02A535A2ED70");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Idsp)
                .ValueGeneratedNever()
                .HasColumnName("IDSP");
            entity.Property(e => e.Detail).HasColumnName("DETAIL");
            entity.Property(e => e.Giagoc)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GIAGOC");
            entity.Property(e => e.Giamgia).HasColumnName("GIAMGIA");
            entity.Property(e => e.Giasale)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GIASALE");
            entity.Property(e => e.Hethang).HasColumnName("HETHANG");
            entity.Property(e => e.Hienthi).HasColumnName("HIENTHI");
            entity.Property(e => e.Hinhanh).HasColumnName("HINHANH");
            entity.Property(e => e.Hot).HasColumnName("HOT");
            entity.Property(e => e.Idloai).HasColumnName("IDLOAI");
            entity.Property(e => e.Mau)
                .HasMaxLength(255)
                .HasColumnName("MAU");
            entity.Property(e => e.Moi).HasColumnName("MOI");
            entity.Property(e => e.Size)
                .HasMaxLength(255)
                .HasColumnName("SIZE");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Tensp)
                .HasMaxLength(255)
                .HasColumnName("TENSP");

            entity.HasOne(d => d.IdloaiNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Idloai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SANPHAM__IDLOAI__4222D4EF");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__TAIKHOAN__161CF725D610CA2A");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Loaitk).HasColumnName("LOAITK");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(255)
                .HasColumnName("MATKHAU");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
