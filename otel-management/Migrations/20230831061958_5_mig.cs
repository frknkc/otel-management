using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace otel_management.Migrations
{
    /// <inheritdoc />
    public partial class _5_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Lock",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Lock",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lock",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lock",
                table: "Rooms");
        }
    }
}
