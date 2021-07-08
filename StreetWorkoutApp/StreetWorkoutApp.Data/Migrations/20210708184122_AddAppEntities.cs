using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StreetWorkoutApp.Data.Migrations
{
    public partial class AddAppEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Example = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentExercise",
                columns: table => new
                {
                    EquipmentNeededId = table.Column<int>(type: "int", nullable: false),
                    ExercisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentExercise", x => new { x.EquipmentNeededId, x.ExercisesId });
                    table.ForeignKey(
                        name: "FK_EquipmentExercise_Equipments_EquipmentNeededId",
                        column: x => x.EquipmentNeededId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentExercise_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CyclesCount = table.Column<int>(type: "int", nullable: false),
                    BreakBetweenExercises = table.Column<TimeSpan>(type: "time", nullable: false),
                    BreakBetweenCycles = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsIndoor = table.Column<bool>(type: "bit", nullable: false),
                    GoalExerciseId = table.Column<int>(type: "int", nullable: true),
                    TrainingLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Exercises_GoalExerciseId",
                        column: x => x.GoalExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: true),
                    TrainingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MuscleGroups_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MuscleGroups_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingsExercises",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsExercises", x => new { x.TrainingId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_TrainingsExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingsExercises_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentExercise_ExercisesId",
                table: "EquipmentExercise",
                column: "ExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_MuscleGroups_ExerciseId",
                table: "MuscleGroups",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_MuscleGroups_TrainingId",
                table: "MuscleGroups",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_GoalExerciseId",
                table: "Trainings",
                column: "GoalExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingsExercises_ExerciseId",
                table: "TrainingsExercises",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentExercise");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropTable(
                name: "TrainingsExercises");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}
