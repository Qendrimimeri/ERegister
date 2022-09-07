using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialNetwork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralDemands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    CanYouManage = table.Column<bool>(type: "bit", nullable: true),
                    ActivitiesYouPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedHelp = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificDemands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificDemands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StreetSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    WorkPlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Duty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdministrativeUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Works__Administr__60A75C0F",
                        column: x => x.AdministrativeUnitId,
                        principalTable: "AdministrativeUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneralDemands_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralDemandId = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDemands_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK__GeneralDe__Gener__02FC7413",
                        column: x => x.GeneralDemandId,
                        principalTable: "GeneralDemands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__GeneralDe__UserI__03F0984C",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Blocks__Municipa__5070F446",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Neighborh__Munic__534D60F1",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PollCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CenterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MunicipalitydId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PollCente__Munic__5BE2A6F2",
                        column: x => x.MunicipalitydId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Villages__Munici__4D94879B",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StreetSourceId = table.Column<int>(type: "int", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Streets__Municip__59063A47",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Streets__StreetS__5812160E",
                        column: x => x.StreetSourceId,
                        principalTable: "StreetSources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PollRelateds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamMembers = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PoliticalSubjectId = table.Column<int>(type: "int", nullable: true),
                    SuccessChancesID = table.Column<int>(type: "int", nullable: true),
                    GeneralReasonID = table.Column<int>(type: "int", nullable: true),
                    SpecificReasonId = table.Column<int>(type: "int", nullable: true),
                    SpecificDemandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollRelateds", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PollRelat__Gener__7C4F7684",
                        column: x => x.GeneralReasonID,
                        principalTable: "GeneralReasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PollRelat__Polit__7A672E12",
                        column: x => x.PoliticalSubjectId,
                        principalTable: "PoliticalSubjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PollRelat__Speci__7D439ABD",
                        column: x => x.SpecificReasonId,
                        principalTable: "SpecificReasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PollRelat__Speci__7E37BEF6",
                        column: x => x.SpecificDemandId,
                        principalTable: "SpecificDemands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PollRelat__Succe__7B5B524B",
                        column: x => x.SuccessChancesID,
                        principalTable: "SuccessChances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PollRelat__UserI__797309D9",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNo = table.Column<int>(type: "int", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    NeighborhoodId = table.Column<int>(type: "int", nullable: true),
                    BlockId = table.Column<int>(type: "int", nullable: true),
                    StreetId = table.Column<int>(type: "int", nullable: true),
                    PollCenterId = table.Column<int>(type: "int", nullable: true),
                    WorkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Addresses__Block__66603565",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Addresses__Munic__6383C8BA",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Addresses__Neigh__656C112C",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Addresses__PollC__68487DD7",
                        column: x => x.PollCenterId,
                        principalTable: "PollCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Addresses__Stree__6754599E",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Addresses__Villa__6477ECF3",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Addresses__WorkI__693CA210",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BlockId",
                table: "Addresses",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MunicipalityId",
                table: "Addresses",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeighborhoodId",
                table: "Addresses",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PollCenterId",
                table: "Addresses",
                column: "PollCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_VillageId",
                table: "Addresses",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_WorkId",
                table: "Addresses",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_MunicipalityId",
                table: "Blocks",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDemands_Users_GeneralDemandId",
                table: "GeneralDemands_Users",
                column: "GeneralDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDemands_Users_UserID",
                table: "GeneralDemands_Users",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_MunicipalityId",
                table: "Neighborhoods",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PollCenters_MunicipalitydId",
                table: "PollCenters",
                column: "MunicipalitydId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_GeneralReasonID",
                table: "PollRelateds",
                column: "GeneralReasonID");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_PoliticalSubjectId",
                table: "PollRelateds",
                column: "PoliticalSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_SpecificDemandId",
                table: "PollRelateds",
                column: "SpecificDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_SpecificReasonId",
                table: "PollRelateds",
                column: "SpecificReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_SuccessChancesID",
                table: "PollRelateds",
                column: "SuccessChancesID");

            migrationBuilder.CreateIndex(
                name: "IX_PollRelateds_UserID",
                table: "PollRelateds",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_MunicipalityId",
                table: "Streets",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_StreetSourceId",
                table: "Streets",
                column: "StreetSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_MunicipalityId",
                table: "Villages",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_AdministrativeUnitId",
                table: "Works",
                column: "AdministrativeUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualStatus");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "GeneralDemands_Users");

            migrationBuilder.DropTable(
                name: "Helps");

            migrationBuilder.DropTable(
                name: "PollRelateds");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "PollCenters");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "GeneralDemands");

            migrationBuilder.DropTable(
                name: "GeneralReasons");

            migrationBuilder.DropTable(
                name: "PoliticalSubjects");

            migrationBuilder.DropTable(
                name: "SpecificReasons");

            migrationBuilder.DropTable(
                name: "SpecificDemands");

            migrationBuilder.DropTable(
                name: "SuccessChances");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StreetSources");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "AdministrativeUnits");
        }
    }
}
