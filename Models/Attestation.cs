using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Test1.Models;

namespace Test1.Models
{
    public class Attestation
    {
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        [Key]
        public int ListId { get; set; }
        public int TeacherId { get; set; } //Псевдо FK
        public string TeacherName { get; set; }
        public string Discipline { get; set; }
        public string Form { get; set; }
        public string Result { get; set; }
        public int Score { get; set; }
        public string ECTS { get; set; }
        public int Semester { get; set; }
        public DateTime? DateOfGrading { get; set; }

        
    }
}