using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System.Domain.Models;

public class Order
{
    [Key] public int Id { get; set; }
    [Required] [ForeignKey("Customer")] public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    [Required] public DateTime OrderDate { get; set; } = DateTime.Today;
    [Required] [MaxLength(50)] public string Status { get; set; } = string.Empty;
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}