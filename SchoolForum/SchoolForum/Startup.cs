using System;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolForum.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Security.Claims;
using System.Data.Entity.Migrations;

[assembly: OwinStartupAttribute(typeof(SchoolForum.Startup))]
namespace SchoolForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
                       
        }

                  
        }
    }



