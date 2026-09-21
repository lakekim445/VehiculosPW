using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosMVC.Models;
using VehiculosMVC.Data;

namespace VehiculosMVC.Controllers
{
    public class VehiculosMvcController : Controller
    {
        private readonly VehiculosDbContext _context;

        public VehiculosMvcController(VehiculosDbContext context)
        {
            _context = context;
        }

        // GET: /VehiculosMvc
        public async Task<IActionResult> Index()
        {
            var vehiculos = await _context.Vehiculos.ToListAsync();
            return View(vehiculos);
        }

        // GET: /VehiculosMvc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehiculo == null) return NotFound();

            return View(vehiculo);
        }

        // GET: /VehiculosMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /VehiculosMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Vehiculos.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: /VehiculosMvc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null) return NotFound();

            return View(vehiculo);
        }

        // POST: /VehiculosMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Vehiculos.Any(v => v.Id == id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: /VehiculosMvc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehiculo == null) return NotFound();

            return View(vehiculo);
        }

        // POST: /VehiculosMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}