using Application.Interfaces;
using CreditEnrollmentApp.Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<Professor>> GetAllAsync()
        {
            return await _professorRepository.GetAllProfessorsAsync();
        }

        public async Task<Professor> GetByIdAsync(int id)
        {
            return await _professorRepository.GetProfessorByIdAsync(id);
        }

        public async Task<Professor> CreateAsync(Professor professor)
        {
            await _professorRepository.CreateProfessorAsync(professor);
            return professor;
        }

        public async Task<Professor> UpdateAsync(Professor professor)
        {
            await _professorRepository.UpdateProfessorAsync(professor);
            return professor;
        }

        public async Task DeleteAsync(int id)
        {
            await _professorRepository.DeleteProfessorAsync(id);
        }
    }
}
