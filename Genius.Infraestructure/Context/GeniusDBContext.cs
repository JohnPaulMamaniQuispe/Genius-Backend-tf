using Genius.Infraestructure.Model;
using Genius.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure.Context;

public class GeniusDBContext:DbContext
{
    public GeniusDBContext()
    {
        
    }
    public GeniusDBContext(DbContextOptions<GeniusDBContext> options) : base(options)
    {
    }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10628086;Pwd=aYhvH3u9Vb;Database=sql10628086;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Drives Table
        builder.Entity<Driver>().ToTable("Drivers");
        builder.Entity<Driver>().HasKey(p => p.Id);
        builder.Entity<Driver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Driver>().Property(c => c.Phone).IsRequired().HasMaxLength(9);
        
        //Cars Table
        builder.Entity<Car>().ToTable("Cars");
        builder.Entity<Car>().HasKey(p => p.Id);
        builder.Entity<Car>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Car>().Property(c => c.Placa).IsRequired().HasMaxLength(10);
        builder.Entity<Driver>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();

        //Owner Table
        builder.Entity<Owner>().ToTable("Owners");
        builder.Entity<Owner>().HasKey(p => p.Id);
        builder.Entity<Owner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Owner>().Property(c => c.Phone).IsRequired().HasMaxLength(9);
        
        
        
        //User Table       
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(c => c.Username).IsRequired().HasMaxLength(60);
        builder.Entity<User>().Property(c => c.Password).IsRequired().HasMaxLength(120);
        builder.Entity<User>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
        
    }
    
}