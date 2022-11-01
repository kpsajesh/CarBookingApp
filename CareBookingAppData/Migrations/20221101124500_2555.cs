using Microsoft.EntityFrameworkCore.Migrations;

namespace CareBookingAppData.Migrations
{
    public partial class _2555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Makes_makeId",
                table: "CarModels");

            migrationBuilder.RenameColumn(
                name: "makeId",
                table: "CarModels",
                newName: "MakeId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModels_makeId",
                table: "CarModels",
                newName: "IX_CarModels_MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Makes_MakeId",
                table: "CarModels",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Makes_MakeId",
                table: "CarModels");

            migrationBuilder.RenameColumn(
                name: "MakeId",
                table: "CarModels",
                newName: "makeId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModels_MakeId",
                table: "CarModels",
                newName: "IX_CarModels_makeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Makes_makeId",
                table: "CarModels",
                column: "makeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
