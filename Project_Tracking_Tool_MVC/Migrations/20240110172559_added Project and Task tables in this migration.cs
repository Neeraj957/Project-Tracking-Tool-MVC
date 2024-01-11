using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Tracking_Tool_MVC.Migrations
{
    /// <inheritdoc />
    public partial class addedProjectandTasktablesinthismigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taskStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taskId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.taskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks_taskId1",
                        column: x => x.taskId1,
                        principalTable: "Tasks",
                        principalColumn: "taskId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_taskId1",
                table: "Tasks",
                column: "taskId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
