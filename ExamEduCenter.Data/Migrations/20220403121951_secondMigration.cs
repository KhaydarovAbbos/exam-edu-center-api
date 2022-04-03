using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamEduCenter.Data.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseType_CourseTypeId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseType",
                table: "CourseType");

            migrationBuilder.RenameTable(
                name: "CourseType",
                newName: "CourseTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTypes",
                table: "CourseTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseTypes_CourseTypeId",
                table: "Courses",
                column: "CourseTypeId",
                principalTable: "CourseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseTypes_CourseTypeId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTypes",
                table: "CourseTypes");

            migrationBuilder.RenameTable(
                name: "CourseTypes",
                newName: "CourseType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseType",
                table: "CourseType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseType_CourseTypeId",
                table: "Courses",
                column: "CourseTypeId",
                principalTable: "CourseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
