using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using StreetWorkoutApp.Data.Extensions;
using StreetWorkoutApp.Data.Models;

namespace StreetWorkoutApp.Data
{
    public class StreetWorkoutDbContext : IdentityDbContext<AppUser>
    {
        public StreetWorkoutDbContext(DbContextOptions<StreetWorkoutDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<TrainingExercise> TrainingsExercises { get; set; }

        public DbSet<Trainer> Trainers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TrainingExercise>()
                .HasKey(x => new { x.TrainingId, x.ExerciseId });

            builder.Entity<Training>()
                .HasOne(x => x.GoalExercise)
                .WithMany(x => x.TrainingsForAcheiving)
                .HasForeignKey(x => x.GoalExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Trainer>()
                .HasMany(x => x.CreatedTrainings)
                .WithOne(x => x.Creator)
                .HasForeignKey(x => x.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.SeedRolesAndUsers();
            builder.SeedData();

            base.OnModelCreating(builder);
        }
    }
}
