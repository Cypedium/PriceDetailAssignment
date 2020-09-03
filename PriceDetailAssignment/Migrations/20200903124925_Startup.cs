using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceDetailAssignment.Migrations
{
    public partial class Startup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PriceValuedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    CatalogEntryCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MarketId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PriceValuedId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
