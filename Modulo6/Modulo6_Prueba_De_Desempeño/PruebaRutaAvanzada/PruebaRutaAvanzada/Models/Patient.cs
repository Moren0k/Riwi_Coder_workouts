using System.ComponentModel.DataAnnotations;

namespace PruebaRutaAvanzada.Models;

public class Patient : Person
{
    [Required] public int Age { get; set; }
} 