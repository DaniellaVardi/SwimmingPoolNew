using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimmingPoolNew.Migrations
{
    public partial class updateName1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "styleId",
                table: "Appintments",
                newName: "StyleId");

            migrationBuilder.RenameColumn(
                name: "classTypeId",
                table: "Appintments",
                newName: "ClassTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "TypeClass",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Appintments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Appintments");

            migrationBuilder.RenameColumn(
                name: "StyleId",
                table: "Appintments",
                newName: "styleId");

            migrationBuilder.RenameColumn(
                name: "ClassTypeId",
                table: "Appintments",
                newName: "classTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "TypeClass",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
