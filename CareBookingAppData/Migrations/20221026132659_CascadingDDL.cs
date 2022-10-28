using Microsoft.EntityFrameworkCore.Migrations;

namespace CareBookingAppData.Migrations
{
    public partial class CascadingDDL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "makeId",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_makeId",
                table: "CarModels",
                column: "makeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Makes_makeId",
                table: "CarModels",
                column: "makeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Makes_makeId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_makeId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "makeId",
                table: "CarModels");
        }
    }
}
