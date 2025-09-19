namespace RiwiMusic.Models;
public class Ticket
{
    // Ticket : TicketId ClientId ConcertId TicketAmount TicketPriceTotal
    public int TicketId { get; set; }
    public int ClientId { get; set; }
    public int ConcertId { get; set; }
    public int TicketAmount { get; set; }
    public double TicketPriceTotal { get; set; }
}