using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class ChangedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowApplicationReviews");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ShowId",
                table: "ShowRoles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShowFestivalApplicationReviews",
                columns: table => new
                {
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: false),
                    ShowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FestivalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Acceptable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowFestivalApplicationReviews", x => new { x.ShowId, x.ReviewerId });
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplicationReviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplicationReviews_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowFestivalApplicationReviews_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("2cbf70ff-f822-4d06-a716-7986a5e40f51"), "Beograd", new DateTime(2023, 10, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(683), "Festival 2", null, new DateTime(2023, 9, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(682), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("4dde64ba-5a06-4879-80f6-21ddf31f13b9"), "Beograd", new DateTime(2024, 2, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(696), "Festival 4", null, new DateTime(2024, 1, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(695), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("d17df312-8412-4aa0-a014-b7488a3a2ffc"), "Beograd", new DateTime(2023, 8, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(674), "Festival 1", null, new DateTime(2023, 7, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(669), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("d3bfe2a9-95d8-4525-8bda-562549c45c20"), "Beograd", new DateTime(2024, 4, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(702), "Festival 5", null, new DateTime(2024, 3, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(701), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("e16ba146-d58c-499f-a433-14fdf975e904"), "Beograd", new DateTime(2023, 12, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(689), "Festival 3", null, new DateTime(2023, 11, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(689), 36300 });

            migrationBuilder.CreateIndex(
                name: "IX_ShowRoles_ShowId",
                table: "ShowRoles",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplicationReviews_FestivalId",
                table: "ShowFestivalApplicationReviews",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplicationReviews_ReviewerId",
                table: "ShowFestivalApplicationReviews",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowRoles_Shows_ShowId",
                table: "ShowRoles",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowRoles_Shows_ShowId",
                table: "ShowRoles");

            migrationBuilder.DropTable(
                name: "ShowFestivalApplicationReviews");

            migrationBuilder.DropIndex(
                name: "IX_ShowRoles_ShowId",
                table: "ShowRoles");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("2cbf70ff-f822-4d06-a716-7986a5e40f51"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("4dde64ba-5a06-4879-80f6-21ddf31f13b9"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("d17df312-8412-4aa0-a014-b7488a3a2ffc"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("d3bfe2a9-95d8-4525-8bda-562549c45c20"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("e16ba146-d58c-499f-a433-14fdf975e904"));

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "ShowRoles");

            migrationBuilder.CreateTable(
                name: "ShowApplicationReviews",
                columns: table => new
                {
                    ShowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReviewerId = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "IX_ShowApplicationReviews_ReviewerId",
                table: "ShowApplicationReviews",
                column: "ReviewerId");
        }
    }
}
