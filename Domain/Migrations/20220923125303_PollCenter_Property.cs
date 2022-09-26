using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class PollCenter_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PollCenterId",
                table: "Villages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodId",
                table: "PollCenters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillageId",
                table: "PollCenters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PollCenterId",
                table: "Neighborhoods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PollCenters_NeighborhoodId",
                table: "PollCenters",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PollCenters_VillageId",
                table: "PollCenters",
                column: "VillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PollCenters_Neighborhoods_NeighborhoodId",
                table: "PollCenters",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollCenters_Villages_VillageId",
                table: "PollCenters",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollCenters_Neighborhoods_NeighborhoodId",
                table: "PollCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_PollCenters_Villages_VillageId",
                table: "PollCenters");

            migrationBuilder.DropIndex(
                name: "IX_PollCenters_NeighborhoodId",
                table: "PollCenters");

            migrationBuilder.DropIndex(
                name: "IX_PollCenters_VillageId",
                table: "PollCenters");

            migrationBuilder.DropColumn(
                name: "PollCenterId",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "PollCenters");

            migrationBuilder.DropColumn(
                name: "VillageId",
                table: "PollCenters");

            migrationBuilder.DropColumn(
                name: "PollCenterId",
                table: "Neighborhoods");
        }
    }
}
