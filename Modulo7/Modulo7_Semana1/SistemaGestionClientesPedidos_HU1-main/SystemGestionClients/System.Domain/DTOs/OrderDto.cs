namespace System.Domain.DTOs;

public class OrderDto
{
    public int customerId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Today;
    public string Status { get; set; } = string.Empty;
}