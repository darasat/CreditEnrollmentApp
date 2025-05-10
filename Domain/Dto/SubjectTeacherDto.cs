using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class SubjectTeacherDto
    {
        public int SubjectId { get; set; }  // El ID de la materia
        public int ProfessorId { get; set; } // El ID del profesor asignado
    }
}
