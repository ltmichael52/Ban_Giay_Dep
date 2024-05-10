using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesStore.Migrations
{
    /// <inheritdoc />
    public partial class addressVietnam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TINH",
                columns: table => new
                {
                    MATINH = table.Column<int>(type: "int", nullable: false),
                    TENTINH = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TINH", x => x.MATINH);
                });

            migrationBuilder.CreateTable(
                name: "QUAN",
                columns: table => new
                {
                    MAQUAN = table.Column<int>(type: "int", nullable: false),
                    TENQUAN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MATINH = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUAN", x => x.MAQUAN);
                    table.ForeignKey(
                        name: "FK_QUAN_TINH",
                        column: x => x.MATINH,
                        principalTable: "TINH",
                        principalColumn: "MATINH");
                });

            migrationBuilder.CreateTable(
                name: "PHUONG",
                columns: table => new
                {
                    MAPHUONG = table.Column<int>(type: "int", nullable: false),
                    TENPHUONG = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MAQUAN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHUONG", x => x.MAPHUONG);
                    table.ForeignKey(
                        name: "FK_QUAN_PHUONG",
                        column: x => x.MAQUAN,
                        principalTable: "QUAN",
                        principalColumn: "MAQUAN");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PHUONG_MAQUAN",
                table: "PHUONG",
                column: "MAQUAN");

            migrationBuilder.CreateIndex(
                name: "IX_QUAN_MATINH",
                table: "QUAN",
                column: "MATINH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PHUONG");

            migrationBuilder.DropTable(
                name: "QUAN");

            migrationBuilder.DropTable(
                name: "TINH");
        }
    }
}
