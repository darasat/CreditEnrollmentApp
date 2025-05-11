using CreditEnrollmentApp.Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditEnrollmentApp.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Subject>> GetSubjectsByIdsAsync(List<int> subjectIds)
        {
            return await _context.Subjects
                                 .Where(s => subjectIds.Contains(s.SubjectId))
                                 .ToListAsync();
        }

        public async Task<List<Subject>> GetSubjectsByProfessorIdAsync(int professorId)
        {
            return await _context.Subjects
                                 .Where(s => s.ProfessorId == professorId)
                                 .ToListAsync();
        }
    }
}
