using Microsoft.AspNetCore.Mvc;
using PruebaRutaAvanzada.Data;

namespace PruebaRutaAvanzada.Controllers;

public class EmailController : Controller
{
    private readonly AppDbContext _context;

    public EmailController(AppDbContext context)
    {
        _context = context; //DB
    }

    public IActionResult Index()
    {
        var emails = _context.Emails.ToList();
        return View(emails);
    }
}