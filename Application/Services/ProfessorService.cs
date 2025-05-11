using Application.Interfaces;
using CreditEnrollmentApp.Domain.Entities;
using Domain.Dto;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly ISubjectRepository _subjectRepository;  // Asegúrate de tener este repositorio para obtener las materias

        public ProfessorService(IProfessorRepository professorRepository, ISubjectRepository subjectRepository)
        {
            _professorRepository = professorRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<ProfessorDto>> GetAllAsync()
        {
            // Asegúrate de que este método incluye las materias
            var professors = await _professorRepository.GetAllProfessorsAsync();

            // Mapear a DTO
            var professorDtos = professors.Select(professor => new ProfessorDto
            {
                ProfessorId = professor.ProfessorId,
                Name = professor.Name,
                SubjectIds = professor.ProfessorSubjects.Select(ps => ps.SubjectId).ToList()
            }).ToList();

            return professorDtos;
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

        // Método para asignar un profesor a una materia
        public async Task AssignProfessorToSubjectAsync(int subjectId, int professorId)
        {
            var subject = await _subjectRepository.GetSubjectByIdAsync(subjectId);
            if (subject == null)
            {
                throw new Exception("Materia no encontrada");
            }

            var professor = await _professorRepository.GetProfessorByIdAsync(professorId);
            if (professor == null)
            {
                throw new Exception("Profesor no encontrado");
            }

            // Aquí realizas la lógica para asignar el profesor a la materia
            subject.ProfessorId = professorId;  // Esto depende de cómo manejas las relaciones en tu base de datos

            await _subjectRepository.UpdateSubjectAsync(subject);  // Asegúrate de que el repositorio de materias tenga este método.
        }

        public async Task<ProfessorDto> GetProfessorForSubjectAsync(int subjectId)
        {
            var subject = await _subjectRepository.GetSubjectByIdAsync(subjectId);
            if (subject == null)
            {
                throw new Exception("Materia no encontrada");
            }

            var professor = await _professorRepository.GetProfessorByIdAsync((int)subject.ProfessorId);
            if (professor == null)
            {
                return null;
            }

            // Mapear al DTO
            var professorDto = new ProfessorDto
            {
                ProfessorId = professor.ProfessorId,
                Name = professor.Name,
                SubjectIds = professor.Subjects.Select(s => s.SubjectId).ToList() // O cualquier otra info relevante
            };

            return professorDto;
        }

        public async Task AssignTeacherToSubjectAsync(int professorId, int subjectId)
        {
            var subject = await _subjectRepository.GetSubjectByIdAsync(subjectId);
            var professor = await _professorRepository.GetProfessorByIdAsync(professorId);

            if (subject == null || professor == null)
            {
                throw new KeyNotFoundException("Profesor o materia no encontrados.");
            }

            // Aquí debes asignar al profesor a la materia (por ejemplo, actualizando la propiedad ProfessorId de la materia)
            subject.ProfessorId = professorId;

            // También puedes guardar la actualización en el repositorio de la materia.
            await _subjectRepository.UpdateSubjectAsync(subject);
        }
    }
}
