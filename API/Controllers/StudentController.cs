using Application.Interfaces;
using CreditEnrollmentApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Domain.Dto;
using System.Linq;

namespace CreditEnrollmentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public StudentsController(IStudentService studentService, ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var createdStudent = await _studentService.CreateAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.StudentId }, createdStudent);
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            await _studentService.UpdateAsync(student);

            return NoContent();
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }

        // POST: api/students/assign-program
        [HttpPost("assign-program")]
        public async Task<IActionResult> AssignProgramToStudent([FromBody] StudentProgramRequestDto request)
        {
            try
            {
                await _studentService.AssignProgramToStudentAsync(request.StudentId, request.ProgramId);
                return Ok("Estudiante asignado al programa correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al asignar programa: {ex.Message}");
            }
        }

        // POST: api/students/assign-subjects
        [HttpPost("assign-subjects")]
        public async Task<IActionResult> AssignSubjectsToStudent([FromBody] StudentSubjectsRequestDto request)
        {
            try
            {
                await _studentService.AssignSubjectsToStudentAsync(request.StudentId, request.SubjectIds);
                return Ok("Materias asignadas al estudiante correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al asignar materias: {ex.Message}");
            }
        }

        // GET: api/students/{id}/shared-students
        [HttpGet("{id}/shared-students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetSharedStudents(int id)
        {
            try
            {
                var students = await _studentService.GetSharedStudentsAsync(id);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener estudiantes compartidos: {ex.Message}");
            }
        }

        [HttpPost("register-subject-teachers")]
        public async Task<IActionResult> RegisterSubjectTeachers([FromBody] List<SubjectTeacherDto> dtos)
        {
            if (dtos == null || !dtos.Any())
                return BadRequest("No se proporcionaron datos para registrar.");

            try
            {
                await _studentService.RegisterSubjectTeachersAsync(dtos);
                return Ok();
            }
            catch (Exception ex)
            {
                // Aquí puedes mejorar el manejo de errores si lo deseas
                return StatusCode(500, $"Error al registrar materias con profesores: {ex.Message}");
            }
        }
    }

}
