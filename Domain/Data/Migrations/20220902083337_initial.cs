using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERegister.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Municipalities_MunicipalitiesId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_DemandsSpecifieds_AspNetUsers_AppliactionUsersId",
                table: "DemandsSpecifieds");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralDemands_Users_AspNetUsers_ApplicationUsersId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralDemands_Users_GeneralDemands_GeneralDemandsId",
                table: "GeneralDemands_Users");

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
                name: "FK_PollRelateds_PoliticalSubjects_PoliticalSubjectsId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_SuccessChances_SuccessChancesId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_Reasons_Users_AspNetUsers_ApplicationUsersId",
                table: "Reasons_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Reasons_Users_GeneralReasons_GeneralReasonsId",
                table: "Reasons_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificReasons_AspNetUsers_ApplicationUserId1",
                table: "SpecificReasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_StreetSources_StreetSourcesId",
                table: "Streets");

            migrationBuilder.DropForeignKey(
                name: "FK_Vilages_Municipalities_MunicipalitiesId",
                table: "Vilages");

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
                name: "IX_Reasons_Users_ApplicationUsersId",
                table: "Reasons_Users");

            migrationBuilder.DropIndex(
                name: "IX_Reasons_Users_GeneralReasonsId",
                table: "Reasons_Users");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_ApplicationUserId1",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_HelpsId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_PoliticalSubjectsId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_SuccessChancesId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_Neigborhoods_MunicipalitiesId",
                table: "Neigborhoods");

            migrationBuilder.DropIndex(
                name: "IX_Municipalities_RegionsId",
                table: "Municipalities");

            migrationBuilder.DropIndex(
                name: "IX_GeneralDemands_Users_ApplicationUsersId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropIndex(
                name: "IX_GeneralDemands_Users_GeneralDemandsId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_MunicipalitiesId",
                table: "Blocks");

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
                name: "ApplicationUsersId",
                table: "Reasons_Users");

            migrationBuilder.DropColumn(
                name: "GeneralReasonsId",
                table: "Reasons_Users");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PollRelateds");

            migrationBuilder.DropColumn(
                name: "HelpsId",
                table: "PollRelateds");

            migrationBuilder.DropColumn(
                name: "PoliticalSubjectsId",
                table: "PollRelateds");

            migrationBuilder.DropColumn(
                name: "SuccessChancesId",
                table: "PollRelateds");

            migrationBuilder.DropColumn(
                name: "MunicipalitiesId",
                table: "Neigborhoods");

            migrationBuilder.DropColumn(
                name: "RegionsId",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "ApplicationUsersId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropColumn(
                name: "GeneralDemandsId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DemandsSpecifieds");

            migrationBuilder.DropColumn(
                name: "MunicipalitiesId",
                table: "Blocks");

            migrationBuilder.RenameColumn(
                name: "WorkId",
                table: "PollRelateds",
                newName: "SuccessChanceId");

            migrationBuilder.RenameColumn(
                name: "AppliactionUsersId",
                table: "DemandsSpecifieds",
                newName: "AppliactionUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DemandsSpecifieds_AppliactionUsersId",
                table: "DemandsSpecifieds",
                newName: "IX_DemandsSpecifieds_AppliactionUserId");

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
                table: "Reasons_Users",
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

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "GeneralDemands_Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "IX_Reasons_Users_ApplicationUserId",
                table: "Reasons_Users",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reasons_Users_GeneralReasonId",
                table: "Reasons_Users",
                column: "GeneralReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_ApplicationUserId",
                table: "PollRelateds",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_HelpId",
                table: "PollRelateds",
                column: "HelpId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_PoliticalSubjectId",
                table: "PollRelateds",
                column: "PoliticalSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_SuccessChanceId",
                table: "PollRelateds",
                column: "SuccessChanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Neigborhoods_MunicipalityId",
                table: "Neigborhoods",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_RegionId",
                table: "Municipalities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDemands_Users_ApplicationUserId",
                table: "GeneralDemands_Users",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDemands_Users_GeneralDemandId",
                table: "GeneralDemands_Users",
                column: "GeneralDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_MunicipalityId",
                table: "Blocks",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Municipalities_MunicipalityId",
                table: "Blocks",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DemandsSpecifieds_AspNetUsers_AppliactionUserId",
                table: "DemandsSpecifieds",
                column: "AppliactionUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralDemands_Users_AspNetUsers_ApplicationUserId",
                table: "GeneralDemands_Users",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralDemands_Users_GeneralDemands_GeneralDemandId",
                table: "GeneralDemands_Users",
                column: "GeneralDemandId",
                principalTable: "GeneralDemands",
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
                name: "FK_PollRelateds_Helps_HelpId",
                table: "PollRelateds",
                column: "HelpId",
                principalTable: "Helps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_PoliticalSubjects_PoliticalSubjectId",
                table: "PollRelateds",
                column: "PoliticalSubjectId",
                principalTable: "PoliticalSubjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_SuccessChances_SuccessChanceId",
                table: "PollRelateds",
                column: "SuccessChanceId",
                principalTable: "SuccessChances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reasons_Users_AspNetUsers_ApplicationUserId",
                table: "Reasons_Users",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reasons_Users_GeneralReasons_GeneralReasonId",
                table: "Reasons_Users",
                column: "GeneralReasonId",
                principalTable: "GeneralReasons",
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
                name: "FK_Blocks_Municipalities_MunicipalityId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_DemandsSpecifieds_AspNetUsers_AppliactionUserId",
                table: "DemandsSpecifieds");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralDemands_Users_AspNetUsers_ApplicationUserId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralDemands_Users_GeneralDemands_GeneralDemandId",
                table: "GeneralDemands_Users");

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
                name: "FK_PollRelateds_Helps_HelpId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_PoliticalSubjects_PoliticalSubjectId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_PollRelateds_SuccessChances_SuccessChanceId",
                table: "PollRelateds");

            migrationBuilder.DropForeignKey(
                name: "FK_Reasons_Users_AspNetUsers_ApplicationUserId",
                table: "Reasons_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Reasons_Users_GeneralReasons_GeneralReasonId",
                table: "Reasons_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificReasons_AspNetUsers_ApplicationUserId",
                table: "SpecificReasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_StreetSources_StreetSourceId",
                table: "Streets");

            migrationBuilder.DropForeignKey(
                name: "FK_Vilages_Municipalities_MunicipalityId",
                table: "Vilages");

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
                name: "IX_Reasons_Users_ApplicationUserId",
                table: "Reasons_Users");

            migrationBuilder.DropIndex(
                name: "IX_Reasons_Users_GeneralReasonId",
                table: "Reasons_Users");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_ApplicationUserId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_HelpId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_PoliticalSubjectId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_PollRelateds_SuccessChanceId",
                table: "PollRelateds");

            migrationBuilder.DropIndex(
                name: "IX_Neigborhoods_MunicipalityId",
                table: "Neigborhoods");

            migrationBuilder.DropIndex(
                name: "IX_Municipalities_RegionId",
                table: "Municipalities");

            migrationBuilder.DropIndex(
                name: "IX_GeneralDemands_Users_ApplicationUserId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropIndex(
                name: "IX_GeneralDemands_Users_GeneralDemandId",
                table: "GeneralDemands_Users");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_MunicipalityId",
                table: "Blocks");

            migrationBuilder.RenameColumn(
                name: "SuccessChanceId",
                table: "PollRelateds",
                newName: "WorkId");

            migrationBuilder.RenameColumn(
                name: "AppliactionUserId",
                table: "DemandsSpecifieds",
                newName: "AppliactionUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_DemandsSpecifieds_AppliactionUserId",
                table: "DemandsSpecifieds",
                newName: "IX_DemandsSpecifieds_AppliactionUsersId");

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
                table: "Reasons_Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsersId",
                table: "Reasons_Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneralReasonsId",
                table: "Reasons_Users",
                type: "int",
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
                name: "HelpsId",
                table: "PollRelateds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PoliticalSubjectsId",
                table: "PollRelateds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuccessChancesId",
                table: "PollRelateds",
                type: "int",
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

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "GeneralDemands_Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsersId",
                table: "GeneralDemands_Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneralDemandsId",
                table: "GeneralDemands_Users",
                type: "int",
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
                name: "IX_Reasons_Users_ApplicationUsersId",
                table: "Reasons_Users",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reasons_Users_GeneralReasonsId",
                table: "Reasons_Users",
                column: "GeneralReasonsId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_ApplicationUserId1",
                table: "PollRelateds",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_HelpsId",
                table: "PollRelateds",
                column: "HelpsId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_PoliticalSubjectsId",
                table: "PollRelateds",
                column: "PoliticalSubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_SuccessChancesId",
                table: "PollRelateds",
                column: "SuccessChancesId");

            migrationBuilder.CreateIndex(
                name: "IX_Neigborhoods_MunicipalitiesId",
                table: "Neigborhoods",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_RegionsId",
                table: "Municipalities",
                column: "RegionsId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDemands_Users_ApplicationUsersId",
                table: "GeneralDemands_Users",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDemands_Users_GeneralDemandsId",
                table: "GeneralDemands_Users",
                column: "GeneralDemandsId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_MunicipalitiesId",
                table: "Blocks",
                column: "MunicipalitiesId");

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
                name: "FK_GeneralDemands_Users_AspNetUsers_ApplicationUsersId",
                table: "GeneralDemands_Users",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralDemands_Users_GeneralDemands_GeneralDemandsId",
                table: "GeneralDemands_Users",
                column: "GeneralDemandsId",
                principalTable: "GeneralDemands",
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
                name: "FK_PollRelateds_PoliticalSubjects_PoliticalSubjectsId",
                table: "PollRelateds",
                column: "PoliticalSubjectsId",
                principalTable: "PoliticalSubjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollRelateds_SuccessChances_SuccessChancesId",
                table: "PollRelateds",
                column: "SuccessChancesId",
                principalTable: "SuccessChances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reasons_Users_AspNetUsers_ApplicationUsersId",
                table: "Reasons_Users",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reasons_Users_GeneralReasons_GeneralReasonsId",
                table: "Reasons_Users",
                column: "GeneralReasonsId",
                principalTable: "GeneralReasons",
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
        }
    }
}
