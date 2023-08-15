using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace otel_management.Migrations
{
    /// <inheritdoc />
    public partial class Migration_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Reservations");
        }
    }
}
