using CreditEnrollmentApp.Domain.Entities;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.StudentSubjects)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task AddAsync(Student student)
        {
            try
            {
                student.CreatedAt = DateTime.UtcNow;
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Aquí puedes manejar errores relacionados con la base de datos
                // Por ejemplo, puedes hacer un log del error
                Console.Error.WriteLine($"Error al guardar los cambios: {ex.Message}");
                // Aquí podrías lanzar una excepción personalizada o re-lanzar la excepción original
                throw new Exception("Ocurrió un error al intentar agregar el estudiante.", ex);
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción general
                Console.Error.WriteLine($"Error inesperado: {ex.Message}");
                throw new Exception("Ocurrió un error inesperado.", ex);
            }
        }


        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<StudentSubject> entities)
        {
            await _context.StudentSubjects.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task AssignProgramAsync(int studentId, int programId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                throw new KeyNotFoundException("Estudiante no encontrado.");

            student.ProgramId = programId;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task AssignSubjectsAsync(int studentId, List<int> subjectIds)
        {
            if (subjectIds.Count > 3)
                throw new ArgumentException("El estudiante solo puede seleccionar 3 materias.");

            var student = await _context.Students
                .Include(s => s.StudentSubjects)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
                throw new KeyNotFoundException("Estudiante no encontrado.");

            var existingSubjectIds = student.StudentSubjects.Select(ss => ss.SubjectId).ToList();

            foreach (var subjectId in subjectIds)
            {
                if (existingSubjectIds.Contains(subjectId))
                    throw new ArgumentException($"El estudiante ya está inscrito en la materia con ID {subjectId}.");

                student.StudentSubjects.Add(new StudentSubject
                {
                    StudentId = studentId,
                    SubjectId = subjectId
                });
            }

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
     }
    

    public async Task<IEnumerable<Student>> GetSharedStudentsAsync(int studentId)
        {
            // Obtener las materias en las que está inscrito el estudiante
            var subjectIds = await _context.StudentSubjects
                .Where(ss => ss.StudentId == studentId)
                .Select(ss => ss.SubjectId)
                .ToListAsync();

            if (subjectIds.Count == 0)
            {
                return new List<Student>(); // Si el estudiante no tiene materias, retornar vacío
            }

            // Obtener estudiantes que compartan las mismas materias (excepto el mismo estudiante)
            var sharedStudents = await _context.StudentSubjects
                .Where(ss => subjectIds.Contains(ss.SubjectId) && ss.StudentId != studentId)
                .Select(ss => ss.Student)
                .Distinct()
                .ToListAsync();

            return sharedStudents;
        }

    }
}