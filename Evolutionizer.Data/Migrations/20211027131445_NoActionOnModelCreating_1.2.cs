using Microsoft.EntityFrameworkCore.Migrations;

namespace Evolutionizer.Data.Migrations
{
    public partial class NoActionOnModelCreating_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDependency_Tasks_ParentTaskId",
                table: "TaskDependency");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDependency_Tasks_ParentTaskId",
                table: "TaskDependency",
                column: "ParentTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDependency_Tasks_ParentTaskId",
                table: "TaskDependency");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDependency_Tasks_ParentTaskId",
                table: "TaskDependency",
                column: "ParentTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
