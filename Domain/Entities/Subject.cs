using Domain.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CreditEnrollmentApp.Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }

        [JsonIgnore]
        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();


        // Relación con el profesor (uno a muchos)
        public int? ProfessorId { get; set; }
        public Professor Professor { get; set; } 
    }

}
