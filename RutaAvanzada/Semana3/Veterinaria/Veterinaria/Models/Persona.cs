namespace Veterinaria.Models;

public abstract class Persona //SuperClase
{
    protected string Nombre { get; set; }
    protected string Apellido { get; set; }
    protected int Edad { get; set; }

    protected Persona(string nombre, string apellido, int edad) //Constructor
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
    }
}