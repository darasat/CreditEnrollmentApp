using CreditEnrollmentApp.Domain.Entities;
using System;

namespace Domain.Entities
{
    public class StudentProgramEnrollment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ProgramId { get; set; }
        public ProgramCredit Program { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }

}
