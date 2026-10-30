using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class TheatreDb : DbContext
{
    public TheatreDb(DbContextOptions<TheatreDb> options)
        : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<MembershipType> MembershipType => Set<MembershipType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.MembershipType)
            .WithMany(c => c.Customer)
            .HasForeignKey(c => c.MembershipTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}