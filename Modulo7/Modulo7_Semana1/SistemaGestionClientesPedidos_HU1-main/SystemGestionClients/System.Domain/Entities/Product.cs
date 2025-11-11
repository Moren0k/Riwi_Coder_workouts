using System.ComponentModel.DataAnnotations;

namespace System.Domain.Models;

public class Product
{
    [Key] public int Id { get; set; }
    [Required][MaxLength(100)] public string Name { get; set; } = String.Empty;
    [Required] public double Price { get; set; }
}