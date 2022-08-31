using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimmingPoolNew.Migrations
{
    public partial class addStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeStyle",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appintments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    styleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    classTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTeacherApproved = table.Column<bool>(type: "bit", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appintments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    StyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.StyleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_StyleId",
                table: "Student",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Style_StyleId",
                table: "Student",
                column: "StyleId",
                principalTable: "Style",
                principalColumn: "StyleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Style_StyleId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Appintments");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropIndex(
                name: "IX_Student_StyleId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "TypeStyle",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
