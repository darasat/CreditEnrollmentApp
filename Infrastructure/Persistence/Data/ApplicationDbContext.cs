using Microsoft.EntityFrameworkCore;
using CreditEnrollmentApp.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using Domain.Entities;

namespace Infrastructure.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<StudentProgramEnrollment> StudentProgramEnrollments { get; set; }
        public DbSet<ProgramCredit> ProgramCredits{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar clave primaria compuesta para la tabla StudentSubject
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            // Relaci�n entre Student y StudentSubject
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            // Relaci�n entre Subject y StudentSubject
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            // Relaci�n entre Professor y StudentSubject
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Professor)
                .WithMany(p => p.ProfessorSubjects)
                .HasForeignKey(ss => ss.ProfessorId);

            // Configurar clave primaria compuesta para la tabla StudentProgramEnrollment
            modelBuilder.Entity<StudentProgramEnrollment>()
                .HasKey(spe => new { spe.StudentId, spe.ProgramId });

            // Relaci�n entre Student y StudentProgramEnrollment
            modelBuilder.Entity<StudentProgramEnrollment>()
                .HasOne(spe => spe.Student)
                .WithMany(s => s.StudentEnrollments)
                .HasForeignKey(spe => spe.StudentId);

            // Relaci�n entre ProgramCredit y StudentProgramEnrollment
            modelBuilder.Entity<StudentProgramEnrollment>()
                .HasOne(spe => spe.Program)
                .WithMany(p => p.StudentEnrollments)
                .HasForeignKey(spe => spe.ProgramId);

            modelBuilder.Entity<ProgramCredit>()
                .HasKey(p => p.ProgramId);

            // Configuraci�n de la tabla StudentProgramEnrollment
            modelBuilder.Entity<StudentProgramEnrollment>()
                .ToTable("StudentProgramEnrollment"); // Aseg�rate de que la tabla se llame correctamente

            base.OnModelCreating(modelBuilder);
        }

    }
}
