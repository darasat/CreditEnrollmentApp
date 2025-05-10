using Domain.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CreditEnrollmentApp.Domain.Entities
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<StudentSubject> ProfessorSubjects { get; set; } = new List<StudentSubject>(); 
        [JsonIgnore]
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
