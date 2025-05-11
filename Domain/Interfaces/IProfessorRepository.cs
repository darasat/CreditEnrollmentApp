using CreditEnrollmentApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task<Professor> GetProfessorByIdAsync(int id);
        Task<Professor> CreateProfessorAsync(Professor professor);
        Task<Professor> UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
    }
}
