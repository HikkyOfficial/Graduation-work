using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test1.Models;
//using System.ComponentModel.DataAnnotations;

namespace Test1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        //[Required]
        public string Email { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public int? StudyingPlanId { get; set; }
        public StudyingPlan StudyingPlan { get; set; }

        public ICollection<Attestation> Attestations { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; }
        public Student()
        {
            Attestations = new List<Attestation>();
            Portfolios = new List<Portfolio>();
        }

        


    }
}