using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test1.Models;

namespace Test1.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Faculty { get; set; }
        public string Direction { get; set; }
        public string Profile { get; set; }
        public string GroupName { get; set; }
        public int GroupNumber { get; set; }
        public int CourseNumber { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public Group()
        {
            Students = new List<Student>();
            Notifications = new List<Notification>();
        }
    }
}