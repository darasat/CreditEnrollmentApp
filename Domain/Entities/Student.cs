using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CreditEnrollmentApp.Domain.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public DateTime CreatedAt { get; set; } 

        [JsonIgnore]
        public List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
        [JsonIgnore]
        public List<StudentProgramEnrollment> StudentEnrollments { get; set; } = new List<StudentProgramEnrollment>();
        public int? ProgramId { get; set; }
    }

}