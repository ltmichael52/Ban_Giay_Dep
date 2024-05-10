using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesStore.Migrations
{
    /// <inheritdoc />
    public partial class updatePm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DIACHINGUOINHAN",
                table: "PHIEUMUA",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EMAILNGUOINHAN",
                table: "PHIEUMUA",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SDTNGUOINHAN",
                table: "PHIEUMUA",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TENNGUOINHAN",
                table: "PHIEUMUA",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DIACHINGUOINHAN",
                table: "PHIEUMUA");

            migrationBuilder.DropColumn(
                name: "EMAILNGUOINHAN",
                table: "PHIEUMUA");

            migrationBuilder.DropColumn(
                name: "SDTNGUOINHAN",
                table: "PHIEUMUA");

            migrationBuilder.DropColumn(
                name: "TENNGUOINHAN",
                table: "PHIEUMUA");
        }
    }
}
