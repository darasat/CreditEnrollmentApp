using Domain.Entities;
using System.Collections.Generic;

namespace CreditEnrollmentApp.Domain.Entities
{
    public class ProgramCredit
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int Credits { get; set; }

        // Relación con los estudiantes
        public List<StudentProgramEnrollment> StudentEnrollments { get; set; } = new List<StudentProgramEnrollment>();
    }
}
