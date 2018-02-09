using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class Reply
    {
        public int Id { get; set; }

        [DisplayName("Reply")]
        public string ReplyDetails { get; set; }

        [DisplayName("Posted By")]
        public string ReplyPostedBy { get; set; }

        [DisplayName("Date & Time")]
        public DateTime ReplyDateTime { get; set; }

       public int MessageId { get; set; }

      public string UserId { get; set; }

       [ForeignKey("MessageId")]
        public virtual Message MessageReply { get; set; }

       [ForeignKey("UserId")]
        public virtual ApplicationUser UserReply { get; set; }
        
    }
}