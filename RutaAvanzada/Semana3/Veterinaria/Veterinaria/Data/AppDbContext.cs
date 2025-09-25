using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;

namespace Veterinaria.Data;

public class AppDbContext : DbContext
{
    public DbSet<Persona>  Personas { get; set; }
    public DbSet<Cliente>  Clientes { get; set; }
    public DbSet<Veterinario>   Veterinarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=veterinaria;user=root;password=",
                new MySqlServerVersion(new Version(8, 0, 36))
            );
        }
    }
}