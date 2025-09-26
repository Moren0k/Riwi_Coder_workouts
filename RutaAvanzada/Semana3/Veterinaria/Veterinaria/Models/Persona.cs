using Veterinaria.Services;

namespace Veterinaria.Models;

// Clase base abstracta
public abstract class Persona
{
    public string Nombre { get; protected set; }
    public string Apellido { get; protected set; }
    public int Edad { get; protected set; }
    public Persona() { }
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