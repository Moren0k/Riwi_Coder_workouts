using System.ComponentModel.DataAnnotations;

namespace Hu.Application.DTOs;

public class AddProductDto
{
    [Required, MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Required] public decimal Price { get; set; }
    public int Stock { get; set; }
}