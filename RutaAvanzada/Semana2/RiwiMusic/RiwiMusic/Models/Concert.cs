namespace RiwiMusic.Models;
public class Concert
{
    // Concert : ConcertId ConcertName ConcertCity ConcertDate ConcertPrice
    public int ConcertId { get; set; }
    public string? ConcertName { get; set; }
    public string? ConcertCity { get; set; }
    public DateTime ConcertDate { get; set; }
    public double ConcertPrice { get; set; }
}