using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Cliente : Persona //ClaseHija
{
    [Key] private int IdCliente { get; set; }
    [MaxLength(20)] private string? Telefono { get; set; }
    [MaxLength(100)] private string? CorreoElectronico { get; set; }

    protected Cliente(int idCliente, string nombre, string apellido, int edad, string telefono,
        string correoElectronico) :
        base(nombre, apellido, edad) //Constructor
    {
        IdCliente = idCliente;
        Telefono = telefono;
        CorreoElectronico = correoElectronico;
    }
}