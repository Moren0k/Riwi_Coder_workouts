using Microsoft.EntityFrameworkCore;
using PruebaRutaAvanzada.Models;

// using PruebaRutaAvanzada.Models;

namespace PruebaRutaAvanzada.Data;

public class AppDbContext : DbContext
{
    //public DbSet<CLASES A CREAR> (IMPORTAR MODELOS)
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Email> Emails { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}