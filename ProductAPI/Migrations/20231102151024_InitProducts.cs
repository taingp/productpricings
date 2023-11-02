using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    public partial class InitProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "117721dd-75f1-4d90-9d2b-3e209c5e90d8", (byte)4, "PRD003", new DateTime(2023, 11, 2, 22, 10, 24, 441, DateTimeKind.Local).AddTicks(3750), null, "TShirt-SEA game 2023" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "32295a53-e8ae-4207-8e94-987c78d94da8", (byte)32, "PRD002", new DateTime(2023, 11, 2, 22, 10, 24, 441, DateTimeKind.Local).AddTicks(3746), null, "Dream 125" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "ca1c1ed8-b2d1-430b-a184-a61d13ac3b70", (byte)1, "PRD001", new DateTime(2023, 11, 2, 22, 10, 24, 441, DateTimeKind.Local).AddTicks(3728), null, "Coca" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
