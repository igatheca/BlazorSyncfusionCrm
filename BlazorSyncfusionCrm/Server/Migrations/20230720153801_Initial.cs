using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorSyncfusionCrm.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateOfBirth", "DateUpdated", "FirstName", "IsDeleted", "LastName", "NickName", "Place" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9410), new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9398), new DateTime(2001, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9395), "Peter", false, "Parker", "Spider-Man", "New York City" },
                    { 2, new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9491), new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9416), new DateTime(1970, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9414), "Tony", false, "Stark", "Iron Man", "Malibu" },
                    { 3, new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9501), new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9497), new DateTime(1915, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9495), "Bruce", false, "Wayne", "Batman", "Gotham City" }
                });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "ContactId", "DateCreated", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9863), "With great power comes great responsibility." },
                    { 2, 2, new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9869), "I am Iron Man" },
                    { 3, 3, new DateTime(2023, 7, 20, 11, 38, 1, 803, DateTimeKind.Local).AddTicks(9872), "I'm Batman!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_ContactId",
                table: "Note",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
