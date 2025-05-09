using CreditEnrollmentApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    using CreditEnrollmentApp.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Domain.Interfaces
    {
        public interface IProgramRepository
        {
            Task<IEnumerable<ProgramCredit>> GetAllProgramsAsync();
            Task<ProgramCredit> GetProgramByIdAsync(int id);
            Task<ProgramCredit> CreateProgramAsync(ProgramCredit program);
            Task<ProgramCredit> UpdateProgramAsync(ProgramCredit program);
            Task DeleteProgramAsync(int id);
        }
    }

}
