using System;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


public class ApplicationContext : DbContext
{
    public DbSet<Player> Players => Set<Player>();
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MsDb"].ConnectionString);
    }
}
