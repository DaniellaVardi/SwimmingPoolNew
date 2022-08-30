using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimmingPoolNew.Migrations
{
    public partial class AddTypeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Style",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "TypeClass",
                table: "Student",
                newName: "TypeStyle");

            migrationBuilder.AddColumn<int>(
                name: "TypeClassClassId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeClass",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeClass", x => x.ClassId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_TypeClassClassId",
                table: "Student",
                column: "TypeClassClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_TypeClass_TypeClassClassId",
                table: "Student",
                column: "TypeClassClassId",
                principalTable: "TypeClass",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_TypeClass_TypeClassClassId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "TypeClass");

            migrationBuilder.DropIndex(
                name: "IX_Student_TypeClassClassId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "TypeClassClassId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "TypeStyle",
                table: "Student",
                newName: "TypeClass");

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
