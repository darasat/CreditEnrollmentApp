using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class StudentSubjectsRequestDto
    {
        public int StudentId { get; set; }
        public List<int> SubjectIds { get; set; }
    }

}
