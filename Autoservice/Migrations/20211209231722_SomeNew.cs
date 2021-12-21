using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoservice.Migrations
{
    public partial class SomeNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_ClientCarId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_ClientId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_MasterId",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ClientCarId",
                table: "Request",
                column: "ClientCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ClientId",
                table: "Request",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_MasterId",
                table: "Request",
                column: "MasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_ClientCarId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_ClientId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_MasterId",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ClientCarId",
                table: "Request",
                column: "ClientCarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_ClientId",
                table: "Request",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_MasterId",
                table: "Request",
                column: "MasterId",
                unique: true);
        }
    }
}
