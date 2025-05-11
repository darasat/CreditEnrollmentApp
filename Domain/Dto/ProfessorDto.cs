using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ProfessorDto
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }
        public List<int> SubjectIds { get; set; } = new List<int>(); // Solo IDs o información relevante de las materias
    }

}
