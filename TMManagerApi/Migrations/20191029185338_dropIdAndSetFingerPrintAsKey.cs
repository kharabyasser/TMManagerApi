using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMManagerApi.Migrations
{
    public partial class dropIdAndSetFingerPrintAsKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Satellites",
                table: "Satellites");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Satellites");

            migrationBuilder.AlterColumn<string>(
                name: "Fingerprint",
                table: "Satellites",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Satellites",
                table: "Satellites",
                column: "Fingerprint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Satellites",
                table: "Satellites");

            migrationBuilder.AlterColumn<string>(
                name: "Fingerprint",
                table: "Satellites",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Satellites",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Satellites",
                table: "Satellites",
                column: "Id");
        }
    }
}
