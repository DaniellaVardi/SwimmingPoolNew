using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimmingPoolNew.Migrations
{
    public partial class addAppointmentToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Appintments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Appintments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
