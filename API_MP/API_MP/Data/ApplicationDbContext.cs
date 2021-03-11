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

            var trener = new ApplicationUser { Id = "1",UserName= "trener@gmail.com", NormalizedUserName= "TRENER@GMAIL.COM",NormalizedEmail= "TRENER@GMAIL.COM", Email = "trener@gmail.com", EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "Admin_123") , FirstName = "Pavel", LastName ="Markovič", WhatITeach="Tenis"};
            var student = new ApplicationUser { Id = "2", UserName = "student@gmail.com", NormalizedUserName = "STUDENT@GMAIL.COM", NormalizedEmail = "STUDENT@GMAIL.COM", Email = "student@gmail.com", EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "Admin_123"), FirstName = "Michael", LastName = "Polívka" };
            modelBuilder.Entity<ApplicationUser>().HasData(trener);
            modelBuilder.Entity<ApplicationUser>().HasData(student);


            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(s => new { s.UserId, s.RoleId });
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = trener.Id, RoleId = TrenerRole.Id });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = student.Id, RoleId = StudentRole.Id });

            //student hodiny
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 1, isOnetime = true, Start = new DateTime(2021, 2, 22, 8, 0, 0), End = new DateTime(2021, 2, 22, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 2, isOnetime = false, Start = new DateTime(2021, 2,22, 11, 0, 0), End = new DateTime(2021, 2, 22, 12, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 3, isOnetime = false, Start = new DateTime(2021, 2, 23, 8, 0, 0), End = new DateTime(2021, 2, 23, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 4, isOnetime = false, Start = new DateTime(2021, 2, 23, 12, 0, 0), End = new DateTime(2021, 2, 23, 13, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 5, isOnetime = true, Start = new DateTime(2021, 2, 24, 8, 0, 0), End = new DateTime(2021, 2, 24, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 6, isOnetime = true, Start = new DateTime(2021, 2, 24, 13, 0, 0), End = new DateTime(2021, 2, 24, 14, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 7, isOnetime = false, Start = new DateTime(2021, 2, 25, 8, 0, 0), End = new DateTime(2021, 2, 25, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 8, isOnetime = false, Start = new DateTime(2021, 2, 25, 10, 0, 0), End = new DateTime(2021, 2, 25, 11, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 9, isOnetime = false, Start = new DateTime(2021, 2, 26, 8, 0, 0), End = new DateTime(2021, 2, 26, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 10, isOnetime = true, Start = new DateTime(2021, 2, 26, 15, 0, 0), End = new DateTime(2021, 2, 26, 16, 0, 0), Person = student.Id, Requester = trener.Id, Name="Tenis" });

            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 19, isOnetime = false, Start = new DateTime(2021, 3, 1, 8, 0, 0), End = new DateTime(2021, 3, 1, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 20, isOnetime = true, Start = new DateTime(2021, 3, 1, 15, 0, 0), End = new DateTime(2021, 3, 1, 16, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 11, isOnetime = true, Start = new DateTime(2021, 3, 2, 8, 0, 0), End = new DateTime(2021, 3, 2, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 12, isOnetime = false, Start = new DateTime(2021, 3, 2, 11, 0, 0), End = new DateTime(2021, 3, 2, 12, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 13, isOnetime = false, Start = new DateTime(2021, 3, 3, 8, 0, 0), End = new DateTime(2021, 3, 3, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 14, isOnetime = false, Start = new DateTime(2021, 3, 3, 12, 0, 0), End = new DateTime(2021, 3, 3, 13, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 15, isOnetime = true, Start = new DateTime(2021, 3, 4, 8, 0, 0), End = new DateTime(2021, 3, 4, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 16, isOnetime = true, Start = new DateTime(2021, 3, 4, 13, 0, 0), End = new DateTime(2021, 3, 4, 14, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 17, isOnetime = false, Start = new DateTime(2021, 3, 5, 8, 0, 0), End = new DateTime(2021, 3, 5, 9, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            modelBuilder.Entity<Hour>().HasData(new Hour { Id = 18, isOnetime = false, Start = new DateTime(2021, 3, 5, 10, 0, 0), End = new DateTime(2021, 3, 5, 11, 0, 0), Person = student.Id, Requester = trener.Id, Name = "Tenis" });
            
        }
    }
}
