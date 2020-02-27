using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SOC.GEN.DealService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    asset_nm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currency_nm = table.Column<string>(nullable: true),
                    currency_symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deal_date = table.Column<DateTime>(nullable: false),
                    currency_Id = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    trader = table.Column<string>(nullable: true),
                    asset_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "asset_nm" },
                values: new object[,]
                {
                    { 1, "Rate" },
                    { 2, "Forex" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "currency_nm", "currency_symbol" },
                values: new object[,]
                {
                    { 1, "Rs", "Rs" },
                    { 2, "Dollar", "$" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Deals");
        }
    }
}
