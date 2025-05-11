using CreditEnrollmentApp.Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext _context;

        public ProfessorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _context.Professors
                .Include(p => p.ProfessorSubjects)
                .ToListAsync();
        }
        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            return await _context.Professors.FindAsync(id);
        }

        public async Task<Professor> CreateProfessorAsync(Professor professor)
        {
            await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor> UpdateProfessorAsync(Professor professor)
        {
            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor != null)
            {
                _context.Professors.Remove(professor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
