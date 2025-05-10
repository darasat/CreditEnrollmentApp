using Domain.Entities;
using System.Collections.Generic;

namespace CreditEnrollmentApp.Domain.Entities
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }
        public List<StudentSubject> ProfessorSubjects { get; set; } = new List<StudentSubject>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
