using Microsoft.EntityFrameworkCore;
// using PruebaRutaAvanzada.Models;

namespace PruebaRutaAvanzada.Data;

public class AppDbContext : DbContext
{
    //public DbSet<CLASES A CREAR> (IMPORTAR MODELOS)
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}