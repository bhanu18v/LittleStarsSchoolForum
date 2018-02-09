using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class CategoryMessagesVM
    {    
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }  

        public int MessageId { get; set; }

        [DisplayName("Message Title")]
        public string MessageTitle { get; set; }

        [DisplayName("Message Details")]
        public string MessageDetails { get; set; }

        [DisplayName("Message From:")]
        public string PostedBy { get; set; }

        [DisplayName("Message DateTime")]
        public DateTime PostDateTime { get; set; }

        //public int ReplyId { get; set; }

        //[DisplayName("Reply")]
        //public string ReplyDetails { get; set; }

        //[DisplayName("Reply From:")]
        //public string ReplyPostedBy { get; set; }

        //[DisplayName("Reply DateTime")]
        //public DateTime ReplyDateTime { get; set; }



    }
}