using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicCRUDText.Migrations
{
    public partial class ChangeDepPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Students",
                newName: "DepId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                newName: "IX_Students_DepId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "DepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepId",
                table: "Students",
                column: "DepId",
                principalTable: "Departments",
                principalColumn: "DepId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "DepId",
                table: "Students",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepId",
                table: "Students",
                newName: "IX_Students_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "DepId",
                table: "Departments",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
