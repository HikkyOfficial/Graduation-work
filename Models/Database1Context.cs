using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class Database1Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudyingPlan> StudyingPlans { get; set; }
        public DbSet<Attestation> Attestations { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}