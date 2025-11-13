using Hu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hu.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    // DbSet
    // Public DbSet<Entity> Entities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    
    //
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(x => x.Id);
            user.Property(x => x.Email).IsRequired().HasMaxLength(250);
            user.HasIndex(x => x.Email).IsUnique();
            user.Property(x => x.Password).IsRequired().HasMaxLength(250);
            user.Property(u => u.Role).HasConversion<string>();
        });

        modelBuilder.Entity<Product>(product =>
        {
            product.HasKey(x => x.Id);
            product.Property(x => x.Name).IsRequired().HasMaxLength(100);
            product.HasIndex(x => x.Name).IsUnique();
            product.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            product.Property(x => x.Stock).HasDefaultValue(0);
        });
    }
}