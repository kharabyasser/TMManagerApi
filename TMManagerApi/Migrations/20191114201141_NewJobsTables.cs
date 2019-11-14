using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMManagerApi.Migrations
{
    public partial class NewJobsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    requestDateTime = table.Column<DateTime>(nullable: false),
                    JobDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResponseDateTime = table.Column<DateTime>(nullable: false),
                    ResponseMessage = table.Column<string>(nullable: true),
                    IsSuccess = table.Column<bool>(nullable: false),
                    JobRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobResponses_JobRequests_JobRequestId",
                        column: x => x.JobRequestId,
                        principalTable: "JobRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobResponses_JobRequestId",
                table: "JobResponses",
                column: "JobRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobResponses");

            migrationBuilder.DropTable(
                name: "JobRequests");
        }
    }
}
