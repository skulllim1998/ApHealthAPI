using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApHealthAPI2.DomainClasses;

namespace ApHealthAPI2.Data
{
    public class AppointmentContext: DbContext
    {
        public AppointmentContext()
        {

        }

        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<DefaultResponse> DefaultResponses { get; set; }
        public DbSet<LoginResponse> LoginResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    DoctorId = 1,
                    DName = "Adonis Stewart",
                    Experience = 10,
                    NumPatient = 1022,
                    DocLocation = "CityMD",
                    About = "The idea of being a part of a profession focused on helping others regardless of circumstance, focused on facilitating people leading healthier and therefore happier lives.",
                    DImage = "https://aphealth-0301.s3.amazonaws.com/adonis_stewart.jpg",
                    SpecialistId = 1
                }
            );

            modelBuilder.Entity<Specialist>().HasData(
                new Specialist { SpecialistId = 1, SName = "Psycho", SImage = "img1" }
            );

            modelBuilder.Entity<DefaultResponse>().HasNoKey();

            modelBuilder.Entity<LoginResponse>().HasNoKey();

        }
    }
}
