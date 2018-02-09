using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Message Title")]
        public string MessageTitle { get; set; }

        [DisplayName("Message Details")]
        public string MessageDetails { get; set; }

        [DisplayName("Posted By")]
        public string PostedBy { get; set; }

        [DisplayName("Date & Time")]
        public DateTime PostDateTime { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        }


    
}