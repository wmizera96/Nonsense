using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nonsense.Data.MigrationRunner.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexForNonsenseTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "NonsenseTasks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "NonsenseTasks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonsenseTasks",
                table: "NonsenseTasks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NonsenseTasks_Name",
                table: "NonsenseTasks",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NonsenseTasks",
                table: "NonsenseTasks");

            migrationBuilder.DropIndex(
                name: "IX_NonsenseTasks_Name",
                table: "NonsenseTasks");

            migrationBuilder.RenameTable(
                name: "NonsenseTasks",
                newName: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");
        }
    }
}
