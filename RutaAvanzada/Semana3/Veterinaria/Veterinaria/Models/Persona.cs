using Veterinaria.Services;

namespace Veterinaria.Models;

// Clase base abstracta
public abstract class Persona
{
    private string Nombre { get; set; }
    private string Apellido { get; set; }
    private int Edad { get; set; }

    protected Persona(string nombre, string apellido, int edad)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
    }
    
    //Metodos Padres
    public virtual void Registrar(){}
    public virtual void Listar(){}
    public virtual void Editar(){}
    public virtual void Eliminar(){}
}