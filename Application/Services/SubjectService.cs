using Application.Interfaces;
using CreditEnrollmentApp.Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _subjectRepository.GetAllSubjectsAsync();
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _subjectRepository.GetSubjectByIdAsync(id);
        }

        public async Task<Subject> CreateAsync(Subject subject)
        {
            await _subjectRepository.CreateSubjectAsync(subject);
            return subject;
        }

        public async Task<Subject> UpdateAsync(Subject subject)
        {
            await _subjectRepository.UpdateSubjectAsync(subject);
            return subject;
        }

        public async Task DeleteAsync(int id)
        {
            await _subjectRepository.DeleteSubjectAsync(id);
        }
    }
}
