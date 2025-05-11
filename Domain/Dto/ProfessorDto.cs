using System.Collections.Generic;

namespace Domain.Dto
{
    public class ProfessorDto
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }
        public List<int> SubjectIds { get; set; } = new List<int>(); 
    }

}
