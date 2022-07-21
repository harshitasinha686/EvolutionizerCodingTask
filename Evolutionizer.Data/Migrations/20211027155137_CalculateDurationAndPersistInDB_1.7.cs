using Microsoft.EntityFrameworkCore.Migrations;

namespace Evolutionizer.Data.Migrations
{
    public partial class CalculateDurationAndPersistInDB_17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Programs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Programs");
        }
    }
}
