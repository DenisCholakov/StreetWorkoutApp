using Microsoft.EntityFrameworkCore.Migrations;

namespace StreetWorkoutApp.Data.Migrations
{
    public partial class manyToManyForMuscleGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroups_Exercises_ExerciseId",
                table: "MuscleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroups_Trainings_TrainingId",
                table: "MuscleGroups");

            migrationBuilder.DropIndex(
                name: "IX_MuscleGroups_ExerciseId",
                table: "MuscleGroups");

            migrationBuilder.DropIndex(
                name: "IX_MuscleGroups_TrainingId",
                table: "MuscleGroups");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "MuscleGroups");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "MuscleGroups");

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroup",
                columns: table => new
                {
                    ExercisesForMuscleGroupId = table.Column<int>(type: "int", nullable: false),
                    MuscleGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroup", x => new { x.ExercisesForMuscleGroupId, x.MuscleGroupsId });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroup_Exercises_ExercisesForMuscleGroupId",
                        column: x => x.ExercisesForMuscleGroupId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroup_MuscleGroups_MuscleGroupsId",
                        column: x => x.MuscleGroupsId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroupTraining",
                columns: table => new
                {
                    MuscleGroupsId = table.Column<int>(type: "int", nullable: false),
                    TrainingsForMuscleGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroupTraining", x => new { x.MuscleGroupsId, x.TrainingsForMuscleGroupId });
                    table.ForeignKey(
                        name: "FK_MuscleGroupTraining_MuscleGroups_MuscleGroupsId",
                        column: x => x.MuscleGroupsId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuscleGroupTraining_Trainings_TrainingsForMuscleGroupId",
                        column: x => x.TrainingsForMuscleGroupId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscleGroup_MuscleGroupsId",
                table: "ExerciseMuscleGroup",
                column: "MuscleGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_MuscleGroupTraining_TrainingsForMuscleGroupId",
                table: "MuscleGroupTraining",
                column: "TrainingsForMuscleGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroup");

            migrationBuilder.DropTable(
                name: "MuscleGroupTraining");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "MuscleGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "MuscleGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MuscleGroups_ExerciseId",
                table: "MuscleGroups",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_MuscleGroups_TrainingId",
                table: "MuscleGroups",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroups_Exercises_ExerciseId",
                table: "MuscleGroups",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroups_Trainings_TrainingId",
                table: "MuscleGroups",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
