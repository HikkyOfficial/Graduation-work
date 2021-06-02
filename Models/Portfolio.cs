using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Test1.Models;

namespace Test1.Models
{
    public class Portfolio
    {
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PortfolioId { get; set; }
        public string Category { get; set; } 
        public string FileName { get; set; }
        public string FileLink { get; set; }
        public DateTime DateOfUpload { get; set; }
    }
}