using System;
using Microsoft.EntityFrameworkCore;


    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=efbasicsappdb;Trusted_Connection=True;");
        }
    }
