﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoesStore.Models;

#nullable disable

namespace ShoesStore.Migrations
{
    [DbContext(typeof(ShoesDbContext))]
    partial class ShoesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoesStore.Models.Chitietphieudat", b =>
                {
                    b.Property<int>("Idpd")
                        .HasColumnType("int")
                        .HasColumnName("IDPD");

                    b.Property<int>("Idsp")
                        .HasColumnType("int")
                        .HasColumnName("IDSP");

                    b.Property<int?>("Soluong")
                        .HasColumnType("int")
                        .HasColumnName("SOLUONG");

                    b.Property<decimal>("Tongtien")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("TONGTIEN");

                    b.HasKey("Idpd", "Idsp")
                        .HasName("PK__CHITIETP__F3FB9B27CF54D311");

                    b.HasIndex("Idsp");

                    b.ToTable("CHITIETPHIEUDAT", (string)null);
                });

            modelBuilder.Entity("ShoesStore.Models.Khachhang", b =>
                {
                    b.Property<int>("Idkh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDKH");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idkh"));

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("DIACHI");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EMAIL");

                    b.Property<bool?>("Gioitinh")
                        .HasColumnType("bit")
                        .HasColumnName("GIOITINH");

                    b.Property<DateTime?>("Ngaysinh")
                        .HasColumnType("datetime")
                        .HasColumnName("NGAYSINH");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SDT");

                    b.Property<string>("Tenkh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("TENKH");

                    b.HasKey("Idkh")
                        .HasName("PK__KHACHHAN__B87DC1A7CB39008C");

                    b.HasIndex("Email");

                    b.ToTable("KHACHHANG", (string)null);
                });

            modelBuilder.Entity("ShoesStore.Models.Loai", b =>
                {
                    b.Property<int>("Idloai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDLOAI");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idloai"));

                    b.Property<string>("Tenloai")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("TENLOAI");

                    b.HasKey("Idloai")
                        .HasName("PK__LOAI__0CDEF519CBA4AE7B");

                    b.HasIndex(new[] { "Tenloai" }, "UQ__LOAI__BF45B9967472A113")
                        .IsUnique();

                    b.ToTable("LOAI", (string)null);
                });

            modelBuilder.Entity("ShoesStore.Models.Nhanvien", b =>
                {
                    b.Property<int>("Idnv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDNV");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idnv"));

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("DIACHI");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EMAIL");

                    b.Property<bool>("Gioitinh")
                        .HasColumnType("bit")
                        .HasColumnName("GIOITINH");

                    b.Property<DateTime?>("Ngaysinh")
                        .HasColumnType("datetime")
                        .HasColumnName("NGAYSINH");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SDT");

                    b.Property<string>("Tennv")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("TENNV");

                    b.HasKey("Idnv")
                        .HasName("PK__NHANVIEN__B87DC9B2BB746F56");

                    b.HasIndex("Email");

                    b.ToTable("NHANVIEN", (string)null);
                });

            modelBuilder.Entity("ShoesStore.Models.Phieudat", b =>
                {
                    b.Property<int>("Idpd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDPD");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idpd"));

                    b.Property<string>("Ghichu")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GHICHU");

                    b.Property<int>("Idkh")
                        .HasColumnType("int")
                        .HasColumnName("IDKH");

                    b.Property<int?>("Idnv")
                        .HasColumnType("int")
                        .HasColumnName("IDNV");

                    b.Property<string>("Lydohuydon")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("LYDOHUYDON");

                    b.Property<DateTime>("Ngaydat")
                        .HasColumnType("datetime")
                        .HasColumnName("NGAYDAT");

                    b.Property<string>("Phuongthucthanhtoan")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("PHUONGTHUCTHANHTOAN");

                    b.Property<string>("Tinhtrang")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("TINHTRANG");

                    b.HasKey("Idpd")
                        .HasName("PK__PHIEUDAT__B87C5B0D773093A2");

                    b.HasIndex("Idkh");

                    b.HasIndex("Idnv");

                    b.ToTable("PHIEUDAT", (string)null);
                });

            modelBuilder.Entity("ShoesStore.Models.Sanpham", b =>
                {
                    b.Property<int>("Idsp")
                        .HasColumnType("int")
                        .HasColumnName("IDSP");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DETAIL");

                    b.Property<decimal>("Giagoc")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("GIAGOC");

                    b.Property<bool?>("Giamgia")
                        .HasColumnType("bit")
                        .HasColumnName("GIAMGIA");

                    b.Property<decimal?>("Giasale")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("GIASALE");

                    b.Property<bool?>("Hethang")
                        .HasColumnType("bit")
                        .HasColumnName("HETHANG");

                    b.Property<bool?>("Hienthi")
                        .HasColumnType("bit")
                        .HasColumnName("HIENTHI");

                    b.Property<string>("Hinhanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HINHANH");

                    b.Property<bool?>("Hot")
                        .HasColumnType("bit")
                        .HasColumnName("HOT");

                    b.Property<int>("Idloai")
                        .HasColumnType("int")
                        .HasColumnName("IDLOAI");

                    b.Property<string>("Mau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("MAU");

                    b.Property<bool?>("Moi")
                        .HasColumnType("bit")
                        .HasColumnName("MOI");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SIZE");

                    b.Property<int>("Soluong")
                        .HasColumnType("int")
                        .HasColumnName("SOLUONG");

                    b.Property<string>("Tensp")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("TENSP");

                    b.HasKey("Idsp")
                        .HasName("PK__SANPHAM__B87C02A535A2ED70");

                    b.HasIndex("Idloai");

                    b.ToTable("SANPHAM", (string)null);
                });

            modelBuilder.Entity("ShoesStore.Models.Taikhoan", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EMAIL");

                    b.Property<int>("Loaitk")
                        .HasColumnType("int")
                        .HasColumnName("LOAITK");

                    b.Property<string>("Matkhau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("MATKHAU");

                    b.HasKey("Email")
                        .HasName("PK__TAIKHOAN__161CF725D610CA2A");

                    b.ToTable("TAIKHOAN", (string)null);
                });

            modelBuilder.Entity("ShoesStore.Models.Chitietphieudat", b =>
                {
                    b.HasOne("ShoesStore.Models.Phieudat", "IdpdNavigation")
                        .WithMany("Chitietphieudats")
                        .HasForeignKey("Idpd")
                        .IsRequired()
                        .HasConstraintName("FK__CHITIETPHI__IDPD__48CFD27E");

                    b.HasOne("ShoesStore.Models.Sanpham", "IdspNavigation")
                        .WithMany("Chitietphieudats")
                        .HasForeignKey("Idsp")
                        .IsRequired()
                        .HasConstraintName("FK__CHITIETPHI__IDSP__49C3F6B7");

                    b.Navigation("IdpdNavigation");

                    b.Navigation("IdspNavigation");
                });

            modelBuilder.Entity("ShoesStore.Models.Khachhang", b =>
                {
                    b.HasOne("ShoesStore.Models.Taikhoan", "EmailNavigation")
                        .WithMany("Khachhangs")
                        .HasForeignKey("Email")
                        .IsRequired()
                        .HasConstraintName("FK__KHACHHANG__EMAIL__398D8EEE");

                    b.Navigation("EmailNavigation");
                });

            modelBuilder.Entity("ShoesStore.Models.Nhanvien", b =>
                {
                    b.HasOne("ShoesStore.Models.Taikhoan", "EmailNavigation")
                        .WithMany("Nhanviens")
                        .HasForeignKey("Email")
                        .IsRequired()
                        .HasConstraintName("FK__NHANVIEN__EMAIL__3C69FB99");

                    b.Navigation("EmailNavigation");
                });

            modelBuilder.Entity("ShoesStore.Models.Phieudat", b =>
                {
                    b.HasOne("ShoesStore.Models.Khachhang", "IdkhNavigation")
                        .WithMany("Phieudats")
                        .HasForeignKey("Idkh")
                        .IsRequired()
                        .HasConstraintName("FK__PHIEUDAT__IDKH__44FF419A");

                    b.HasOne("ShoesStore.Models.Nhanvien", "IdnvNavigation")
                        .WithMany("Phieudats")
                        .HasForeignKey("Idnv")
                        .HasConstraintName("FK__PHIEUDAT__IDNV__45F365D3");

                    b.Navigation("IdkhNavigation");

                    b.Navigation("IdnvNavigation");
                });

            modelBuilder.Entity("ShoesStore.Models.Sanpham", b =>
                {
                    b.HasOne("ShoesStore.Models.Loai", "IdloaiNavigation")
                        .WithMany("Sanphams")
                        .HasForeignKey("Idloai")
                        .IsRequired()
                        .HasConstraintName("FK__SANPHAM__IDLOAI__4222D4EF");

                    b.Navigation("IdloaiNavigation");
                });

            modelBuilder.Entity("ShoesStore.Models.Khachhang", b =>
                {
                    b.Navigation("Phieudats");
                });

            modelBuilder.Entity("ShoesStore.Models.Loai", b =>
                {
                    b.Navigation("Sanphams");
                });

            modelBuilder.Entity("ShoesStore.Models.Nhanvien", b =>
                {
                    b.Navigation("Phieudats");
                });

            modelBuilder.Entity("ShoesStore.Models.Phieudat", b =>
                {
                    b.Navigation("Chitietphieudats");
                });

            modelBuilder.Entity("ShoesStore.Models.Sanpham", b =>
                {
                    b.Navigation("Chitietphieudats");
                });

            modelBuilder.Entity("ShoesStore.Models.Taikhoan", b =>
                {
                    b.Navigation("Khachhangs");

                    b.Navigation("Nhanviens");
                });
#pragma warning restore 612, 618
        }
    }
}
