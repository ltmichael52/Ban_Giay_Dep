using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesStore.Migrations
{
    /// <inheritdoc />
    public partial class soxu_sodiachi_voucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DIACHI",
                table: "KHACHHANG");

            migrationBuilder.RenameColumn(
                name: "ANHDAIDIEN",
                table: "BLOG",
                newName: "Anhdaidien");

            migrationBuilder.AddColumn<int>(
                name: "MAVOUCHER",
                table: "PHIEUMUA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NGAYXEPHANG",
                table: "KHACHHANG",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "XEPHANG",
                table: "KHACHHANG",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Anhdaidien",
                table: "BLOG",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SODIACHI",
                columns: table => new
                {
                    MASODIACHI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAKH = table.Column<int>(type: "int", nullable: false),
                    TENNGUOINHAN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SDTNGUOINHAN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SODIACHI", x => x.MASODIACHI);
                    table.ForeignKey(
                        name: "FK__KHACHHAG__SODIACHI__123213",
                        column: x => x.MAKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MAKH");
                });

            migrationBuilder.CreateTable(
                name: "SOXU",
                columns: table => new
                {
                    MASOXU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAKH = table.Column<int>(type: "int", nullable: false),
                    TONGXU = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOXU", x => x.MASOXU);
                    table.ForeignKey(
                        name: "FK__KHACHHAG__SOXU__123213",
                        column: x => x.MAKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MAKH");
                });

            migrationBuilder.CreateTable(
                name: "VOUCHER",
                columns: table => new
                {
                    MAVOUCHER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOLUONG = table.Column<int>(type: "int", nullable: false),
                    PHANTRAMGIAM = table.Column<int>(type: "int", nullable: false),
                    GIATOITHIEU = table.Column<decimal>(type: "money", nullable: false),
                    GIAMTOIDA = table.Column<decimal>(type: "money", nullable: false),
                    NGAYTAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    NGAYHETHAN = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOUCHER", x => x.MAVOUCHER);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUMUA_MAVOUCHER",
                table: "PHIEUMUA",
                column: "MAVOUCHER");

            migrationBuilder.CreateIndex(
                name: "IX_SODIACHI_MAKH",
                table: "SODIACHI",
                column: "MAKH");

            migrationBuilder.CreateIndex(
                name: "IX_SOXU_MAKH",
                table: "SOXU",
                column: "MAKH");

            migrationBuilder.AddForeignKey(
                name: "FK_PHIEUMUA_VOUCHER",
                table: "PHIEUMUA",
                column: "MAVOUCHER",
                principalTable: "VOUCHER",
                principalColumn: "MAVOUCHER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PHIEUMUA_VOUCHER",
                table: "PHIEUMUA");

            migrationBuilder.DropTable(
                name: "SODIACHI");

            migrationBuilder.DropTable(
                name: "SOXU");

            migrationBuilder.DropTable(
                name: "VOUCHER");

            migrationBuilder.DropIndex(
                name: "IX_PHIEUMUA_MAVOUCHER",
                table: "PHIEUMUA");

            migrationBuilder.DropColumn(
                name: "MAVOUCHER",
                table: "PHIEUMUA");

            migrationBuilder.DropColumn(
                name: "NGAYXEPHANG",
                table: "KHACHHANG");

            migrationBuilder.DropColumn(
                name: "XEPHANG",
                table: "KHACHHANG");

            migrationBuilder.RenameColumn(
                name: "Anhdaidien",
                table: "BLOG",
                newName: "ANHDAIDIEN");

            migrationBuilder.AddColumn<string>(
                name: "DIACHI",
                table: "KHACHHANG",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ANHDAIDIEN",
                table: "BLOG",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
