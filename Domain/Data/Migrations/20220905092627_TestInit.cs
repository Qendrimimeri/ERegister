using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERegister.Data.Migrations
{
    public partial class TestInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Blocks_BlocksId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Houses_HousesId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Municipalities_MunicipalitiesId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Neigborhoods_NeigborhoodsId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PollCenters_PollCentersId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Streets_StreetsId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Vilages_VilagesId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ActualStatuses_ActualStatusesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Municipalities_MunicipalitiesId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_DemandsSpecifieds_AspNetUsers_AppliactionUsersId",
                table: "DemandsSpecifieds");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipalities_Regions_RegionsId",
                table: "Municipalities");

            migrationBuilder.DropForeignKey(
                name: "FK_Neigborhoods_Municipalities_MunicipalitiesId",
                table: "Neigborhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_AspNetUsers_ApplicationUserId1",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_Helps_HelpsId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificReasons_AspNetUsers_ApplicationUserId1",
                table: "SpecificReasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_StreetSources_StreetSourcesId",
                table: "Streets");

            migrationBuilder.DropForeignKey(
                name: "FK_Vilages_Municipalities_MunicipalitiesId",
                table: "Vilages");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_AspNetUsers_ApplicationUserId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "AdministrativeUnitsWorks");

            migrationBuilder.DropTable(
                name: "Reasons_Users");

            migrationBuilder.DropIndex(
                name: "IX_Works_ApplicationUserId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Vilages_MunicipalitiesId",
                table: "Vilages");

            migrationBuilder.DropIndex(
                name: "IX_Streets_StreetSourcesId",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_SpecificReasons_ApplicationUserId1",
                table: "SpecificReasons");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_ApplicationUserId1",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_Neigborhoods_MunicipalitiesId",
                table: "Neigborhoods");

            migrationBuilder.DropIndex(
                name: "IX_Municipalities_RegionsId",
                table: "Municipalities");

            migrationBuilder.DropIndex(
                name: "IX_DemandsSpecifieds_AppliactionUsersId",
                table: "DemandsSpecifieds");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_MunicipalitiesId",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ActualStatusesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_BlocksId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_HousesId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_MunicipalitiesId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_NeigborhoodsId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PollCentersId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StreetsId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_VilagesId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "MunicipalitiesId",
                table: "Vilages");

            migrationBuilder.DropColumn(
                name: "StreetSourcesId",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "SpecificReasons");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PollRelateds");

            migrationBuilder.DropColumn(
                name: "MunicipalitiesId",
                table: "Neigborhoods");

            migrationBuilder.DropColumn(
                name: "RegionsId",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropColumn(
                name: "GeneralDemandId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropColumn(
                name: "AppliactionUsersId",
                table: "DemandsSpecifieds");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DemandsSpecifieds");

            migrationBuilder.DropColumn(
                name: "MunicipalitiesId",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "ActualStatusesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BlocksId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "HousesId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "MunicipalitiesId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "NeigborhoodsId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PollCentersId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StreetsId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "VilagesId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "WorkId",
                table: "PollRelateds",
                newName: "SpecificReasonId");

            migrationBuilder.RenameColumn(
                name: "PoliticalSubjectId",
                table: "PollRelateds",
                newName: "MyPropertyId");

            migrationBuilder.RenameColumn(
                name: "HelpsId",
                table: "PollRelateds",
                newName: "GeneralReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_PollRelateds_HelpsId",
                table: "PollRelateds",
                newName: "IX_PollRelateds_GeneralReasonId");

            migrationBuilder.RenameColumn(
                name: "AddressesId",
                table: "AspNetUsers",
                newName: "SpecificDemandId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AddressesId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SpecificDemandId");

            migrationBuilder.RenameColumn(
                name: "VillageId",
                table: "Addresses",
                newName: "VilageId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "SpecificReasons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PollRelateds",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneralDemandId",
                table: "PollRelateds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdministrativeUnitWork",
                columns: table => new
                {
                    AdministrativeUnitsId = table.Column<int>(type: "int", nullable: false),
                    WorksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeUnitWork", x => new { x.AdministrativeUnitsId, x.WorksId });
                    table.ForeignKey(
                        name: "FK_AdministrativeUnitWork_AdministrativeUnits_AdministrativeUnitsId",
                        column: x => x.AdministrativeUnitsId,
                        principalTable: "AdministrativeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministrativeUnitWork_Works_WorksId",
                        column: x => x.WorksId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vilages_MunicipalityId",
                table: "Vilages",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_StreetSourceId",
                table: "Streets",
                column: "StreetSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificReasons_ApplicationUserId",
                table: "SpecificReasons",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_ApplicationUserId",
                table: "PollRelateds",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_GeneralDemandId",
                table: "PollRelateds",
                column: "GeneralDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_HelpId",
                table: "PollRelateds",
                column: "HelpId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_MyPropertyId",
                table: "PollRelateds",
                column: "MyPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_SpecificReasonId",
                table: "PollRelateds",
                column: "SpecificReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Neigborhoods_MunicipalityId",
                table: "Neigborhoods",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_RegionId",
                table: "Municipalities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_MunicipalityId",
                table: "Blocks",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ActualStatusId",
                table: "AspNetUsers",
                column: "ActualStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkId",
                table: "AspNetUsers",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BlockId",
                table: "Addresses",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_HouseId",
                table: "Addresses",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MunicipalityId",
                table: "Addresses",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeigborhoodId",
                table: "Addresses",
                column: "NeigborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PollCenterId",
                table: "Addresses",
                column: "PollCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_VilageId",
                table: "Addresses",
                column: "VilageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeUnitWork_WorksId",
                table: "AdministrativeUnitWork",
                column: "WorksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Blocks_BlockId",
                table: "Addresses",
                column: "BlockId",
                principalTable: "Blocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Houses_HouseId",
                table: "Addresses",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Municipalities_MunicipalityId",
                table: "Addresses",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Neigborhoods_NeigborhoodId",
                table: "Addresses",
                column: "NeigborhoodId",
                principalTable: "Neigborhoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_PollCenters_PollCenterId",
                table: "Addresses",
                column: "PollCenterId",
                principalTable: "PollCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Vilages_VilageId",
                table: "Addresses",
                column: "VilageId",
                principalTable: "Vilages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ActualStatuses_ActualStatusId",
                table: "AspNetUsers",
                column: "ActualStatusId",
                principalTable: "ActualStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DemandsSpecifieds_SpecificDemandId",
                table: "AspNetUsers",
                column: "SpecificDemandId",
                principalTable: "DemandsSpecifieds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Works_WorkId",
                table: "AspNetUsers",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Municipalities_MunicipalityId",
                table: "Blocks",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipalities_Regions_RegionId",
                table: "Municipalities",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Neigborhoods_Municipalities_MunicipalityId",
                table: "Neigborhoods",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_AspNetUsers_ApplicationUserId",
                table: "PollRelateds",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_DemandsSpecifieds_MyPropertyId",
                table: "PollRelateds",
                column: "MyPropertyId",
                principalTable: "DemandsSpecifieds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_GeneralDemands_GeneralDemandId",
                table: "PollRelateds",
                column: "GeneralDemandId",
                principalTable: "GeneralDemands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_GeneralReasons_GeneralReasonId",
                table: "PollRelateds",
                column: "GeneralReasonId",
                principalTable: "GeneralReasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_Helps_HelpId",
                table: "PollRelateds",
                column: "HelpId",
                principalTable: "Helps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_SpecificReasons_SpecificReasonId",
                table: "PollRelateds",
                column: "SpecificReasonId",
                principalTable: "SpecificReasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificReasons_AspNetUsers_ApplicationUserId",
                table: "SpecificReasons",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_StreetSources_StreetSourceId",
                table: "Streets",
                column: "StreetSourceId",
                principalTable: "StreetSources",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vilages_Municipalities_MunicipalityId",
                table: "Vilages",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Blocks_BlockId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Houses_HouseId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Municipalities_MunicipalityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Neigborhoods_NeigborhoodId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PollCenters_PollCenterId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Vilages_VilageId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ActualStatuses_ActualStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DemandsSpecifieds_SpecificDemandId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Works_WorkId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Municipalities_MunicipalityId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipalities_Regions_RegionId",
                table: "Municipalities");

            migrationBuilder.DropForeignKey(
                name: "FK_Neigborhoods_Municipalities_MunicipalityId",
                table: "Neigborhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_AspNetUsers_ApplicationUserId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_DemandsSpecifieds_MyPropertyId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_GeneralDemands_GeneralDemandId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_GeneralReasons_GeneralReasonId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_Helps_HelpId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_SpecificReasons_SpecificReasonId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificReasons_AspNetUsers_ApplicationUserId",
                table: "SpecificReasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_StreetSources_StreetSourceId",
                table: "Streets");

            migrationBuilder.DropForeignKey(
                name: "FK_Vilages_Municipalities_MunicipalityId",
                table: "Vilages");

            migrationBuilder.DropTable(
                name: "AdministrativeUnitWork");

            migrationBuilder.DropIndex(
                name: "IX_Vilages_MunicipalityId",
                table: "Vilages");

            migrationBuilder.DropIndex(
                name: "IX_Streets_StreetSourceId",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_SpecificReasons_ApplicationUserId",
                table: "SpecificReasons");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_ApplicationUserId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_GeneralDemandId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_HelpId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_MyPropertyId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_SpecificReasonId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_Neigborhoods_MunicipalityId",
                table: "Neigborhoods");

            migrationBuilder.DropIndex(
                name: "IX_Municipalities_RegionId",
                table: "Municipalities");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_MunicipalityId",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ActualStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_BlockId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_HouseId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_MunicipalityId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_NeigborhoodId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PollCenterId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_VilageId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "GeneralDemandId",
                table: "PollRelateds");

            migrationBuilder.RenameColumn(
                name: "SpecificReasonId",
                table: "PollRelateds",
                newName: "WorkId");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "PollRelateds",
                newName: "PoliticalSubjectId");

            migrationBuilder.RenameColumn(
                name: "GeneralReasonId",
                table: "PollRelateds",
                newName: "HelpsId");

            migrationBuilder.RenameIndex(
                name: "IX_PollRelateds_GeneralReasonId",
                table: "PollRelateds",
                newName: "IX_PollRelateds_HelpsId");

            migrationBuilder.RenameColumn(
                name: "SpecificDemandId",
                table: "AspNetUsers",
                newName: "AddressesId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SpecificDemandId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AddressesId");

            migrationBuilder.RenameColumn(
                name: "VilageId",
                table: "Addresses",
                newName: "VillageId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Works",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalitiesId",
                table: "Vilages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StreetSourcesId",
                table: "Streets",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "SpecificReasons",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "SpecificReasons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "PollRelateds",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "PollRelateds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalitiesId",
                table: "Neigborhoods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionsId",
                table: "Municipalities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "GeneralDemands_Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneralDemandId",
                table: "GeneralDemands_Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliactionUsersId",
                table: "DemandsSpecifieds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "DemandsSpecifieds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalitiesId",
                table: "Blocks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActualStatusesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlocksId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HousesId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalitiesId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeigborhoodsId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PollCentersId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StreetsId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VilagesId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdministrativeUnitsWorks",
                columns: table => new
                {
                    AdministrativeUnitsId = table.Column<int>(type: "int", nullable: false),
                    WorksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeUnitsWorks", x => new { x.AdministrativeUnitsId, x.WorksId });
                    table.ForeignKey(
                        name: "FK_AdministrativeUnitsWorks_AdministrativeUnits_AdministrativeUnitsId",
                        column: x => x.AdministrativeUnitsId,
                        principalTable: "AdministrativeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministrativeUnitsWorks_Works_WorksId",
                        column: x => x.WorksId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reasons_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GeneralReasonsId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    GeneralReasonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasons_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reasons_Users_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reasons_Users_GeneralReasons_GeneralReasonsId",
                        column: x => x.GeneralReasonsId,
                        principalTable: "GeneralReasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_ApplicationUserId",
                table: "Works",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vilages_MunicipalitiesId",
                table: "Vilages",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_StreetSourcesId",
                table: "Streets",
                column: "StreetSourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificReasons_ApplicationUserId1",
                table: "SpecificReasons",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_ApplicationUserId1",
                table: "PollRelateds",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Neigborhoods_MunicipalitiesId",
                table: "Neigborhoods",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_RegionsId",
                table: "Municipalities",
                column: "RegionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandsSpecifieds_AppliactionUsersId",
                table: "DemandsSpecifieds",
                column: "AppliactionUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_MunicipalitiesId",
                table: "Blocks",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ActualStatusesId",
                table: "AspNetUsers",
                column: "ActualStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BlocksId",
                table: "Addresses",
                column: "BlocksId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_HousesId",
                table: "Addresses",
                column: "HousesId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MunicipalitiesId",
                table: "Addresses",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeigborhoodsId",
                table: "Addresses",
                column: "NeigborhoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PollCentersId",
                table: "Addresses",
                column: "PollCentersId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetsId",
                table: "Addresses",
                column: "StreetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_VilagesId",
                table: "Addresses",
                column: "VilagesId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeUnitsWorks_WorksId",
                table: "AdministrativeUnitsWorks",
                column: "WorksId");

            migrationBuilder.CreateIndex(
                name: "IX_Reasons_Users_ApplicationUsersId",
                table: "Reasons_Users",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reasons_Users_GeneralReasonsId",
                table: "Reasons_Users",
                column: "GeneralReasonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Blocks_BlocksId",
                table: "Addresses",
                column: "BlocksId",
                principalTable: "Blocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Houses_HousesId",
                table: "Addresses",
                column: "HousesId",
                principalTable: "Houses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Municipalities_MunicipalitiesId",
                table: "Addresses",
                column: "MunicipalitiesId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Neigborhoods_NeigborhoodsId",
                table: "Addresses",
                column: "NeigborhoodsId",
                principalTable: "Neigborhoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_PollCenters_PollCentersId",
                table: "Addresses",
                column: "PollCentersId",
                principalTable: "PollCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Streets_StreetsId",
                table: "Addresses",
                column: "StreetsId",
                principalTable: "Streets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Vilages_VilagesId",
                table: "Addresses",
                column: "VilagesId",
                principalTable: "Vilages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ActualStatuses_ActualStatusesId",
                table: "AspNetUsers",
                column: "ActualStatusesId",
                principalTable: "ActualStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressesId",
                table: "AspNetUsers",
                column: "AddressesId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Municipalities_MunicipalitiesId",
                table: "Blocks",
                column: "MunicipalitiesId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DemandsSpecifieds_AspNetUsers_AppliactionUsersId",
                table: "DemandsSpecifieds",
                column: "AppliactionUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipalities_Regions_RegionsId",
                table: "Municipalities",
                column: "RegionsId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Neigborhoods_Municipalities_MunicipalitiesId",
                table: "Neigborhoods",
                column: "MunicipalitiesId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_AspNetUsers_ApplicationUserId1",
                table: "PollRelateds",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_Helps_HelpsId",
                table: "PollRelateds",
                column: "HelpsId",
                principalTable: "Helps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificReasons_AspNetUsers_ApplicationUserId1",
                table: "SpecificReasons",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_StreetSources_StreetSourcesId",
                table: "Streets",
                column: "StreetSourcesId",
                principalTable: "StreetSources",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vilages_Municipalities_MunicipalitiesId",
                table: "Vilages",
                column: "MunicipalitiesId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_AspNetUsers_ApplicationUserId",
                table: "Works",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
