using Microsoft.EntityFrameworkCore.Migrations;

namespace SOC.GEN.DealService.Migrations
{
    public partial class addingcountrycolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "country_id",
                table: "Deals",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "country_id",
                table: "Deals");
        }
    }
}
