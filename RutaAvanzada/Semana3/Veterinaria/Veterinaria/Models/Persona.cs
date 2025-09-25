using Veterinaria.Services;

namespace Veterinaria.Models;

// Clase base abstracta
public abstract class Persona
{
    protected string Nombre { get; set; }
    protected string Apellido { get; set; }
    protected int Edad { get; set; }

    protected Persona(string nombre, string apellido, int edad)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
    }

    public virtual void Registrar()
    {

    }

    public virtual void Listar()
    {
        /* implementación común */
    }

    public virtual void Editar()
    {
        /* implementación común */
    }

    public virtual void Eliminar()
    {
        /* implementación común */
    }
}