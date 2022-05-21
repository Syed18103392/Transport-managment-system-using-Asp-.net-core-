using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMSSajib.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    TransportNumber = table.Column<string>(nullable: false),
                    TransportType = table.Column<string>(nullable: false),
                    DriverName = table.Column<string>(nullable: false),
                    DriverNumber = table.Column<string>(nullable: false),
                    BookingDate = table.Column<string>(nullable: true),
                    hour = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    route = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.TransportNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "Transport");
        }
    }
}
