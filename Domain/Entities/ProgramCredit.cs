using Domain.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CreditEnrollmentApp.Domain.Entities
{
    public class ProgramCredit
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int Credits { get; set; }

        [JsonIgnore]
        public List<StudentProgramEnrollment> StudentEnrollments { get; set; } = new List<StudentProgramEnrollment>();
    }
}
