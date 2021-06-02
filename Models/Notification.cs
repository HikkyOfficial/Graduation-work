using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Test1.Models;

namespace Test1.Models
{
    public class Notification
    {
        [Key]
        public int NoteId { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public string TeacherName { get; set; }
        public DateTime DateOfNote { get; set; }
        public string NoteText { get; set; }
        public string File1 { get; set; }
        public string File2 { get; set; }
        public string File3 { get; set; }
        public string File4 { get; set; }
        public string File5 { get; set; }
    }
}