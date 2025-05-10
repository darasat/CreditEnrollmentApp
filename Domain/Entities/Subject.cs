using Domain.Entities;
using System.Collections.Generic;

namespace CreditEnrollmentApp.Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }

        // Agregar la propiedad de navegación
        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();


        // Relación con el profesor (uno a muchos)
        public int ProfessorId { get; set; }  // Relación con el profesor
        public Professor Professor { get; set; }  // Propiedad de navegación
    }

}
