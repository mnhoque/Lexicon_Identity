using System;
using System.Collections.Generic;
using System.Text;
using Lexicon_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string roleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();



            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = roleId
            });



            var adminUser = new AppUser
            {
                Id = userId,
                //UserName= admin@admin.com,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                CityId = 1
            };




            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "password");




            modelBuilder.Entity<AppUser>().HasData(adminUser);



            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = roleId, UserId = userId });
            modelBuilder.Entity<Country>()
                .HasMany<City>(Country => Country.Cities)
                .WithOne(City => City.Country)
                .HasForeignKey(City => City.Country_Id);
                //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<City>()
            .HasOne<AppUser>(C => C._AppUser)
            .WithOne(ad => ad.City)
            .HasForeignKey<AppUser>(ad => ad.CityId);

            modelBuilder.Entity<Country>()
            .HasOne<AppUser>(Co => Co._AppUser)
            .WithOne(ad => ad.Country)
            .HasForeignKey<AppUser>(ad => ad.CountryId);

            //string ADMIN_ID = “869d7e0c - d587 - 45f8 - 9db8 - 1199e3b14122”;
            //string ROLE_ID = “e421c09b - 7d40 - 4fa1 - 91f1 - 4f6df46db178”;

            //builder.Entity<AppUser>().HasData(new AppUser
            //{
            //    UserName = “SuperAdmin”,
            //    NormalizedName = “SuperAdmin”,
            //    Id = ROLE_ID,
            //    ConcurrencyStamp = ROLE_ID
            //});
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
