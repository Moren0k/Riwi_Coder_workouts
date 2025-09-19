using RiwiMusic.Models;
namespace RiwiMusic;

public class DataStore
{   
    // User : UserName UserPassword UserStatus
    public static List<User> Users = new List<User>
    {
        new User {UserName = "admin", UserPassword = "123", UserStatus = true},
        new User {UserName = "kevin", UserPassword = "321", UserStatus = false},
    };
    
    // Concert : ConcertId ConcertName ConcertCity ConcertDate ConcertPrice
    public static List<Concert> Concerts = new List<Concert>
    {
        new Concert {ConcertId = 1, ConcertName = "1", ConcertCity = "1", ConcertDate = DateTime.Now,  ConcertPrice = 100},
        new Concert { ConcertId = 2, ConcertName = "2", ConcertCity = "2", ConcertDate = new DateTime(2025,01,01),  ConcertPrice = 200},
    };
    
    // Ticket : TicketId ClientId ConcertId TicketAmount TicketPriceTotal
    public static List<Ticket> Purchases = new List<Ticket>
    {
        new Ticket {TicketId = 1, ClientId = 1, ConcertId = 1, TicketAmount = 1, TicketPriceTotal = 100},
        new Ticket {TicketId = 2, ClientId = 2, ConcertId = 2, TicketAmount = 2, TicketPriceTotal = 200},
    };
}