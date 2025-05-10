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

        // Agregar la propiedad de navegaci�n
        [JsonIgnore]
        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();


        // Relaci�n con el profesor (uno a muchos)
        public int? ProfessorId { get; set; }// Relaci�n con el profesor
        public Professor Professor { get; set; }  // Propiedad de navegaci�n
    }

}
