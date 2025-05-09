using Domain.Entities;
using System;
using System.Collections.Generic;

namespace CreditEnrollmentApp.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } // Agregué el correo electrónico que está en la tabla de la base de datos
        public DateTime CreatedAt { get; set; } // Para reflejar la fecha de creación

        // Relación con las materias
        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
        public List<StudentProgramEnrollment> StudentEnrollments { get; set; } = new List<StudentProgramEnrollment>();
    }

}