using CreditEnrollmentApp.Domain.Entities;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task AssignProgramAsync(int studentId, int programId);
        Task AssignSubjectsAsync(int studentId, List<int> subjectIds);
        Task<IEnumerable<Student>> GetSharedStudentsAsync(int studentId);
        Task AddRangeAsync(IEnumerable<StudentSubject> entities);
    }
}
