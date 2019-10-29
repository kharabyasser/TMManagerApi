using Microsoft.EntityFrameworkCore.Migrations;

namespace TMManagerApi.Migrations
{
    public partial class renameFingerPrint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fingerpring",
                table: "Satellites",
                newName: "Fingerprint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fingerprint",
                table: "Satellites",
                newName: "fingerpring");
        }
    }
}
