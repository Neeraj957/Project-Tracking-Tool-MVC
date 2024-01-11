using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Tracking_Tool_MVC.Migrations
{
    /// <inheritdoc />
    public partial class addedProjectandTasktablesinthismigrationupdatecolumninProjectEntityandTaskEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_taskId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_taskId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "taskId1",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "taskName",
                table: "Tasks",
                newName: "TaskName");

            migrationBuilder.RenameColumn(
                name: "taskDescription",
                table: "Tasks",
                newName: "TaskDescription");

            migrationBuilder.RenameColumn(
                name: "taskId",
                table: "Tasks",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "taskStatus",
                table: "Tasks",
                newName: "TaskDomain");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDeadlineDate",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TaskStartDate",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskDeadlineDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskStartDate",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Tasks",
                newName: "taskName");

            migrationBuilder.RenameColumn(
                name: "TaskDescription",
                table: "Tasks",
                newName: "taskDescription");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "taskId");

            migrationBuilder.RenameColumn(
                name: "TaskDomain",
                table: "Tasks",
                newName: "taskStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "taskId1",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_taskId1",
                table: "Tasks",
                column: "taskId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_taskId1",
                table: "Tasks",
                column: "taskId1",
                principalTable: "Tasks",
                principalColumn: "taskId");
        }
    }
}
