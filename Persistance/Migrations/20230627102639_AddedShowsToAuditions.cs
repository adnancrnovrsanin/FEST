using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddedShowsToAuditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorAuditions");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("392699b9-b418-4575-a420-366e84e6181e"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("8aff5893-c7f3-4d41-ad19-4738f4d43e29"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("ae836ac2-e8e3-46d5-8e16-50ee8c306b6b"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("d119b7c7-1d5c-4eef-9211-a86c5d6dc209"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("efc42c21-dc77-45d2-ac98-07b8edda427e"));

            migrationBuilder.CreateTable(
                name: "ActorShowRoleAuditions",
                columns: table => new
                {
                    ActorId = table.Column<string>(type: "TEXT", nullable: false),
                    AuditionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShowRoleId = table.Column<Guid>(type: "TEXT", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("1844b0f9-26df-488f-af46-c4710ab29876"), "Beograd", new DateTime(2023, 10, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3444), "Festival 2", null, new DateTime(2023, 9, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3444), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("475c1703-f99a-4cb8-8f4f-f74cc5c15b82"), "Beograd", new DateTime(2023, 8, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3434), "Festival 1", null, new DateTime(2023, 7, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3428), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("660b182f-75e1-49c9-bc2d-cc460dc4ecb6"), "Beograd", new DateTime(2023, 12, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3451), "Festival 3", null, new DateTime(2023, 11, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3450), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("98611f2c-914e-4cec-b25f-f55933f40fae"), "Beograd", new DateTime(2024, 2, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3457), "Festival 4", null, new DateTime(2024, 1, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3456), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("c58672a3-6acf-4252-bd91-cf643ddc82e0"), "Beograd", new DateTime(2024, 4, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3463), "Festival 5", null, new DateTime(2024, 3, 27, 10, 26, 39, 357, DateTimeKind.Utc).AddTicks(3463), 36300 });

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoleAuditions_AuditionId",
                table: "ActorShowRoleAuditions",
                column: "AuditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoleAuditions_ShowRoleId",
                table: "ActorShowRoleAuditions",
                column: "ShowRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorShowRoleAuditions");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("1844b0f9-26df-488f-af46-c4710ab29876"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("475c1703-f99a-4cb8-8f4f-f74cc5c15b82"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("660b182f-75e1-49c9-bc2d-cc460dc4ecb6"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("98611f2c-914e-4cec-b25f-f55933f40fae"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("c58672a3-6acf-4252-bd91-cf643ddc82e0"));

            migrationBuilder.CreateTable(
                name: "ActorAuditions",
                columns: table => new
                {
                    ActorId = table.Column<string>(type: "TEXT", nullable: false),
                    AuditionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorAuditions", x => new { x.ActorId, x.AuditionId });
                    table.ForeignKey(
                        name: "FK_ActorAuditions_AspNetUsers_ActorId",
                        column: x => x.ActorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorAuditions_Auditions_AuditionId",
                        column: x => x.AuditionId,
                        principalTable: "Auditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("392699b9-b418-4575-a420-366e84e6181e"), "Beograd", new DateTime(2024, 4, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9930), "Festival 5", null, new DateTime(2024, 3, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9930), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("8aff5893-c7f3-4d41-ad19-4738f4d43e29"), "Beograd", new DateTime(2023, 8, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9902), "Festival 1", null, new DateTime(2023, 7, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9897), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("ae836ac2-e8e3-46d5-8e16-50ee8c306b6b"), "Beograd", new DateTime(2023, 12, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9918), "Festival 3", null, new DateTime(2023, 11, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9917), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("d119b7c7-1d5c-4eef-9211-a86c5d6dc209"), "Beograd", new DateTime(2024, 2, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9924), "Festival 4", null, new DateTime(2024, 1, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9923), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("efc42c21-dc77-45d2-ac98-07b8edda427e"), "Beograd", new DateTime(2023, 10, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9911), "Festival 2", null, new DateTime(2023, 9, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9910), 36300 });

            migrationBuilder.CreateIndex(
                name: "IX_ActorAuditions_AuditionId",
                table: "ActorAuditions",
                column: "AuditionId");
        }
    }
}
