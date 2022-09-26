using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class Street : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodId",
                table: "Streets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillageId",
                table: "Streets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_NeighborhoodId",
                table: "Streets",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_VillageId",
                table: "Streets",
                column: "VillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_Neighborhoods_NeighborhoodId",
                table: "Streets",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_Villages_VillageId",
                table: "Streets",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Streets_Neighborhoods_NeighborhoodId",
                table: "Streets");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_Villages_VillageId",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_Streets_NeighborhoodId",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_Streets_VillageId",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "VillageId",
                table: "Streets");
        }
    }
}
