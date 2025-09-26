using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Mascota
{
    [Key] private int IdMascota { get; set; }
    [MaxLength(100)] private string Nombre { get; set; }
    [MaxLength(100)] private string Especie { get; set; }
    private int Edad { get; set; }

    protected Mascota(int idMascota, string nombre, string especie, int edad) //Constructor
    {
        IdMascota = idMascota;
        Nombre = nombre;
        Especie = especie;
        Edad = edad;
    }
}