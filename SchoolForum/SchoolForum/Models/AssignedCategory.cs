using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class AssignedCategory
    {
        public int CtID { get; set; }
        public string CtName { get; set; }
        public bool Assigned { get; set; }
    }
}

