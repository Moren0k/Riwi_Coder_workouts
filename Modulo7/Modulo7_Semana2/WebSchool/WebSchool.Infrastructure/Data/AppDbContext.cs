using Microsoft.EntityFrameworkCore;
using WebSchool.Domain.Entities;

namespace WebSchool.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}