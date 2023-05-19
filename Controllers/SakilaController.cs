using ASPMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ASPMVC.Models;


public class SakilaController : Controller
{
    private readonly SakilaDbContext _context;

    public SakilaController(SakilaDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var actor = await _context.actor.ToListAsync();
        return View(actor); 
    }

    public IActionResult Add()
    {
        return View();
    }


    // add more actions to interact with the database

    public async Task<IActionResult> Edit(int id)
    {
        var actor = await _context.actor.FindAsync(id);
        if (actor == null)
        {
            return NotFound();
        }
        return View(actor);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var actor = await _context.actor.FindAsync(id);
        _context.actor.Remove(actor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


}
