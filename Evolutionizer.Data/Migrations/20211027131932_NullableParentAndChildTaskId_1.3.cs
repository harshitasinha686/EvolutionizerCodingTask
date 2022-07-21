using Microsoft.EntityFrameworkCore.Migrations;

namespace Evolutionizer.Data.Migrations
{
    public partial class NullableParentAndChildTaskId_13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDependency_Tasks_ChildTaskId",
                table: "TaskDependency");

            migrationBuilder.AlterColumn<int>(
                name: "ParentTaskId",
                table: "TaskDependency",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChildTaskId",
                table: "TaskDependency",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDependency_Tasks_ChildTaskId",
                table: "TaskDependency",
                column: "ChildTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDependency_Tasks_ChildTaskId",
                table: "TaskDependency");

            migrationBuilder.AlterColumn<int>(
                name: "ParentTaskId",
                table: "TaskDependency",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChildTaskId",
                table: "TaskDependency",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDependency_Tasks_ChildTaskId",
                table: "TaskDependency",
                column: "ChildTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
