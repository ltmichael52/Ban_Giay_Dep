using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesStore.Migrations
{
    /// <inheritdoc />
    public partial class soXu2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_SOXU_MAKH",
                table: "SOXU",
                newName: "IX_SOXU_MAKH1");

            migrationBuilder.CreateIndex(
                name: "IX_SOXU_MAKH",
                table: "SOXU",
                column: "MAKH",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SOXU_MAKH",
                table: "SOXU");

            migrationBuilder.RenameIndex(
                name: "IX_SOXU_MAKH1",
                table: "SOXU",
                newName: "IX_SOXU_MAKH");
        }
    }
}
