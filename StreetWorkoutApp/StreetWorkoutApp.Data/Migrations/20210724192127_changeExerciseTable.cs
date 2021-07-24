using Microsoft.EntityFrameworkCore.Migrations;

namespace StreetWorkoutApp.Data.Migrations
{
    public partial class changeExerciseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Example",
                table: "Exercises",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "ExampleUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExampleUrl",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Exercises",
                newName: "Example");
        }
    }
}
