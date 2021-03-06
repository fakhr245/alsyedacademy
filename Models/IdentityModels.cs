﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace alsyedAcademy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Outline> Outlines { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public System.Data.Entity.DbSet<alsyedAcademy.Models.FreeStudents> FreeStudents { get; set; }

        public System.Data.Entity.DbSet<alsyedAcademy.Models.Tutorial> Tutorials { get; set; }

        public System.Data.Entity.DbSet<alsyedAcademy.Models.Comment> Comments { get; set; }
    }
}