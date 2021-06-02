using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test1.Models;

namespace Test1.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Cathedra { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public Teacher()
        {
            Notifications = new List<Notification>();
        }
    }
}