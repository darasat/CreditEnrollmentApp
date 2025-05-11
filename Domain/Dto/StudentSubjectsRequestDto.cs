using System.Collections.Generic;

namespace Domain.Dto
{
    public class StudentSubjectsRequestDto
    {
        public int StudentId { get; set; }
        public List<int> SubjectIds { get; set; }
    }

}
