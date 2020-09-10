using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceDetailAssignment.Migrations
{
    public partial class Updated_with_Key_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceValuedId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    CatalogEntryCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MarketId = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
