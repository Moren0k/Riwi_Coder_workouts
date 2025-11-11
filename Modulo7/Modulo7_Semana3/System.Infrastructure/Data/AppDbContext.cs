using System.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace System.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Entities
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(u =>
        {
            u.HasKey(x => x.Id);
            u.Property(x => x.Username).IsRequired().HasMaxLength(100);
            u.Property(x => x.Email).IsRequired().HasMaxLength(150);
            u.HasIndex(x => x.Email).IsUnique();
            u.HasIndex(x => x.Username).IsUnique();
            u.Property(x => x.PasswordHash).IsRequired();
        });

        modelBuilder.Entity<Product>(p =>
        {
            p.HasKey(x => x.Id);
            p.Property(x => x.Name).IsRequired().HasMaxLength(100);
            p.Property(x => x.Description).IsRequired().HasMaxLength(150).HasDefaultValue("");
            p.Property(x => x.Price).HasColumnType("decimal(18,2)");
            p.Property(x => x.Stock).HasDefaultValue(0);
        });
    }
}