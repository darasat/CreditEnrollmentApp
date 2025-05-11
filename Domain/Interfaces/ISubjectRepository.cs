using CreditEnrollmentApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<Subject> CreateSubjectAsync(Subject subject);
        Task<Subject> UpdateSubjectAsync(Subject subject);
        Task DeleteSubjectAsync(int id);
        Task<List<Subject>> GetSubjectsByIdsAsync(List<int> subjectIds);

        Task<List<Subject>> GetSubjectsByProfessorIdAsync(int professorId);
    }
}
