using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Mascota
{
    [Key] public int IdMascota { get; set; }
    [MaxLength(100)] protected string Nombre { get; set; }
    [MaxLength(100)] protected string Especie { get; set; }
    protected int Edad { get; set; }

    protected Mascota()
    {
    }

    protected Mascota(int idMascota, string nombre, string especie, int edad) //Constructor
    {
        IdMascota = idMascota;
        Nombre = nombre;
        Especie = especie;
        Edad = edad;
    }
}