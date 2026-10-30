using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class TheatreDb : DbContext
{
    public TheatreDb(DbContextOptions<TheatreDb> options)
        : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}