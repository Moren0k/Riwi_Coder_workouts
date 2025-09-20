using RiwiMusic.Models;
namespace RiwiMusic;
public static class DataStore
{           
    public static int IdCounter = 3;
    public static List<User> Users = new List<User>
    {// User : UserId UserName UserPassword UserEmail UserStatus
        new User {UserId = 1, UserName = "admin", UserPassword = "123", UserEmail = "admin@gmail.com", UserStatus = true},
        new User {UserId = 2, UserName = "kevin", UserPassword = "321", UserEmail = "kevin@gmail.com", UserStatus = false},
    };
    
    public static List<Concert> Concerts = new List<Concert>
    {// Concert : ConcertId ConcertName ConcertCity ConcertDate ConcertPrice
        new Concert {ConcertId = 1, ConcertName = "1", ConcertCity = "1", ConcertDate = DateTime.Now,  ConcertPrice = 100},
        new Concert { ConcertId = 2, ConcertName = "2", ConcertCity = "2", ConcertDate = new DateTime(2025,01,01),  ConcertPrice = 200},
    };
    
    public static List<Ticket> Purchases = new List<Ticket>
    {// Ticket : TicketId ClientId ConcertId TicketAmount TicketPriceTotal
        new Ticket {TicketId = 1, ClientId = 1, ConcertId = 1, TicketAmount = 1, TicketPriceTotal = 100},
        new Ticket {TicketId = 2, ClientId = 2, ConcertId = 2, TicketAmount = 2, TicketPriceTotal = 200},
    };
}