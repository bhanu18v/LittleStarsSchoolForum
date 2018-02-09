using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class Class
    {
        public int Id { get; set; }
        [DisplayName("Class Name")]
        public string ClassName { get; set; }

        public virtual ICollection<Models.ApplicationUser> ClassMembers { get; set; }
    }
}