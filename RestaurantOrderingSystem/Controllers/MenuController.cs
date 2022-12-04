using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Data;
using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.Controllers; 

public class MenuController : Controller
{
    private readonly RestaurantContext _context;

    public MenuController(RestaurantContext context)
    {
        _context = context;
    }

    // GET: Menu
    public async Task<IActionResult> Index()
    {
        return View(await _context.menuItems.ToListAsync());
    }

    // GET: Menu/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menuItem = await _context.menuItems
            .FirstOrDefaultAsync(m => m.menuItemID == id);
        if (menuItem == null)
        {
            return NotFound();
        }

        return View(menuItem);
    }

    // GET: Menu/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Menu/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("menuItemID,price,name,description,category")] MenuItem menuItem)
    {
        menuItem.ingredients=new List<Ingredient>();
        _context.Add(menuItem);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Menu/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menuItem = await _context.menuItems.FindAsync(id);
        if (menuItem == null)
        {
            return NotFound();
        }
        return View(menuItem);
    }

    // POST: Menu/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("menuItemID,price,name,description,category")] MenuItem menuItem)
    {
        if (id != menuItem.menuItemID)
        {
            return NotFound();
        }

        
        
            try
            {
                _context.Update(menuItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(menuItem.menuItemID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
       
       
    }

    // GET: Menu/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menuItem = await _context.menuItems
            .FirstOrDefaultAsync(m => m.menuItemID == id);
        if (menuItem == null)
        {
            return NotFound();
        }

        return View(menuItem);
    }

    // POST: Menu/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var menuItem = await _context.menuItems.FindAsync(id);
        _context.menuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MenuItemExists(int id)
    {
        return _context.menuItems.Any(e => e.menuItemID == id);
    }
}