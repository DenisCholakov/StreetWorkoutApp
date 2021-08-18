using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StreetWorkoutApp.Data.Migrations
{
    public partial class addDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Trainers_CreatorId",
                table: "Trainings");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f7ff7003-9468-49f5-979a-8138bcf8d480", "aa0c05f0-ebf6-4ba8-b5f0-e05b798e1e6a", "Admin", "ADMIN" },
                    { "f3b35b36-e0ad-479b-9855-35a6a785173c", "40a4d759-a0fd-4742-ac08-91c24d18a77c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b2b201e9-8c95-4d19-89c3-28184f48b1d5", 0, "52a1d00c-4f03-4749-b437-41c98047908e", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEEuWZTciHQ1QuJtE5LM7R+vLtetWSuowW8b3VpZ0MdYq53ighqcuyompPWbrU9fdAQ==", null, false, "9254b2c1-ebff-4cab-af09-30047df56720", false, "admin" },
                    { "f8406549-4a2e-4401-9fb8-d06992ef6afd", 0, "b9c0ed80-3817-4cc2-a005-d09e3790ec39", "test@test.com", false, false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEJpubPuauAQj7Y5Y2ln4qMJHNXJGDumtCrMahiP8/i1meqBH4v8Sn5pG7tE6Ccb2Ig==", null, false, "425298d9-2de6-4af1-afe2-6092cfb6681c", false, "test" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://m.media-amazon.com/images/I/81CIL-7+n3L._AC_SX425_.jpg", "Dumbells" },
                    { 2, "https://rukminim1.flixcart.com/image/416/416/k37mg7k0/pilates-ring/9/t/g/wooden-gymnastics-roman-rings-wxws-original-imafh2yxqpahjwjx.jpeg?q=70", "Rings" },
                    { 3, "https://i.pinimg.com/564x/d5/e4/53/d5e45313b036eb890d6e918a3428be8b.jpg", "Pull Up Bar" },
                    { 4, "https://kengurupro.eu/wp-content/uploads/2021/01/P-003-1.jpg", "Parallels" }
                });

            migrationBuilder.InsertData(
                table: "MuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13, "Glutes" },
                    { 12, "Calves" },
                    { 11, "HamStrings" },
                    { 10, "Quadriceps" },
                    { 9, "Forearms" },
                    { 8, "Abs" },
                    { 4, "Traps" },
                    { 6, "Upper Back" },
                    { 5, "Triceps" },
                    { 14, "Neck" },
                    { 3, "Biceps" },
                    { 2, "Chest" },
                    { 1, "Shoulders" },
                    { 7, "Lower Back" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "UserId", "UserName" },
                values: new object[] { 1, "b2b201e9-8c95-4d19-89c3-28184f48b1d5", "admin" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatorId", "Description", "ExampleUrl", "ExerciseLevel", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 1, "This exercise is performed on rings. The performer must go on top of the rings and open his arms as wide as possible.", null, 3, "https://image.shutterstock.com/image-illustration/gymnast-performing-iron-cross-on-260nw-1586582845.jpg", "Iron cross" },
                    { 2, 1, "A front lever is performed by lowering from an inverted hang until the body is completely horizontal and straight with the front of the body facing upwards", null, 3, "https://image.shutterstock.com/image-vector/muscular-man-doing-front-lever-260nw-1687648483.jpg", "Fron lever" },
                    { 3, 1, "A back lever is performed by lowering from an inverted hang until the body is completely horizontal and straight with the front of the body facing backwards.", null, 2, "https://flighttrainingfitness.files.wordpress.com/2018/06/back-lever.png", "Back lever" },
                    { 4, 1, "A pullup is a challenging upper body exercise where you grip an overhead bar and lift your body until your chin is above that bar.", null, 1, "https://i.stack.imgur.com/AY9Xl.png", "Pull up" },
                    { 5, 1, "Conditioning exercise performed in a prone position by raising and lowering the body with the straightening and bending of the arms while keeping the back straight and supporting the body on the hands and toes.", null, 1, "https://physicalculturestudy.com/wp-content/uploads/2018/01/pushup.png", "Push up" },
                    { 6, 1, "Hanging from a bar by your extended arms, you raise your legs parallel to the ground.", null, 1, "https://www.gymguider.com/wp-content/uploads/2017/07/Hanging_Leg_Raise.jpg", "Hanging leg raises 90" },
                    { 7, 1, "Hanging from a bar lift your toes to the bar and start rotating your legs to each side. One rep is moving your toes once to the left and once to the right.", null, 1, "https://www.mensjournal.com/wp-content/uploads/2019/01/hangingwindshieldwipers.jpg?w=700&quality=86&strip=all", "Whipers" },
                    { 8, 1, "Hanging from a bar lift your toes to the bar and hold for 2 seconds, then slowly lower your legs.", null, 1, "https://cdn-xi3mbccdkztvoept8hl.netdna-ssl.com/wp-content/uploads/watermarked/Hanging_Leg_Raises_to_Bar-1.png", "Leg raises to bar" },
                    { 9, 1, "Hanging from a bar lift your body in the front lever position and then slowly bring it back to hanging position", null, 2, "https://i.pinimg.com/736x/dd/f0/da/ddf0daa00c840e4020f6edc31ad29f89.jpg", "Front lever raises" },
                    { 10, 1, "Hanging from a bar lift your knees up to ypur chest and then bring them back.", null, 1, "http://1bodyweighttraining.com/wp-content/uploads/2018/04/hanging-knee-raises.png", "Knee raises" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "BreakBetweenCycles", "BreakBetweenExercises", "CreatorId", "CyclesCount", "Description", "GoalExerciseId", "IsIndoor", "Name", "TrainingLevel" },
                values: new object[] { 1, new TimeSpan(0, 0, 1, 0, 0), new TimeSpan(0, 0, 0, 10, 0), 1, 5, "This is a trainigng for abs. It's really useable for front lever. The trainings should be performed outside.", null, false, "Abs routine", 1 });

            migrationBuilder.InsertData(
                table: "EquipmentExercise",
                columns: new[] { "EquipmentNeededId", "ExercisesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 7 },
                    { 3, 10 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 6 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroup",
                columns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                values: new object[,]
                {
                    { 7, 6 },
                    { 7, 7 },
                    { 7, 8 },
                    { 7, 9 },
                    { 8, 1 },
                    { 8, 9 },
                    { 8, 8 },
                    { 9, 1 },
                    { 9, 7 },
                    { 9, 8 },
                    { 9, 9 },
                    { 10, 8 },
                    { 10, 9 },
                    { 8, 6 },
                    { 6, 9 },
                    { 6, 10 },
                    { 3, 1 },
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 9 },
                    { 2, 1 },
                    { 2, 7 },
                    { 2, 8 },
                    { 6, 8 },
                    { 3, 6 },
                    { 3, 2 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 9 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroup",
                columns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                values: new object[,]
                {
                    { 5, 5 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "MuscleGroupTraining",
                columns: new[] { "MuscleGroupsId", "TrainingsForMuscleGroupId" },
                values: new object[,]
                {
                    { 9, 1 },
                    { 7, 1 },
                    { 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "TrainingsExercises",
                columns: new[] { "ExerciseId", "TrainingId", "Reps" },
                values: new object[,]
                {
                    { 7, 1, 10 },
                    { 8, 1, 10 },
                    { 6, 1, 10 },
                    { 10, 1, 30 }
                });

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
                name: "FK_Trainings_Trainers_CreatorId",
                table: "Trainings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b35b36-e0ad-479b-9855-35a6a785173c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ff7003-9468-49f5-979a-8138bcf8d480");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2b201e9-8c95-4d19-89c3-28184f48b1d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8406549-4a2e-4401-9fb8-d06992ef6afd");

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "EquipmentExercise",
                keyColumns: new[] { "EquipmentNeededId", "ExercisesId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroup",
                keyColumns: new[] { "ExercisesForMuscleGroupId", "MuscleGroupsId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "MuscleGroupTraining",
                keyColumns: new[] { "MuscleGroupsId", "TrainingsForMuscleGroupId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "MuscleGroupTraining",
                keyColumns: new[] { "MuscleGroupsId", "TrainingsForMuscleGroupId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "MuscleGroupTraining",
                keyColumns: new[] { "MuscleGroupsId", "TrainingsForMuscleGroupId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrainingsExercises",
                keyColumns: new[] { "ExerciseId", "TrainingId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "TrainingsExercises",
                keyColumns: new[] { "ExerciseId", "TrainingId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "TrainingsExercises",
                keyColumns: new[] { "ExerciseId", "TrainingId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "TrainingsExercises",
                keyColumns: new[] { "ExerciseId", "TrainingId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Trainers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Trainers_CreatorId",
                table: "Trainings",
                column: "CreatorId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
