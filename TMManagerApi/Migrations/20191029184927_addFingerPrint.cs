using Microsoft.EntityFrameworkCore.Migrations;

namespace TMManagerApi.Migrations
{
    public partial class addFingerPrint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fingerpring",
                table: "Satellites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fingerpring",
                table: "Satellites");
        }
    }
}
