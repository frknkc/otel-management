using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace otel_management.Migrations
{
    /// <inheritdoc />
    public partial class _3_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvaliable",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvaliable",
                table: "Services");
        }
    }
}
