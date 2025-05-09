using Application.Interfaces;
using CreditEnrollmentApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditEnrollmentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramsController(IProgramService programService)
        {
            _programService = programService;
        }

        // GET: api/programs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramCredit>>> GetPrograms()
        {
            var programs = await _programService.GetAllAsync();
            return Ok(programs);
        }

        // GET: api/programs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramCredit>> GetProgram(int id)
        {
            var program = await _programService.GetByIdAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            return Ok(program);
        }

        // POST: api/programs
        [HttpPost]
        public async Task<ActionResult<ProgramCredit>> PostProgram(ProgramCredit program)
        {
            var createdProgram = await _programService.CreateAsync(program);
            return CreatedAtAction(nameof(GetProgram), new { id = createdProgram.ProgramId }, createdProgram);
        }

        // PUT: api/programs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgram(int id, ProgramCredit program)
        {
            if (id != program.ProgramId)
            {
                return BadRequest();
            }

            var updatedProgram = await _programService.UpdateAsync(program);
            if (updatedProgram == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/programs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var program = await _programService.GetByIdAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            await _programService.DeleteAsync(id);
            return NoContent();
        }
    }
}
