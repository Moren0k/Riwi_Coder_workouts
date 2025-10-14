namespace PruebaRutaAvanzada.Models;

public class Email
{
    public int Id { get; set; }
    public string? EmailTo { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

    public Email(string emailTo, string message)
    {
        EmailTo = emailTo;
        Message = message;
    }

    public Email() { }
}