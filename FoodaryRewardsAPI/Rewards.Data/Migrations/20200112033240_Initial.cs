using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rewards.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountPromotions",
                columns: table => new
                {
                    DiscountPromotionId = table.Column<string>(nullable: false),
                    PromotionName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_DiscountPromotionId", x => x.DiscountPromotionId);
                });

            migrationBuilder.CreateTable(
                name: "PointsPromotions",
                columns: table => new
                {
                    PointsPromotionId = table.Column<string>(nullable: false),
                    PromotionName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Category = table.Column<string>(nullable: true),
                    PointsPerDollar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_PointsPromotionId", x => x.PointsPromotionId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ProductId", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "DiscountPromotionProducts",
                columns: table => new
                {
                    DiscountPromotionsProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountPromotionId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_DiscountPromotionsProductID", x => x.DiscountPromotionsProductID);
                    table.ForeignKey(
                        name: "FK_DiscountPromotionProducts_DiscountPromotion",
                        column: x => x.DiscountPromotionId,
                        principalTable: "DiscountPromotions",
                        principalColumn: "DiscountPromotionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountPromotionProducts_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DiscountPromotions",
                columns: new[] { "DiscountPromotionId", "DiscountPercent", "EndDate", "PromotionName", "StartDate" },
                values: new object[,]
                {
                    { "DP001", 20m, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fuel Discount Promo", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "DP002", 15m, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Happy Promo", new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PointsPromotions",
                columns: new[] { "PointsPromotionId", "Category", "EndDate", "PointsPerDollar", "PromotionName", "StartDate" },
                values: new object[,]
                {
                    { "PP001", "Any", new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, "New Year Promo", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PP002", "Fuel", new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, "Fuel Promo", new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PP003", "Shop", new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, "Shop Promo", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { "PRD01", "Fuel", "Vortex 95", 1.2m },
                    { "PRD02", "Fuel", "Vortex 98", 1.3m },
                    { "PRD03", "Fuel", "Diesel", 1.1m },
                    { "PRD04", "Shop", "Twix 55g", 2.3m },
                    { "PRD05", "Shop", "Mars 72g", 5.1m },
                    { "PRD06", "Shop", "SNICKERS 72G", 3.4m },
                    { "PRD07", "Shop", "Bounty 363g", 6.9m },
                    { "PRD08", "Shop", "Snickers 50g", 4.0m }
                });

            migrationBuilder.InsertData(
                table: "DiscountPromotionProducts",
                columns: new[] { "DiscountPromotionsProductID", "DiscountPromotionId", "ProductId" },
                values: new object[] { 1, "DP001", "PRD01" });

            migrationBuilder.InsertData(
                table: "DiscountPromotionProducts",
                columns: new[] { "DiscountPromotionsProductID", "DiscountPromotionId", "ProductId" },
                values: new object[] { 2, "DP001", "PRD02" });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountPromotionProducts_DiscountPromotionId",
                table: "DiscountPromotionProducts",
                column: "DiscountPromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountPromotionProducts_ProductId",
                table: "DiscountPromotionProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountPromotionProducts");

            migrationBuilder.DropTable(
                name: "PointsPromotions");

            migrationBuilder.DropTable(
                name: "DiscountPromotions");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
