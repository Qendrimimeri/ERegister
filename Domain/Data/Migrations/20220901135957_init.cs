using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERegister.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActualStatusId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActualStatusesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialNetwork",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActualStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemandsSpecifieds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    AppliactionUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandsSpecifieds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandsSpecifieds_AspNetUsers_AppliactionUsersId",
                        column: x => x.AppliactionUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneralDemands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDemands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Helps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanYouManage = table.Column<bool>(type: "bit", nullable: false),
                    ActivitiesYouPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedHelp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterNumber = table.Column<int>(type: "int", nullable: true),
                    CenterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificReasons_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StreetSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuccessChances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuccessChances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeUnitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneralDemands_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralDemandId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    GeneralDemandsId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDemands_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralDemands_Users_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralDemands_Users_GeneralDemands_GeneralDemandsId",
                        column: x => x.GeneralDemandsId,
                        principalTable: "GeneralDemands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reasons_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralReasonId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    GeneralReasonsId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    RegionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipalities_Regions_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetSourceId = table.Column<int>(type: "int", nullable: true),
                    StreetSourcesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streets_StreetSources_StreetSourcesId",
                        column: x => x.StreetSourcesId,
                        principalTable: "StreetSources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PollRelateds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamMember = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PoliticalSubjectId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    SuccessChancesId = table.Column<int>(type: "int", nullable: true),
                    WorkId = table.Column<int>(type: "int", nullable: true),
                    HelpId = table.Column<int>(type: "int", nullable: true),
                    PoliticalSubjectsId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HelpsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollRelateds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollRelateds_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollRelateds_Helps_HelpsId",
                        column: x => x.HelpsId,
                        principalTable: "Helps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollRelateds_PoliticalSubjects_PoliticalSubjectsId",
                        column: x => x.PoliticalSubjectsId,
                        principalTable: "PoliticalSubjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollRelateds_SuccessChances_SuccessChancesId",
                        column: x => x.SuccessChancesId,
                        principalTable: "SuccessChances",
                        principalColumn: "Id");
                });

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
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    MunicipalitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Municipalities_MunicipalitiesId",
                        column: x => x.MunicipalitiesId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Neigborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    MunicipalitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neigborhoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neigborhoods_Municipalities_MunicipalitiesId",
                        column: x => x.MunicipalitiesId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vilages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    MunicipalitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vilages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vilages_Municipalities_MunicipalitiesId",
                        column: x => x.MunicipalitiesId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    NeigborhoodId = table.Column<int>(type: "int", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: true),
                    StreetId = table.Column<int>(type: "int", nullable: true),
                    PollCenterId = table.Column<int>(type: "int", nullable: true),
                    BlockId = table.Column<int>(type: "int", nullable: true),
                    MunicipalitiesId = table.Column<int>(type: "int", nullable: true),
                    VilagesId = table.Column<int>(type: "int", nullable: true),
                    NeigborhoodsId = table.Column<int>(type: "int", nullable: true),
                    HousesId = table.Column<int>(type: "int", nullable: true),
                    StreetsId = table.Column<int>(type: "int", nullable: true),
                    PollCentersId = table.Column<int>(type: "int", nullable: true),
                    BlocksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Blocks_BlocksId",
                        column: x => x.BlocksId,
                        principalTable: "Blocks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Houses_HousesId",
                        column: x => x.HousesId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Municipalities_MunicipalitiesId",
                        column: x => x.MunicipalitiesId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Neigborhoods_NeigborhoodsId",
                        column: x => x.NeigborhoodsId,
                        principalTable: "Neigborhoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_PollCenters_PollCentersId",
                        column: x => x.PollCentersId,
                        principalTable: "PollCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Streets_StreetsId",
                        column: x => x.StreetsId,
                        principalTable: "Streets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Vilages_VilagesId",
                        column: x => x.VilagesId,
                        principalTable: "Vilages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ActualStatusesId",
                table: "AspNetUsers",
                column: "ActualStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressesId",
                table: "AspNetUsers",
                column: "AddressesId");

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
                name: "IX_Blocks_MunicipalitiesId",
                table: "Blocks",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandsSpecifieds_AppliactionUsersId",
                table: "DemandsSpecifieds",
                column: "AppliactionUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDemands_Users_ApplicationUsersId",
                table: "GeneralDemands_Users",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDemands_Users_GeneralDemandsId",
                table: "GeneralDemands_Users",
                column: "GeneralDemandsId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_RegionsId",
                table: "Municipalities",
                column: "RegionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Neigborhoods_MunicipalitiesId",
                table: "Neigborhoods",
                column: "MunicipalitiesId");

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
                name: "IX_Reasons_Users_ApplicationUsersId",
                table: "Reasons_Users",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reasons_Users_GeneralReasonsId",
                table: "Reasons_Users",
                column: "GeneralReasonsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificReasons_ApplicationUserId1",
                table: "SpecificReasons",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_StreetSourcesId",
                table: "Streets",
                column: "StreetSourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vilages_MunicipalitiesId",
                table: "Vilages",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ApplicationUserId",
                table: "Works",
                column: "ApplicationUserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ActualStatuses_ActualStatusesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressesId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ActualStatuses");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AdministrativeUnitsWorks");

            migrationBuilder.DropTable(
                name: "DemandsSpecifieds");

            migrationBuilder.DropTable(
                name: "GeneralDemands_Users");

            migrationBuilder.DropTable(
                name: "PollRelateds");

            migrationBuilder.DropTable(
                name: "Reasons_Users");

            migrationBuilder.DropTable(
                name: "SpecificReasons");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Neigborhoods");

            migrationBuilder.DropTable(
                name: "PollCenters");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Vilages");

            migrationBuilder.DropTable(
                name: "AdministrativeUnits");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "GeneralDemands");

            migrationBuilder.DropTable(
                name: "Helps");

            migrationBuilder.DropTable(
                name: "PoliticalSubjects");

            migrationBuilder.DropTable(
                name: "SuccessChances");

            migrationBuilder.DropTable(
                name: "GeneralReasons");

            migrationBuilder.DropTable(
                name: "StreetSources");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ActualStatusesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ActualStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ActualStatusesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SocialNetwork",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "AspNetUsers");
        }
    }
}
