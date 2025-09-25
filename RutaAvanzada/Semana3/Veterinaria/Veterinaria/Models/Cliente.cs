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
        /* implementación común */
    }

    public override void Listar()
    {
        /* implementación común */
    }

    public override void Editar()
    {
        /* implementación común */
    }

    public override void Eliminar()
    {
        /* implementación común */
    }
}