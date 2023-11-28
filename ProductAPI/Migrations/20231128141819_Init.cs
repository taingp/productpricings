using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    public partial class Init : Migration
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(36)", nullable: false),
                    EffectedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "0ed9b79a-6323-454c-aa77-d5d972f542ea", (byte)4, "PRD003", new DateTime(2023, 11, 28, 21, 18, 19, 650, DateTimeKind.Local).AddTicks(5489), null, "TShirt-SEA game 2023" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "777ae460-4890-4d5c-a86f-0acb0c4c25bb", (byte)1, "PRD001", new DateTime(2023, 11, 28, 21, 18, 19, 650, DateTimeKind.Local).AddTicks(5460), null, "Coca" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { "f420f3fe-95d8-48cf-9c6e-78c0d0249df3", (byte)32, "PRD002", new DateTime(2023, 11, 28, 21, 18, 19, 650, DateTimeKind.Local).AddTicks(5482), null, "Dream 125" });

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
