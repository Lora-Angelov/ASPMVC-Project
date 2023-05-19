/*using ASPMVC.Data;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly SakilaDbContext _context;

    public HomeController(SakilaDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var actor = await _context.actor.ToListAsync();
        return View(actor); 
    }

    // add more actions to interact with the database
}*/
