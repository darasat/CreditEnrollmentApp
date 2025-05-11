using CreditEnrollmentApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task<Subject> GetByIdAsync(int id);
        Task<Subject> CreateAsync(Subject subject);
        Task<Subject> UpdateAsync(Subject subject);
        Task DeleteAsync(int id);
    }
}
