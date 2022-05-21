using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMSSajib.Migrations
{
    public partial class smthng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "extra1",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extra2",
                table: "Notifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "extra1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "extra2",
                table: "Notifications");
        }
    }
}
