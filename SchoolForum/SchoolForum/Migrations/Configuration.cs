namespace SchoolForum.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolForum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SchoolForum.Models.ApplicationDbContext";

        }

        protected override void Seed(SchoolForum.Models.ApplicationDbContext context)
        {
       
            // create default roles (Teacher, Student) and a Default Teacher-user for managing. 
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


         

            // creating Creating Student role 
            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }

         
            // Creating TEACHER/ADMIN Role
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole("Teacher"));

            //Creating Class
            context.Classes.AddOrUpdate(x => x.ClassName,
               new Class()
               {
                   Id = 1,
                   ClassName = "TestClass",
               });
            context.SaveChanges();


            //Creating a Default Teacher & Student User 
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Teacher@school.se",
                Email = "Teacher@school.se",
                FirstName = "Teacher",
                LastName = "Tom",
                Classes = context.Classes.FirstOrDefault(x => x.ClassName == "TestClass"),                
                ClassId = 1,
            };
            ApplicationUser user2 = new ApplicationUser()
            {
                UserName = "Student@school.se",
                Email = "Student@school.se",
                FirstName = "Student",
                LastName = "Sally",
                ClassId=1,

            };
            ApplicationUser user3 = new ApplicationUser()
            {
                UserName = "Bob@school.se",
                Email = "Bob@school.se",
                FirstName = "Student",
                LastName = "Bob",
               ClassId = 1,
            };


            // Creating a password for the Default Teacher & Student Users
            var result = UserManager.Create(user, "password");
            var result2 = UserManager.Create(user2, "password");
            var result3 = UserManager.Create(user3, "password");


            // Assigning a role to the Default Teacher User

            ApplicationUser admin =
                UserManager.FindByName("Teacher@school.se");
                UserManager.AddToRole(admin.Id, "Teacher");
                context.SaveChanges();

            ApplicationUser student =
            UserManager.FindByName("Student@school.se");
            UserManager.AddToRole(student.Id, "Student");
            context.SaveChanges();

            ApplicationUser student2 =
            UserManager.FindByName("Bob@school.se");
            UserManager.AddToRole(student2.Id, "Student");
            context.SaveChanges();

            

            //Creating test category and message
            context.Categories.AddOrUpdate(x => x.CategoryName,
               new Category()
               {
                   Id = 1,
                   CategoryName = "Test",
               });
            context.SaveChanges();


            context.Messages.AddOrUpdate(x => x.MessageTitle,
                new Message()
                {
                    Categories = context.Categories.FirstOrDefault(x => x.CategoryName == "Test"),
                    MessageTitle = "Team Meeting",
                    MessageDetails = "When can we have our first team meeting?",
                    PostedBy = "Teacher@school.se",
                    PostDateTime = DateTime.Now,
                    CategoryId = 1,
                });
            context.SaveChanges();
        }



    }




}



