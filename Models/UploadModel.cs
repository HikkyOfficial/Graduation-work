using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class UploadModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}