using System.ComponentModel.DataAnnotations;
using Veterinaria.Data;
using Veterinaria.Services;
namespace Veterinaria.Models;

// Clase derivada
public class Cliente : Persona
{
    [Key] public int IdCliente { get; set; }
    [MaxLength(20)] public string? Telefono { get; private set; }
    [MaxLength(100)] public string? CorreoElectronico { get; private set; }
    
    /* Constructores */
    public Cliente() { }
    public Cliente(int idCliente, string nombre, string apellido, int edad, string telefono, string correoElectronico) :
        base(nombre, apellido, edad)
    {
        IdCliente = idCliente;
        Telefono = telefono;
        CorreoElectronico = correoElectronico;
    }
    
    /* Metodos */
    public override void Registrar()
    {
        using var context = new AppDbContext();
        var servicio = new ClienteService(context);
        servicio.RegistrarCliente(IdCliente, Nombre, Apellido, Edad, Telefono!, CorreoElectronico!);
    }

    public override void Listar()
    {
        /* implementación */
    }

    public override void Editar()
    {
        /* implementación */
    }

    public override void Eliminar()
    {
        /* implementación */
    }
}