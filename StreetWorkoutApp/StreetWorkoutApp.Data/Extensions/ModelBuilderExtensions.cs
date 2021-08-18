using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Data.Models.Enums;

using userRoles = StreetWorkoutApp.Data.Models.UserRoles;

namespace StreetWorkoutApp.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        private const string adminRoleId = "f7ff7003-9468-49f5-979a-8138bcf8d480";
        private const string userRoleId = "f3b35b36-e0ad-479b-9855-35a6a785173c";
        private const string trainerRoleId = "7942e80f-1f4d-4da4-8fb0-66616a9d7966";
        private const string administratorId = "b2b201e9-8c95-4d19-89c3-28184f48b1d5";
        private const string userId = "f8406549-4a2e-4401-9fb8-d06992ef6afd";
        private const string trainerId = "5a1b8332-873e-4c5f-af06-2ccdf04616dc";

        private static List<MuscleGroup> muscleGroups = new List<MuscleGroup>
            {
                new MuscleGroup { Id = 1, Name = "Shoulders" },
                new MuscleGroup { Id = 2, Name = "Chest" },
                new MuscleGroup { Id = 3, Name = "Biceps" },
                new MuscleGroup { Id = 4, Name = "Traps" },
                new MuscleGroup { Id = 5, Name = "Triceps" },
                new MuscleGroup { Id = 6, Name = "Upper Back" },
                new MuscleGroup { Id = 7, Name = "Lower Back" },
                new MuscleGroup { Id = 8, Name = "Abs" },
                new MuscleGroup { Id = 9, Name = "Forearms" },
                new MuscleGroup { Id = 10, Name = "Quadriceps" },
                new MuscleGroup { Id = 11, Name = "HamStrings" },
                new MuscleGroup { Id = 12, Name = "Calves" },
                new MuscleGroup { Id = 13, Name = "Glutes" },
                new MuscleGroup { Id = 14, Name = "Neck" }
            };

        private static List<Equipment> equipmentList = new List<Equipment>
            {
                new Equipment { Id = 1, Name = "Dumbells", ImageUrl = "https://m.media-amazon.com/images/I/81CIL-7+n3L._AC_SX425_.jpg" },
                new Equipment { Id = 2, Name = "Rings", ImageUrl = "https://rukminim1.flixcart.com/image/416/416/k37mg7k0/pilates-ring/9/t/g/wooden-gymnastics-roman-rings-wxws-original-imafh2yxqpahjwjx.jpeg?q=70" },
                new Equipment { Id = 3, Name = "Pull Up Bar", ImageUrl = "https://i.pinimg.com/564x/d5/e4/53/d5e45313b036eb890d6e918a3428be8b.jpg" },
                new Equipment { Id = 4, Name = "Parallels", ImageUrl = "https://kengurupro.eu/wp-content/uploads/2021/01/P-003-1.jpg" }
            };

        public static void SeedRolesAndUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = userRoles.Admin, NormalizedName = userRoles.Admin.ToUpper() },
                new IdentityRole { Id = userRoleId, Name = userRoles.User, NormalizedName = userRoles.User.ToUpper() },
                new IdentityRole { Id = trainerRoleId, Name = userRoles.Trainer, NormalizedName = userRoles.Trainer.ToUpper() });

            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = administratorId,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@admin.com",
                    NormalizedEmail = "admin@admin.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "adminadmin")
                },
                new AppUser
                {
                    Id = userId,
                    UserName = "test",
                    NormalizedUserName = "TEST",
                    Email = "test@test.com",
                    NormalizedEmail = "test@test.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "testtest")
                },
                new AppUser
                {
                    Id = trainerId,
                    UserName = "trainer",
                    NormalizedUserName = "TRAINER",
                    Email = "trainer@trainer.com",
                    NormalizedEmail = "trainer@trainer.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "trainertrainer")
                });

            modelBuilder.Entity<Trainer>().HasData(
                new Trainer
                {
                    Id = 1,
                    UserId = administratorId,
                    UserName = "admin"
                },
                new Trainer
                {
                    Id = 2,
                    UserId = trainerId,
                    UserName = "trainer"
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = administratorId },
                new IdentityUserRole<string> { RoleId = trainerRoleId, UserId = administratorId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = administratorId },
                new IdentityUserRole<string> { RoleId = trainerRoleId, UserId = trainerId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = trainerId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = userId });
        }

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MuscleGroup>().HasData(muscleGroups);

            modelBuilder.Entity<Equipment>().HasData(equipmentList);

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1,
                    Name = "Iron cross",
                    ImageUrl = "https://image.shutterstock.com/image-illustration/gymnast-performing-iron-cross-on-260nw-1586582845.jpg",
                    Description = "This exercise is performed on rings. The performer must go on top of the rings and open his arms as wide as possible.",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.advanced
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Fron lever",
                    ImageUrl = "https://image.shutterstock.com/image-vector/muscular-man-doing-front-lever-260nw-1687648483.jpg",
                    Description = "A front lever is performed by lowering from an inverted hang until the body is completely horizontal and straight with the front of the body facing upwards",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.advanced
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Back lever",
                    ImageUrl = "https://flighttrainingfitness.files.wordpress.com/2018/06/back-lever.png",
                    Description = "A back lever is performed by lowering from an inverted hang until the body is completely horizontal and straight with the front of the body facing backwards.",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.intermediate
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Pull up",
                    ImageUrl = "https://i.stack.imgur.com/AY9Xl.png",
                    Description = "A pullup is a challenging upper body exercise where you grip an overhead bar and lift your body until your chin is above that bar.",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.beginner
                },
                new Exercise
                {
                    Id = 5,
                    Name = "Push up",
                    ImageUrl = "https://physicalculturestudy.com/wp-content/uploads/2018/01/pushup.png",
                    Description = "Conditioning exercise performed in a prone position by raising and lowering the body with the straightening and bending of the arms while keeping the back straight and supporting the body on the hands and toes.",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.beginner
                },
                new Exercise
                {
                    Id = 6,
                    Name = "Hanging leg raises 90",
                    ImageUrl = "https://www.gymguider.com/wp-content/uploads/2017/07/Hanging_Leg_Raise.jpg",
                    Description = "Hanging from a bar by your extended arms, you raise your legs parallel to the ground.",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.beginner
                },
                new Exercise
                {
                    Id = 7,
                    Name = "Whipers",
                    ImageUrl = "https://www.mensjournal.com/wp-content/uploads/2019/01/hangingwindshieldwipers.jpg?w=700&quality=86&strip=all",
                    Description = "Hanging from a bar lift your toes to the bar and start rotating your legs to each side. One rep is moving your toes once to the left and once to the right.",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.beginner
                },
                new Exercise
                {
                    Id = 8,
                    Name = "Leg raises to bar",
                    ImageUrl = "https://cdn-xi3mbccdkztvoept8hl.netdna-ssl.com/wp-content/uploads/watermarked/Hanging_Leg_Raises_to_Bar-1.png",
                    Description = "Hanging from a bar lift your toes to the bar and hold for 2 seconds, then slowly lower your legs.",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.beginner
                },
                new Exercise
                {
                    Id = 9,
                    Name = "Front lever raises",
                    ImageUrl = "https://i.pinimg.com/736x/dd/f0/da/ddf0daa00c840e4020f6edc31ad29f89.jpg",
                    Description = "Hanging from a bar lift your body in the front lever position and then slowly bring it back to hanging position",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.intermediate
                },
                new Exercise
                {
                    Id = 10,
                    Name = "Knee raises",
                    ImageUrl = "http://1bodyweighttraining.com/wp-content/uploads/2018/04/hanging-knee-raises.png",
                    Description = "Hanging from a bar lift your knees up to ypur chest and then bring them back.",
                    CreatorId = 1,
                    ExerciseLevel = ExerciseLevelEnum.beginner
                });

            SeedExerciseManyToMany(modelBuilder);

            modelBuilder.Entity<Training>().HasData(
                new Training
                {
                    Id = 1,
                    Name = "Abs routine",
                    Description = "This is a trainigng for abs. It's really useable for front lever. The trainings should be performed outside.",
                    CyclesCount = 5,
                    BreakBetweenCycles = TimeSpan.ParseExact("1:00", "m':'ss", null),
                    BreakBetweenExercises = TimeSpan.ParseExact("0:10", "m':'ss", null),
                    IsIndoor = false,
                    CreatorId = 1,
                    TrainingLevel = TrainingLevelEnum.Beginner
                });

            modelBuilder.Entity<TrainingExercise>().HasData(
                new TrainingExercise { TrainingId = 1, ExerciseId = 6, Reps = 10 },
                new TrainingExercise { TrainingId = 1, ExerciseId = 7, Reps = 10 },
                new TrainingExercise { TrainingId = 1, ExerciseId = 8, Reps = 10 },
                new TrainingExercise { TrainingId = 1, ExerciseId = 10, Reps = 30 });

            modelBuilder.Entity("MuscleGroupTraining").HasData(
                new { TrainingsForMuscleGroupId  = 1, MuscleGroupsId = 7},
                new { TrainingsForMuscleGroupId  = 1, MuscleGroupsId = 8},
                new { TrainingsForMuscleGroupId  = 1, MuscleGroupsId = 9});
        }

        private static void SeedExerciseManyToMany(ModelBuilder modelBuilder)
        {
            // many to many realtionship cannot be seeded directly using the navigational properties.

            modelBuilder.Entity("ExerciseMuscleGroup").HasData(
                    new { ExercisesForMuscleGroupId = 1, MuscleGroupsId = 1 },
                    new { ExercisesForMuscleGroupId = 1, MuscleGroupsId = 2 },
                    new { ExercisesForMuscleGroupId = 1, MuscleGroupsId = 9 },
                    new { ExercisesForMuscleGroupId = 2, MuscleGroupsId = 1 },
                    new { ExercisesForMuscleGroupId = 2, MuscleGroupsId = 7 },
                    new { ExercisesForMuscleGroupId = 2, MuscleGroupsId = 8 },
                    new { ExercisesForMuscleGroupId = 3, MuscleGroupsId = 1 },
                    new { ExercisesForMuscleGroupId = 3, MuscleGroupsId = 2 },
                    new { ExercisesForMuscleGroupId = 3, MuscleGroupsId = 6 },
                    new { ExercisesForMuscleGroupId = 3, MuscleGroupsId = 7 },
                    new { ExercisesForMuscleGroupId = 4, MuscleGroupsId = 1 },
                    new { ExercisesForMuscleGroupId = 4, MuscleGroupsId = 3 },
                    new { ExercisesForMuscleGroupId = 4, MuscleGroupsId = 4 },
                    new { ExercisesForMuscleGroupId = 4, MuscleGroupsId = 9 },
                    new { ExercisesForMuscleGroupId = 5, MuscleGroupsId = 1 },
                    new { ExercisesForMuscleGroupId = 5, MuscleGroupsId = 2 },
                    new { ExercisesForMuscleGroupId = 5, MuscleGroupsId = 4 },
                    new { ExercisesForMuscleGroupId = 5, MuscleGroupsId = 5 },
                    new { ExercisesForMuscleGroupId = 6, MuscleGroupsId = 8 },
                    new { ExercisesForMuscleGroupId = 6, MuscleGroupsId = 9 },
                    new { ExercisesForMuscleGroupId = 6, MuscleGroupsId = 10 },
                    new { ExercisesForMuscleGroupId = 7, MuscleGroupsId = 6 },
                    new { ExercisesForMuscleGroupId = 7, MuscleGroupsId = 7 },
                    new { ExercisesForMuscleGroupId = 7, MuscleGroupsId = 8 },
                    new { ExercisesForMuscleGroupId = 7, MuscleGroupsId = 9 },
                    new { ExercisesForMuscleGroupId = 8, MuscleGroupsId = 1 },
                    new { ExercisesForMuscleGroupId = 8, MuscleGroupsId = 6 },
                    new { ExercisesForMuscleGroupId = 8, MuscleGroupsId = 8 },
                    new { ExercisesForMuscleGroupId = 8, MuscleGroupsId = 9 },
                    new { ExercisesForMuscleGroupId = 9, MuscleGroupsId = 1 },
                    new { ExercisesForMuscleGroupId = 9, MuscleGroupsId = 7 },
                    new { ExercisesForMuscleGroupId = 9, MuscleGroupsId = 8 },
                    new { ExercisesForMuscleGroupId = 9, MuscleGroupsId = 9 },
                    new { ExercisesForMuscleGroupId = 10, MuscleGroupsId = 8 },
                    new { ExercisesForMuscleGroupId = 10, MuscleGroupsId = 9 }
                );

            modelBuilder.Entity("EquipmentExercise").HasData(
                    new { ExercisesId = 1, EquipmentNeededId = 1 },
                    new { ExercisesId = 2, EquipmentNeededId = 3 },
                    new { ExercisesId = 3, EquipmentNeededId = 3 },
                    new { ExercisesId = 4, EquipmentNeededId = 3 },
                    new { ExercisesId = 6, EquipmentNeededId = 3 },
                    new { ExercisesId = 7, EquipmentNeededId = 3 },
                    new { ExercisesId = 8, EquipmentNeededId = 3 },
                    new { ExercisesId = 9, EquipmentNeededId = 3 },
                    new { ExercisesId = 10, EquipmentNeededId = 3 }
                );
        }
    }
}
