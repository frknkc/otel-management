using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace otel_management.Migrations
{
    /// <inheritdoc />
    public partial class _4_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckInDate",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CheckOutDate",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "Rooms");
        }
    }
}
