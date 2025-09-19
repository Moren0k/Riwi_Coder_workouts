namespace RiwiMusic.Models;
public class User
{
    // User : UserName UserPassword UserStatus
    public string? UserName { get; init; }
    public string? UserPassword { get; init; }
    public bool UserStatus { get; set; }
}