using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMManagerApi.Migrations
{
    public partial class AddSatellitesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Satellites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(nullable: true),
                    Truck = table.Column<string>(nullable: true),
                    Meter = table.Column<string>(nullable: true),
                    IsDualMeter = table.Column<bool>(nullable: false),
                    Printer = table.Column<string>(nullable: true),
                    TruckMasterVersion = table.Column<string>(nullable: true),
                    RemoteServiceVersion = table.Column<string>(nullable: true),
                    TeamViewerID = table.Column<string>(nullable: true),
                    TeamViewerVersion = table.Column<string>(nullable: true),
                    OS = table.Column<string>(nullable: true),
                    IsOnlie = table.Column<bool>(nullable: false),
                    LastSynch = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satellites", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Satellites");
        }
    }
}
