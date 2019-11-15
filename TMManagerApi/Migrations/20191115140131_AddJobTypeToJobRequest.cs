using Microsoft.EntityFrameworkCore.Migrations;

namespace TMManagerApi.Migrations
{
    public partial class AddJobTypeToJobRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "requestDateTime",
                table: "JobRequests",
                newName: "RequestDateTime");

            migrationBuilder.AddColumn<string>(
                name: "JobType",
                table: "JobRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobType",
                table: "JobRequests");

            migrationBuilder.RenameColumn(
                name: "RequestDateTime",
                table: "JobRequests",
                newName: "requestDateTime");
        }
    }
}
