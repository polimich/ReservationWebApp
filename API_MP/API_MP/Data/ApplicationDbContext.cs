using API_MP.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Change> Changes { get; set; }
        public DbSet<Hour> Hours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var TrenerRole = new ApplicationRole { Id = Guid.NewGuid().ToString(), Name = "Trener", NormalizedName = "TRENER" };
            var StudentRole = new ApplicationRole { Id = Guid.NewGuid().ToString(), Name = "Student", NormalizedName = "STUDENT" };

            modelBuilder.Entity<ApplicationRole>().HasData(TrenerRole);
            modelBuilder.Entity<ApplicationRole>().HasData(StudentRole);

            var hasher = new PasswordHasher<ApplicationUser>();

            var trener = new ApplicationUser { Id = "1",UserName= "trener@gmail.com", NormalizedUserName= "TRENER@GMAIL.COM",NormalizedEmail= "TRENER@GMAIL.COM", Email = "trener@gmail.com", EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "Admin_123") , FirstName = "Pavel", LastName ="Markovič"};
            var student = new ApplicationUser { Id = "2", UserName = "student@gmail.com", NormalizedUserName = "STUDENT@GMAIL.COM", NormalizedEmail = "STUDENT@GMAIL.COM", Email = "student@gmail.com", EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "Admin_123"), FirstName = "Michael", LastName = "Polívka" };
            modelBuilder.Entity<ApplicationUser>().HasData(trener);
            modelBuilder.Entity<ApplicationUser>().HasData(student);


            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(s => new { s.UserId, s.RoleId });
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = trener.Id, RoleId = TrenerRole.Id });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = student.Id, RoleId = StudentRole.Id });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 1, isOnetime = true, Start = new DateTime(2021, 2, 10, 8, 0, 0), End = new DateTime(2021, 2, 10, 9, 0, 0), Person = student.Id, Requester = trener.Id });
        }
    }
}
