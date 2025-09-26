using Veterinaria.Data;
using Veterinaria.Services;
namespace Veterinaria.Models;

// Clase derivada
public class Cliente : Persona
{
    protected int IdCliente { get; set; }
    protected string Telefono { get; set; }
    protected string CorreoElectronico { get; set; }

    public Cliente(int idCliente, string nombre, string apellido, int edad, string telefono, string correoElectronico) :
        base(nombre, apellido, edad)
    {
        IdCliente = idCliente;
        Telefono = telefono;
        CorreoElectronico = correoElectronico;
    }

    public override void Registrar()
    {
        using var context = new AppDbContext();
        var servicio = new ClienteService(context);
        servicio.RegistrarCliente(IdCliente, Nombre, Apellido, Edad, Telefono, CorreoElectronico);
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