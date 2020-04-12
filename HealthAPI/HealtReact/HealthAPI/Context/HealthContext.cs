using HealthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.Context
{
    public class HealthContext : DbContext
    {
        public HealthContext(DbContextOptions<HealthContext> options) : base(options)
        {
            //Database.EnsureDeleted(); // COMMENT OUT WHEN NEEDED
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 1,
                FirstName = "Mario",
                LastName = "Rincon",
                BirthDate = DateTime.Now,
                InsuranceName = "Coomeva",
                PhoneNumber = "32123123123123",
                Location = "United States",
                Email = "aaa@gmail.com",
                UserPassword = "123"
            });

            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                Id = 1,
                DoctorName = "Manuel Alonso",
                Diagnostic = "The patient is sick",
                OcurredDate = DateTime.Now,
                Medicines = "Acetanomifen ; Dolex",
                PatientId = 1
            },
                new Appointment
                {
                    Id = 2,
                    DoctorName = "Samuel Latora",
                    Diagnostic = "It is just a cold",
                    OcurredDate = DateTime.Now,
                    Medicines = "Dolex",
                    PatientId = 1
                }

                );

           

            modelBuilder.Entity<Sickness>().HasData(new Sickness
                {
                    Id = 1,
                    Description = "Pneumonia is an infection that inflames the air sacs in one or both lungs",
                    Name = "Pneumonia",
                    StartedDate = DateTime.Now,
                    Symptoms = "Chest pain;Cough",
                }, new Sickness
                {
                    Id = 2,
                    Description = "Inflammation of one or more joints, causing pain and stiffness that can worsen with age.",
                    Name = "Osea",
                    StartedDate = DateTime.Now,
                    Symptoms = " pain;swelling",
                }, new Sickness
                {
                    Id = 3,
                    Description = "A group of diseases that result in too much sugar in the blood (high blood glucose).",
                    Name = "Diabetes",
                    StartedDate = DateTime.Now,
                    Symptoms = "dizzness;headeache",
            }
            );

            modelBuilder.Entity<WellnessPlan>().HasData(new WellnessPlan
                {
                    Id = 1,
                    Name = "Loose Weight",
                    Description = " Sweat like a hourse",
                    Activities = " Run; Jog; Aerobics",
                    Duration = 10,
                }, new WellnessPlan
                {
                    Id = 2,
                    Name = "Diet",
                    Description = "Eat Healthy",
                    Activities = " Run; Jog; Aerobics",
                    Duration = 70,
                }, new WellnessPlan
                {
                    Id = 3,
                    Name = "Stretch",
                    Description = " Keep Your aticulations active",
                    Activities = " Run; Jog; Aerobics",
                    Duration = 40,
                }
            );

            modelBuilder.Entity<PatientSickness>().HasData(new PatientSickness
            {
                Id = 1,
                PatientId = 1,
                SicknessId = 1,
                StartedDate = DateTime.Now

            });



           base.OnModelCreating(modelBuilder);
        }
        //entities
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Sickness> Sicknesses { get; set; }
        public DbSet<WellnessPlan> WellnessPlans { get; set; }
        public DbSet<PatientSickness> PatientSicknesses { get; set; }
        public DbSet<PatientWellnessPlan> PatientWellnessPlans { get; set; }
    }
}