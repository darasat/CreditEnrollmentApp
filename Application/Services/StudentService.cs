using Application.Interfaces;
using CreditEnrollmentApp.Domain.Entities;
using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IProgramRepository _programRepository;
        private readonly ISubjectRepository _subjectRepository;

        public StudentService(IStudentRepository studentRepository, IProgramRepository programRepository, ISubjectRepository subjectRepository)
        {
            _studentRepository = studentRepository;
            _programRepository = programRepository;
            _subjectRepository = subjectRepository;
        }

        // Get all students
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        // Get a student by Id
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        // Create a new student
        public async Task<Student> CreateAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return student;
        }

        // Update an existing student
        public async Task<Student> UpdateAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return student;
        }

        // Delete a student by Id
        public async Task DeleteAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task AssignProgramToStudentAsync(int studentId, int programId)
        {
            await _studentRepository.AssignProgramAsync(studentId, programId);
        }

        public async Task AssignSubjectsToStudentAsync(int studentId, List<int> subjectIds)
        {
            await _studentRepository.AssignSubjectsAsync(studentId, subjectIds);
        }

        public async Task<IEnumerable<Student>> GetSharedStudentsAsync(int studentId)
        {
            // Llamar al repositorio para obtener los estudiantes compartidos.
            return await _studentRepository.GetSharedStudentsAsync(studentId);
        }

        public async Task RegisterSubjectTeachersAsync(List<SubjectTeacherDto> dtos)
        {
            var records = dtos.Select(dto => new StudentSubject
            {
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId,
                ProfessorId = dto.ProfessorId
            }).ToList();

            await _studentRepository.AddRangeAsync(records);
        }

    }
}
