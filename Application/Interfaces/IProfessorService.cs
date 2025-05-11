using CreditEnrollmentApp.Domain.Entities;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProfessorService
    {
        Task<IEnumerable<ProfessorDto>> GetAllAsync();
        Task<Professor> GetByIdAsync(int id);
        Task<Professor> CreateAsync(Professor professor);
        Task<Professor> UpdateAsync(Professor professor);
        Task DeleteAsync(int id);
        Task AssignProfessorToSubjectAsync(int subjectId, int professorId);
        Task<ProfessorDto> GetProfessorForSubjectAsync(int subjectId);
    }
}
