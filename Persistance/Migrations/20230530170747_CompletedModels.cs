using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class CompletedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorAuditions",
                table: "ActorAuditions");

            migrationBuilder.DropColumn(
                name: "VideoURL",
                table: "ActorAuditions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ActorAuditions",
                newName: "AuditionId");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizerId",
                table: "Festivals",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActorId",
                table: "ActorAuditions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorAuditions",
                table: "ActorAuditions",
                columns: new[] { "ActorId", "AuditionId" });

            migrationBuilder.CreateTable(
                name: "ActorShowRoles",
                columns: table => new
                {
                    ActorId = table.Column<string>(type: "TEXT", nullable: false),
                    ShowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pay = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorShowRoles", x => new { x.ActorId, x.RoleId, x.ShowId });
                    table.ForeignKey(
                        name: "FK_ActorShowRoles_AspNetUsers_ActorId",
                        column: x => x.ActorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorShowRoles_ShowRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ShowRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorShowRoles_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VideoURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeOfPlay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LengthOfPlay = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShowApplicationReviews",
                columns: table => new
                {
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: false),
                    ShowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Acceptable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowApplicationReviews", x => new { x.ShowId, x.ReviewerId });
                    table.ForeignKey(
                        name: "FK_ShowApplicationReviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowApplicationReviews_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheatreShows",
                columns: table => new
                {
                    TheatreId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfActors = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheatreShows", x => new { x.TheatreId, x.ShowId });
                    table.ForeignKey(
                        name: "FK_TheatreShows_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheatreShows_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditionReviews",
                columns: table => new
                {
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: false),
                    AuditionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Review = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditionReviews", x => new { x.AuditionId, x.ReviewerId });
                    table.ForeignKey(
                        name: "FK_AuditionReviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditionReviews_Auditions_AuditionId",
                        column: x => x.AuditionId,
                        principalTable: "Auditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheaterShowSchedules",
                columns: table => new
                {
                    TheatreId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheaterShowSchedules", x => new { x.TheatreId, x.ShowId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_TheaterShowSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheaterShowSchedules_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheaterShowSchedules_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Festivals_OrganizerId",
                table: "Festivals",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAuditions_AuditionId",
                table: "ActorAuditions",
                column: "AuditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoles_RoleId",
                table: "ActorShowRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoles_ShowId",
                table: "ActorShowRoles",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditionReviews_ReviewerId",
                table: "AuditionReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowApplicationReviews_ReviewerId",
                table: "ShowApplicationReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterShowSchedules_ScheduleId",
                table: "TheaterShowSchedules",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterShowSchedules_ShowId",
                table: "TheaterShowSchedules",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TheatreShows_ShowId",
                table: "TheatreShows",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAuditions_AspNetUsers_ActorId",
                table: "ActorAuditions",
                column: "ActorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAuditions_Auditions_AuditionId",
                table: "ActorAuditions",
                column: "AuditionId",
                principalTable: "Auditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Festivals_Theatres_OrganizerId",
                table: "Festivals",
                column: "OrganizerId",
                principalTable: "Theatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorAuditions_AspNetUsers_ActorId",
                table: "ActorAuditions");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorAuditions_Auditions_AuditionId",
                table: "ActorAuditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Festivals_Theatres_OrganizerId",
                table: "Festivals");

            migrationBuilder.DropTable(
                name: "ActorShowRoles");

            migrationBuilder.DropTable(
                name: "AuditionReviews");

            migrationBuilder.DropTable(
                name: "ShowApplicationReviews");

            migrationBuilder.DropTable(
                name: "TheaterShowSchedules");

            migrationBuilder.DropTable(
                name: "TheatreShows");

            migrationBuilder.DropTable(
                name: "Auditions");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Festivals_OrganizerId",
                table: "Festivals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorAuditions",
                table: "ActorAuditions");

            migrationBuilder.DropIndex(
                name: "IX_ActorAuditions_AuditionId",
                table: "ActorAuditions");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "ActorAuditions");

            migrationBuilder.RenameColumn(
                name: "AuditionId",
                table: "ActorAuditions",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                table: "ActorAuditions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorAuditions",
                table: "ActorAuditions",
                column: "Id");
        }
    }
}
