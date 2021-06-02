using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Models
{
    public class ProgressListViewModel
    {
        public IEnumerable<Attestation> Attestations { get; set; }
        public SelectList Semester { get; set; }
        public SelectList Discipline { get; set; }
    }
}