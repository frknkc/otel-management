using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace otel_management.Migrations
{
    /// <inheritdoc />
    public partial class _2_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServicePrice",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomPrice",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "RoomPrice",
                table: "Rooms");
        }
    }
}
