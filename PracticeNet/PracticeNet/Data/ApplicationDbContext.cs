using System;
using Microsoft.EntityFrameworkCore;
using PracticeNet.Data.Configurations;
using PracticeNet.Models;

namespace PracticeNet.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplyDbSeedData(builder);



            builder.ApplyConfigurationsFromAssembly(typeof(CityConfiguration).Assembly);
            base.OnModelCreating(builder);
        }

        public static void ApplyDbSeedData(ModelBuilder builder)
        {
            builder.Entity<City>()
               .HasData(
               new City { Id = 1, Name = "Baku" },
               new City { Id = 2, Name = "Sumgayit" }
              
               );

            builder.Entity<Customer>()
                .HasData(
                new Customer { Id = 1, Name = "Ilham", Surname = "Binyetov"},
                new Customer { Id = 2, Name = "Murad", Surname = "Muradli" },
                new Customer { Id = 3, Name = "Ulvi", Surname = "Asadzade" }


                );
        }


        
    }
}
