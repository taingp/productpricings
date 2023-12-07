using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    ProductId = table.Column<string>(type: "varchar(36)", nullable: false),
                    EffectedFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "41eb3bb0-1748-4f08-9ab3-4095456e3443", (byte)1, "PRD001", new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(1999), null, "Coca" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "54244d5f-ccb0-478f-a739-906e451a3f39", (byte)4, "PRD003", new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(2024), null, "TShirt-SEA game 2023" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "d302a420-a014-48ed-bfa6-42307e6b8e96", (byte)32, "PRD002", new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(2019), null, "Dream 125" });

            migrationBuilder.InsertData(
                table: "Pricings",
                columns: new[] { "Id", "CreatedOn", "EffectedFrom", "LastUpdatedOn", "ProductId", "Value" },
                values: new object[] { "17aacbe9-3008-4fb9-a66a-cbce91db79dd", new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(2071), new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(2056), null, "41eb3bb0-1748-4f08-9ab3-4095456e3443", 8.5m });

            migrationBuilder.InsertData(
                table: "Pricings",
                columns: new[] { "Id", "CreatedOn", "EffectedFrom", "LastUpdatedOn", "ProductId", "Value" },
                values: new object[] { "9c04f7ae-cf7b-4c72-ab95-01b684db8262", new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(2078), new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(2056), null, "d302a420-a014-48ed-bfa6-42307e6b8e96", 2350m });

            migrationBuilder.InsertData(
                table: "Pricings",
                columns: new[] { "Id", "CreatedOn", "EffectedFrom", "LastUpdatedOn", "ProductId", "Value" },
                values: new object[] { "e820be79-3f45-4b8c-803f-d7478a887f8a", new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(2081), new DateTime(2023, 12, 3, 10, 46, 52, 624, DateTimeKind.Local).AddTicks(2056), null, "54244d5f-ccb0-478f-a739-906e451a3f39", 5m });

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_ProductId",
                table: "Pricings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
