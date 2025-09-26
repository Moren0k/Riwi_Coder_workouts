using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Mascota
{
    [Key] public int IdMascota { get; set; }
    public string Nombre { get; private set; }
    public string Especie { get; private set; }
    public int Edad { get; private set; }
    
    /* Constructores */
    public Mascota() { }
    public Mascota(int idMascota, string nombre, string especie, int edad)
    {
        IdMascota = idMascota;
        Nombre = nombre;
        Especie = especie;
        Edad = edad;
    }
    
    /* Metodos */
    public void Registrar()
    {
        /* implementación común */
    }

    public void Listar()
    {
        /* implementación común */
    }

    public void Editar()
    {
        /* implementación común */
    }

    public void Eliminar()
    {
        /* implementación común */
    }
}