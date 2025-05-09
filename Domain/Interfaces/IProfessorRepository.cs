using CreditEnrollmentApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProfessorRepository
    {
        // Get all professors
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();

        // Get a professor by ID
        Task<Professor> GetProfessorByIdAsync(int id);

        // Create a new professor
        Task<Professor> CreateProfessorAsync(Professor professor);

        // Update an existing professor
        Task<Professor> UpdateProfessorAsync(Professor professor);

        // Delete a professor
        Task DeleteProfessorAsync(int id);
    }
}
