
using KolokwiumApbdNumer2.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumApbdNumer2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<SeedlingBatch> Batches { get; set; }
    public DbSet<Responsible> ResponsibleEmployees { get; set; }


    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1434;Database=TournamentDb;User Id=SA;Password=Passw0rd??;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nursery>().HasData(
            new Nursery() { NurseryId = 1, Name = "Green Forest Nursery", EstablishedDate = new DateTime(2000, 5, 20) }
        );
        modelBuilder.Entity<SeedlingBatch>().HasData(
            new SeedlingBatch()
            {
                BatchId = 1, Quantity = 500, ShownDate = new DateTime(2000, 5, 20),
                ReadyDate = new DateTime(2000, 5, 20)
            }
        );
        modelBuilder.Entity<TreeSpecies>().HasData(
            new TreeSpecies() { LatinName = "Quercus robur", GrowthTimeInYears = 5 }
        );
        modelBuilder.Entity<Responsible>().HasData(
            new Employee() { FirstName = "Anna", LastName = "Kowalska", Role = "Supervisor" },
            new Employee() { FirstName = "Jan", LastName = "Nowak", Role = "PLanter" }
        );

    }
}