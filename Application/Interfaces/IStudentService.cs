using CreditEnrollmentApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task DeleteAsync(int id);

        Task AssignProgramToStudentAsync(int studentId, int programId);
        Task AssignSubjectsToStudentAsync(int studentId, List<int> subjectIds);
        Task<IEnumerable<Student>> GetSharedStudentsAsync(int studentId);
    }
}
