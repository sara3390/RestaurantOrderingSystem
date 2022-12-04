using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Data;
using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.Controllers; 

public class TableController : Controller
{
    private readonly RestaurantContext _context;

    public TableController(RestaurantContext context)
    {
        _context = context;
    }

    // GET: Table
    public async Task<IActionResult> Index()
    {
        return View(await _context.tables.ToListAsync());
    }

    // GET: Table/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var table = await _context.tables
            .FirstOrDefaultAsync(m => m.TableID == id);
        if (table == null)
        {
            return NotFound();
        }

        return View(table);
    }

    // GET: Table/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Table/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("TableID,numOfChairs")] Table table)
    {
        if (!ModelState.IsValid) return View(table);
        _context.Add(table);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Table/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var table = await _context.tables.FindAsync(id);
        if (table == null)
        {
            return NotFound();
        }
        return View(table);
    }

    // POST: Table/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("TableID,numOfChairs")] Table table)
    {
        if (id != table.TableID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(table);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(table.TableID))
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
        return View(table);
    }

    // GET: Table/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var table = await _context.tables
            .FirstOrDefaultAsync(m => m.TableID == id);
        if (table == null)
        {
            return NotFound();
        }

        return View(table);
    }

    // POST: Table/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var table = await _context.tables.FindAsync(id);
        _context.tables.Remove(table);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TableExists(int id)
    {
        return _context.tables.Any(e => e.TableID == id);
    }
}