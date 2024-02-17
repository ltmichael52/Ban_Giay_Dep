using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesStore.Migrations
{
    /// <inheritdoc />
    public partial class v0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOAI",
                columns: table => new
                {
                    IDLOAI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENLOAI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOAI__0CDEF519CBA4AE7B", x => x.IDLOAI);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MATKHAU = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LOAITK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TAIKHOAN__161CF725D610CA2A", x => x.EMAIL);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    IDSP = table.Column<int>(type: "int", nullable: false),
                    IDLOAI = table.Column<int>(type: "int", nullable: false),
                    TENSP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HINHANH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false),
                    GIAGOC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GIASALE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MAU = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SIZE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DETAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HIENTHI = table.Column<bool>(type: "bit", nullable: true),
                    HETHANG = table.Column<bool>(type: "bit", nullable: true),
                    GIAMGIA = table.Column<bool>(type: "bit", nullable: true),
                    MOI = table.Column<bool>(type: "bit", nullable: true),
                    HOT = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SANPHAM__B87C02A535A2ED70", x => x.IDSP);
                    table.ForeignKey(
                        name: "FK__SANPHAM__IDLOAI__4222D4EF",
                        column: x => x.IDLOAI,
                        principalTable: "LOAI",
                        principalColumn: "IDLOAI");
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    IDKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENKH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GIOITINH = table.Column<bool>(type: "bit", nullable: true),
                    NGAYSINH = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHACHHAN__B87DC1A7CB39008C", x => x.IDKH);
                    table.ForeignKey(
                        name: "FK__KHACHHANG__EMAIL__398D8EEE",
                        column: x => x.EMAIL,
                        principalTable: "TAIKHOAN",
                        principalColumn: "EMAIL");
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    IDNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENNV = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GIOITINH = table.Column<bool>(type: "bit", nullable: false),
                    NGAYSINH = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHANVIEN__B87DC9B2BB746F56", x => x.IDNV);
                    table.ForeignKey(
                        name: "FK__NHANVIEN__EMAIL__3C69FB99",
                        column: x => x.EMAIL,
                        principalTable: "TAIKHOAN",
                        principalColumn: "EMAIL");
                });

            migrationBuilder.CreateTable(
                name: "PHIEUDAT",
                columns: table => new
                {
                    IDPD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NGAYDAT = table.Column<DateTime>(type: "datetime", nullable: false),
                    IDKH = table.Column<int>(type: "int", nullable: false),
                    IDNV = table.Column<int>(type: "int", nullable: true),
                    TINHTRANG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PHUONGTHUCTHANHTOAN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GHICHU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LYDOHUYDON = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PHIEUDAT__B87C5B0D773093A2", x => x.IDPD);
                    table.ForeignKey(
                        name: "FK__PHIEUDAT__IDKH__44FF419A",
                        column: x => x.IDKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "IDKH");
                    table.ForeignKey(
                        name: "FK__PHIEUDAT__IDNV__45F365D3",
                        column: x => x.IDNV,
                        principalTable: "NHANVIEN",
                        principalColumn: "IDNV");
                });

            migrationBuilder.CreateTable(
                name: "CHITIETPHIEUDAT",
                columns: table => new
                {
                    IDPD = table.Column<int>(type: "int", nullable: false),
                    IDSP = table.Column<int>(type: "int", nullable: false),
                    TONGTIEN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHITIETP__F3FB9B27CF54D311", x => new { x.IDPD, x.IDSP });
                    table.ForeignKey(
                        name: "FK__CHITIETPHI__IDPD__48CFD27E",
                        column: x => x.IDPD,
                        principalTable: "PHIEUDAT",
                        principalColumn: "IDPD");
                    table.ForeignKey(
                        name: "FK__CHITIETPHI__IDSP__49C3F6B7",
                        column: x => x.IDSP,
                        principalTable: "SANPHAM",
                        principalColumn: "IDSP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETPHIEUDAT_IDSP",
                table: "CHITIETPHIEUDAT",
                column: "IDSP");

            migrationBuilder.CreateIndex(
                name: "IX_KHACHHANG_EMAIL",
                table: "KHACHHANG",
                column: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "UQ__LOAI__BF45B9967472A113",
                table: "LOAI",
                column: "TENLOAI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_EMAIL",
                table: "NHANVIEN",
                column: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDAT_IDKH",
                table: "PHIEUDAT",
                column: "IDKH");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDAT_IDNV",
                table: "PHIEUDAT",
                column: "IDNV");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_IDLOAI",
                table: "SANPHAM",
                column: "IDLOAI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETPHIEUDAT");

            migrationBuilder.DropTable(
                name: "PHIEUDAT");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "LOAI");

            migrationBuilder.DropTable(
                name: "TAIKHOAN");
        }
    }
}
