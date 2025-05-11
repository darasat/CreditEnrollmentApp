using CreditEnrollmentApp.Domain.Entities;

namespace Domain.Entities
{
    public class StudentSubject
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }

}
