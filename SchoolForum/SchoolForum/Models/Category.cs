using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Models.ApplicationUser> users { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        

    }
}