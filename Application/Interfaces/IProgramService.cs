using CreditEnrollmentApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProgramService
    {
        Task<IEnumerable<ProgramCredit>> GetAllAsync();
        Task<ProgramCredit> GetByIdAsync(int id);
        Task<ProgramCredit> CreateAsync(ProgramCredit program);
        Task<ProgramCredit> UpdateAsync(ProgramCredit program);
        Task DeleteAsync(int id);
    }
}
