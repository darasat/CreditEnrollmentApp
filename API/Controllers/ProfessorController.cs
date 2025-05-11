using Application.Interfaces;
using CreditEnrollmentApp.Domain.Entities;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditEnrollmentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorsController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        // GET: api/professors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorDto>>> GetProfessors()
        {
            var professors = await _professorService.GetAllAsync();
            return Ok(professors);
        }

        // GET: api/professors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _professorService.GetByIdAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // POST: api/professors
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
            var createdProfessor = await _professorService.CreateAsync(professor);
            return CreatedAtAction(nameof(GetProfessor), new { id = createdProfessor.ProfessorId }, createdProfessor);
        }

        // PUT: api/professors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, Professor professor)
        {
            if (id != professor.ProfessorId)
            {
                return BadRequest();
            }

            await _professorService.UpdateAsync(professor);

            return NoContent();
        }

        // DELETE: api/professors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            await _professorService.DeleteAsync(id);
            return NoContent();
        }

        // POST: api/professors/assign-to-subject/{subjectId}
        [HttpPost("assign-to-subject/{subjectId}")]
        public async Task<IActionResult> AssignProfessorToSubject(int subjectId, [FromBody] int professorId)
        {
            try
            {
                // Asignamos el profesor a la materia
                await _professorService.AssignProfessorToSubjectAsync(subjectId, professorId);
                return Ok("Profesor asignado correctamente a la materia.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al asignar profesor: {ex.Message}");
            }
        }

        // GET: api/professors/assigned-to-subject/{subjectId}
        [HttpGet("assigned-to-subject/{subjectId}")]
        public async Task<ActionResult<ProfessorDto>> GetProfessorForSubject(int subjectId)
        {
            var professor = await _professorService.GetProfessorForSubjectAsync(subjectId);

            if (professor == null)
            {
                return NotFound("No hay profesor asignado a esta materia.");
            }

            return Ok(professor);
        }


    }
}
