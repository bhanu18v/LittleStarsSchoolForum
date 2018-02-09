using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class MessageRepliesVM
    {
        public int Id { get; set; }

        [DisplayName("Message Title")]
        public string MessageTitle { get; set; }

        [DisplayName("Message Details")]
        public string MessageDetails { get; set; }

        [DisplayName("Posted By")]
        public string PostedBy { get; set; }

        [DisplayName("Date & Time")]
        public DateTime PostDateTime { get; set; }

        public int ReplyId { get; set; }

        [DisplayName("Reply")]
        public string ReplyDetails { get; set; }

        [DisplayName("Posted By")]
        public string ReplyPostedBy { get; set; }

        [DisplayName("Date & Time")]
        public DateTime ReplyDateTime { get; set; }
    }
}