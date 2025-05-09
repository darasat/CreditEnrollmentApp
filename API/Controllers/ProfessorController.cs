using Application.Interfaces;
using Application.Services;
using CreditEnrollmentApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
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
    }
}
