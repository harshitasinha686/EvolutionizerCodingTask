using Microsoft.EntityFrameworkCore.Migrations;

namespace Evolutionizer.Data.Migrations
{
    public partial class CreateTaskDependency_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskDependency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentTaskId = table.Column<int>(type: "int", nullable: false),
                    ChildTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDependency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDependency_Tasks_ChildTaskId",
                        column: x => x.ChildTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskDependency_Tasks_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDependency_ChildTaskId",
                table: "TaskDependency",
                column: "ChildTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDependency_ParentTaskId",
                table: "TaskDependency",
                column: "ParentTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDependency");
        }
    }
}
