using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolForum.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        // Added Fields of User Table.

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string UserRoleName { get; set; }
        public int ClassId { get; set; }

        //[ForeignKey("userId")]
        //public virtual IdentityUserRole _Users { get; set; }

        // Connections
        [ForeignKey("ClassId")]
        public virtual Class Classes { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Message> UserMessages { get; set; }

        public virtual ICollection<Reply> UserReplies { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }




    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Category> Categories { get; set; }
       
        public DbSet<Class> Classes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public System.Data.Entity.DbSet<SchoolForum.Models.CategoryMessagesVM> CategoryMessagesVMs { get; set; }

        //  public System.Data.Entity.DbSet<SchoolForum.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}