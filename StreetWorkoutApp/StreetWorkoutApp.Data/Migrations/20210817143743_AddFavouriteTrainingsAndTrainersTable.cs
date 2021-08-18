using Microsoft.EntityFrameworkCore.Migrations;

namespace StreetWorkoutApp.Data.Migrations
{
    public partial class AddFavouriteTrainingsAndTrainersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserExercise_AspNetUsers_UsersId",
                table: "AppUserExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserExercise_Exercises_ExercisesId",
                table: "AppUserExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserExercise",
                table: "AppUserExercise");

            migrationBuilder.DropIndex(
                name: "IX_AppUserExercise_UsersId",
                table: "AppUserExercise");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "AppUserExercise",
                newName: "BookmarkedUsersId");

            migrationBuilder.RenameColumn(
                name: "ExercisesId",
                table: "AppUserExercise",
                newName: "FavouriteExercisesId");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserExercise",
                table: "AppUserExercise",
                columns: new[] { "BookmarkedUsersId", "FavouriteExercisesId" });

            migrationBuilder.CreateTable(
                name: "AppUserTraining",
                columns: table => new
                {
                    BookmarkedUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavouriteTrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTraining", x => new { x.BookmarkedUsersId, x.FavouriteTrainingsId });
                    table.ForeignKey(
                        name: "FK_AppUserTraining_AspNetUsers_BookmarkedUsersId",
                        column: x => x.BookmarkedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTraining_Trainings_FavouriteTrainingsId",
                        column: x => x.FavouriteTrainingsId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CreatorId",
                table: "Trainings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CreatorId",
                table: "Exercises",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserExercise_FavouriteExercisesId",
                table: "AppUserExercise",
                column: "FavouriteExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTraining_FavouriteTrainingsId",
                table: "AppUserTraining",
                column: "FavouriteTrainingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserExercise_AspNetUsers_BookmarkedUsersId",
                table: "AppUserExercise",
                column: "BookmarkedUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserExercise_Exercises_FavouriteExercisesId",
                table: "AppUserExercise",
                column: "FavouriteExercisesId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainers_CreatorId",
                table: "Exercises",
                column: "CreatorId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Trainers_CreatorId",
                table: "Trainings",
                column: "CreatorId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserExercise_AspNetUsers_BookmarkedUsersId",
                table: "AppUserExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserExercise_Exercises_FavouriteExercisesId",
                table: "AppUserExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainers_CreatorId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Trainers_CreatorId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "AppUserTraining");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CreatorId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_CreatorId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserExercise",
                table: "AppUserExercise");

            migrationBuilder.DropIndex(
                name: "IX_AppUserExercise_FavouriteExercisesId",
                table: "AppUserExercise");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "FavouriteExercisesId",
                table: "AppUserExercise",
                newName: "ExercisesId");

            migrationBuilder.RenameColumn(
                name: "BookmarkedUsersId",
                table: "AppUserExercise",
                newName: "UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserExercise",
                table: "AppUserExercise",
                columns: new[] { "ExercisesId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserExercise_UsersId",
                table: "AppUserExercise",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserExercise_AspNetUsers_UsersId",
                table: "AppUserExercise",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserExercise_Exercises_ExercisesId",
                table: "AppUserExercise",
                column: "ExercisesId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
