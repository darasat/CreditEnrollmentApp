using Application.Interfaces;
using CreditEnrollmentApp.Domain.Entities;
using Domain.Interfaces.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IEnumerable<ProgramCredit>> GetAllAsync()
        {
            return await _programRepository.GetAllProgramsAsync();
        }

        public async Task<ProgramCredit> GetByIdAsync(int id)
        {
            return await _programRepository.GetProgramByIdAsync(id);
        }

        public async Task<ProgramCredit> CreateAsync(ProgramCredit program)
        {
            await _programRepository.CreateProgramAsync(program);
            return program;
        }

        public async Task<ProgramCredit> UpdateAsync(ProgramCredit program)
        {
            await _programRepository.UpdateProgramAsync(program);
            return program;
        }

        public async Task DeleteAsync(int id)
        {
            await _programRepository.DeleteProgramAsync(id);
        }
    }
}
