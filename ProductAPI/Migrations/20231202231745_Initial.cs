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
                name: "Pricing",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(36)", nullable: false),
                    EffectedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricing_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "48304f9d-31f1-42de-a995-8c221e23e19f", (byte)1, "PRD001", new DateTime(2023, 12, 3, 6, 17, 45, 498, DateTimeKind.Local).AddTicks(9389), null, "Coca" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "4e6a9f5c-5993-4886-9954-b957ecc0a420", (byte)4, "PRD003", new DateTime(2023, 12, 3, 6, 17, 45, 498, DateTimeKind.Local).AddTicks(9531), null, "TShirt-SEA game 2023" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "80e87162-07bd-4fa2-91d7-ac2cf6761da8", (byte)32, "PRD002", new DateTime(2023, 12, 3, 6, 17, 45, 498, DateTimeKind.Local).AddTicks(9525), null, "Dream 125" });

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_ProductId",
                table: "Pricing",
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
                name: "Pricing");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
