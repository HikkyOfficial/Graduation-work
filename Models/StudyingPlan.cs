using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test1.Models;

namespace Test1.Models
{
    public class StudyingPlan
    {
        public int StudyingPlanId { get; set; }
        public string DirectionCode { get; set; }
        public string Direction { get; set; }
        public string Profile { get; set; }
        public int StudyingPlanYear { get; set; }
        public string Cathedra { get; set; }
        public string Faculty { get; set; }
        public string Level { get; set; }
        public string Form { get; set; }
        public string File1 { get; set; }
        public string File2 { get; set; }
        public string File3 { get; set; }
        public string File4 { get; set; }
        public string File5 { get; set; }


        public ICollection<Student> Students { get; set; }
        public StudyingPlan()
        {
            Students = new List<Student>();
        }
    }
}