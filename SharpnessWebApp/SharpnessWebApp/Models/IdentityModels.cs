using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using SharpnessWebApp.Models.Sharpness_Persistence.Entities;
using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
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

        public ApplicationUser()
        {
            RegisterDate = DateTime.Now;
        }

        public string Salutation { get; set; }
        public string AcademicTitle { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Organisation { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public DateTime RegisterDate { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Organ> Organs { get; set; }
        public virtual DbSet<Reglament> Reglaments { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Stain> Stains { get; set; }
        public virtual DbSet<Tissue> Tissues { get; set; }

        public virtual DbSet<WSI> WSIs { get; set; }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}