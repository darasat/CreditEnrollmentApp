using CreditEnrollmentApp.Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditEnrollmentApp.Infrastructure.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly AppDbContext _context;

        public ProgramRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramCredit>> GetAllProgramsAsync()
        {
            return await _context.ProgramCredits.ToListAsync();
        }

        public async Task<ProgramCredit> GetProgramByIdAsync(int id)
        {
            return await _context.ProgramCredits.FindAsync(id);
        }

        public async Task<ProgramCredit> CreateProgramAsync(ProgramCredit program)
        {
            _context.ProgramCredits.Add(program);
            await _context.SaveChangesAsync();
            return program;
        }

        public async Task<ProgramCredit> UpdateProgramAsync(ProgramCredit program)
        {
            _context.ProgramCredits.Update(program);
            await _context.SaveChangesAsync();
            return program;
        }

        public async Task DeleteProgramAsync(int id)
        {
            var program = await _context.ProgramCredits.FindAsync(id);
            if (program != null)
            {
                _context.ProgramCredits.Remove(program);
                await _context.SaveChangesAsync();
            }
        }
    }
}
