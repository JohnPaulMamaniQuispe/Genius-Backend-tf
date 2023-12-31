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
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
 
    public DbSet<Parking> Parkings { get; set; }
    
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    
    public DbSet<Place> Places { get; set; }
    public DbSet<Owner> Owners { get; set; }
    
    public DbSet<OwnerType> OwnerTypes { get; set; }
    
   
    
 
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10628440;Pwd=hQEfABAGpq;Database=sql10628440;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //User Table       
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(c => c.Username).IsRequired().HasMaxLength(60);
        builder.Entity<User>().Property(c => c.Password).IsRequired().HasMaxLength(120);
        builder.Entity<User>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);

        
        //Cars Table
        builder.Entity<Car>().ToTable("Cars");
        builder.Entity<Car>().HasKey(p => p.Id);
        builder.Entity<Car>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Car>().Property(c => c.Placa).IsRequired().HasMaxLength(10);
        builder.Entity<Driver>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        
        //Drives Table
        builder.Entity<Driver>().ToTable("Drivers");
        builder.Entity<Driver>().HasKey(p => p.Id);
        builder.Entity<Driver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Driver>().Property(c => c.Phone).IsRequired().HasMaxLength(9);
        
        //Reservation Table
        builder.Entity<Reservation>().ToTable("Reservations");
        builder.Entity<Reservation>().HasKey(p => p.Id);
        builder.Entity<Reservation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Driver>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Parking>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();

        //Parking Table
        builder.Entity<Parking>().ToTable("Parkings");
        builder.Entity<Parking>().HasKey(p => p.Id);
        builder.Entity<Parking>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PaymentMethod>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Owner>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();


        // PaymentMethods Table
        builder.Entity<PaymentMethod>().ToTable("PaymentMethods");
        builder.Entity<PaymentMethod>().HasKey(p => p.Id);
        builder.Entity<PaymentMethod>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PaymentMethod>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        
        
        
         
        //Place Table
        builder.Entity<Place>().ToTable("Places");
        builder.Entity<Place>().HasKey(p => p.Id);
        builder.Entity<Place>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Parking>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        
        
        
        
        //Owner Table
        builder.Entity<Owner>().ToTable("Owners");
        builder.Entity<Owner>().HasKey(p => p.Id);
        builder.Entity<Owner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Owner>().Property(c => c.Phone).IsRequired().HasMaxLength(9);
        
        
     
         
        //OwnerType Table
        builder.Entity<OwnerType>().ToTable("OwnerTypes");
        builder.Entity<OwnerType>().HasKey(p => p.Id);
        builder.Entity<OwnerType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       
        
        
    }
    
}