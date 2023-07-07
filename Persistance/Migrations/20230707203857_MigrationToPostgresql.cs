using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistance.Migrations
{
    public partial class MigrationToPostgresql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VideoURL = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SerialNumber = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DirectorName = table.Column<string>(type: "text", nullable: true),
                    StoryWriterName = table.Column<string>(type: "text", nullable: true),
                    LengthOfPlay = table.Column<int>(type: "integer", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Theatres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    YearOfCreation = table.Column<int>(type: "integer", nullable: false),
                    ManagerId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theatres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theatres_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditionReviews",
                columns: table => new
                {
                    ReviewerId = table.Column<string>(type: "text", nullable: false),
                    AuditionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Review = table.Column<double>(type: "double precision", nullable: false)
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
                name: "ShowRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ShowId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowRoles_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ZipCode = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    OrganizerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Festivals_Theatres_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheatreShows",
                columns: table => new
                {
                    TheatreId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfActors = table.Column<int>(type: "integer", nullable: false)
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
                name: "TheatreShowSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TheatreId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheatreShowSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheatreShowSchedules_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TheatreShowSchedules_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorShowRoleAuditions",
                columns: table => new
                {
                    ActorId = table.Column<string>(type: "text", nullable: false),
                    AuditionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowRoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorShowRoleAuditions", x => new { x.ActorId, x.AuditionId, x.ShowRoleId });
                    table.ForeignKey(
                        name: "FK_ActorShowRoleAuditions_AspNetUsers_ActorId",
                        column: x => x.ActorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorShowRoleAuditions_Auditions_AuditionId",
                        column: x => x.AuditionId,
                        principalTable: "Auditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorShowRoleAuditions_ShowRoles_ShowRoleId",
                        column: x => x.ShowRoleId,
                        principalTable: "ShowRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorShowRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ActorId = table.Column<string>(type: "text", nullable: true),
                    ShowId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Pay = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorShowRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorShowRoles_AspNetUsers_ActorId",
                        column: x => x.ActorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                name: "ShowFestivalApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowId = table.Column<Guid>(type: "uuid", nullable: false),
                    FestivalId = table.Column<Guid>(type: "uuid", nullable: false),
                    TheatreId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfActors = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowFestivalApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplications_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplications_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplications_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeOfPlay = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LengthOfPlay = table.Column<int>(type: "integer", nullable: false),
                    FestivalId = table.Column<Guid>(type: "uuid", nullable: false),
                    TheatreShowScheduleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_TheatreShowSchedules_TheatreShowScheduleId",
                        column: x => x.TheatreShowScheduleId,
                        principalTable: "TheatreShowSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowFestivalApplicationReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewerId = table.Column<string>(type: "text", nullable: true),
                    ShowFestivalApplicationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Acceptable = table.Column<bool>(type: "boolean", nullable: false),
                    ShowId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowFestivalApplicationReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplicationReviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplicationReviews_ShowFestivalApplications_Sho~",
                        column: x => x.ShowFestivalApplicationId,
                        principalTable: "ShowFestivalApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplicationReviews_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("296074d9-28f6-4beb-bb23-9490e1e0ab6c"), "Beograd", new DateTime(2023, 11, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4175), "Festival 2", null, new DateTime(2023, 10, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4174), 36300 },
                    { new Guid("4506a2e2-17d2-46e2-96ea-3f6ff42831b2"), "Beograd", new DateTime(2024, 5, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4196), "Festival 5", null, new DateTime(2024, 4, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4194), 36300 },
                    { new Guid("629bd6d5-be2b-4348-bdbf-34d3af7f8de7"), "Beograd", new DateTime(2024, 1, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4181), "Festival 3", null, new DateTime(2023, 12, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4181), 36300 },
                    { new Guid("926a6755-ce4b-40a6-a2b3-5d667db816aa"), "Beograd", new DateTime(2024, 3, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4188), "Festival 4", null, new DateTime(2024, 2, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4188), 36300 },
                    { new Guid("a553b5f9-220c-4f45-91e5-9419f7baf575"), "Beograd", new DateTime(2023, 9, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4166), "Festival 1", null, new DateTime(2023, 8, 7, 20, 38, 57, 752, DateTimeKind.Utc).AddTicks(4160), 36300 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoleAuditions_AuditionId",
                table: "ActorShowRoleAuditions",
                column: "AuditionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoleAuditions_ShowRoleId",
                table: "ActorShowRoleAuditions",
                column: "ShowRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoles_ActorId",
                table: "ActorShowRoles",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoles_RoleId",
                table: "ActorShowRoles",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoles_ShowId",
                table: "ActorShowRoles",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditionReviews_ReviewerId",
                table: "AuditionReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Festivals_OrganizerId",
                table: "Festivals",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AppUserId",
                table: "RefreshToken",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_FestivalId",
                table: "Schedules",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TheatreShowScheduleId",
                table: "Schedules",
                column: "TheatreShowScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplicationReviews_ReviewerId",
                table: "ShowFestivalApplicationReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplicationReviews_ShowFestivalApplicationId",
                table: "ShowFestivalApplicationReviews",
                column: "ShowFestivalApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplicationReviews_ShowId",
                table: "ShowFestivalApplicationReviews",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplications_FestivalId",
                table: "ShowFestivalApplications",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplications_ShowId",
                table: "ShowFestivalApplications",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplications_TheatreId",
                table: "ShowFestivalApplications",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowRoles_ShowId",
                table: "ShowRoles",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Theatres_ManagerId",
                table: "Theatres",
                column: "ManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TheatreShows_ShowId",
                table: "TheatreShows",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TheatreShowSchedules_ShowId",
                table: "TheatreShowSchedules",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TheatreShowSchedules_TheatreId",
                table: "TheatreShowSchedules",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorShowRoleAuditions");

            migrationBuilder.DropTable(
                name: "ActorShowRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditionReviews");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "ShowFestivalApplicationReviews");

            migrationBuilder.DropTable(
                name: "TheatreShows");

            migrationBuilder.DropTable(
                name: "ShowRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Auditions");

            migrationBuilder.DropTable(
                name: "TheatreShowSchedules");

            migrationBuilder.DropTable(
                name: "ShowFestivalApplications");

            migrationBuilder.DropTable(
                name: "Festivals");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Theatres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
