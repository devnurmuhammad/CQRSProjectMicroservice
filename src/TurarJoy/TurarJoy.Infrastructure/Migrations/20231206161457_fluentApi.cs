using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurarJoy.Infrastructure.Migrations
{
    public partial class fluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HouseBuildingCompany",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, "Tashkent", "MuradBuildings2023@gmail.com", "Murad Buildings", "+998714522145" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HouseBuildingCompany",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
