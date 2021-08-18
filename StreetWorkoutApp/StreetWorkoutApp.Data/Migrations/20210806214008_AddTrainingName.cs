using Microsoft.EntityFrameworkCore.Migrations;

namespace StreetWorkoutApp.Data.Migrations
{
    public partial class AddTrainingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Trainings");
        }
    }
}
