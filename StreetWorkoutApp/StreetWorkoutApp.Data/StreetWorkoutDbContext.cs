using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StreetWorkoutApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TrainingExercise>()
                .HasKey(x => new { x.TrainingId, x.ExerciseId });

            base.OnModelCreating(builder);
        }
    }
}
