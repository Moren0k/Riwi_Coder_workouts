using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.Controllers;

public class UserController : Controller
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context; //DataBase
    }
    
    public ActionResult Index() //Show All
    {
        return View(_context.Users.ToList());
    }

    public ActionResult Save(User user) //Save one User
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id) //Show details of a User
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        return View(user);
    }

    public ActionResult Edit(User? userEdit) //Edit of a User
    {
        var user = _context.Users.FirstOrDefault(u => userEdit != null && u.Id == userEdit.Id);
        if (userEdit == null) return NotFound();

        if (user != null)
        {
            user.Name = userEdit.Name;
            user.Document = userEdit.Document;
            user.Email = userEdit.Email;
            user.Phone = userEdit.Phone;
        }

        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) //Detele of a User
    {
        var user = _context.Users.Find(id);
        if (user == null) return RedirectToAction("Index");
        _context.Users.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}