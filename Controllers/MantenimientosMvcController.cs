using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehiculosMVC.Models;
using VehiculosMVC.Data;

namespace VehiculosMVC.Controllers
{
    public class MantenimientosMvcController : Controller
    {
        private readonly VehiculosDbContext _context;

        public MantenimientosMvcController(VehiculosDbContext context)
        {
            _context = context;
        }

        // GET: /MantenimientosMvc
        public async Task<IActionResult> Index()
        {
            var mantenimientos = await _context.Mantenimientos
                .Include(m => m.Vehiculo)
                .ToListAsync();
            return View(mantenimientos);
        }

        // GET: /MantenimientosMvc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var mantenimiento = await _context.Mantenimientos
                .Include(m => m.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mantenimiento == null) return NotFound();

            return View(mantenimiento);
        }

        // GET: /MantenimientosMvc/Create
        public IActionResult Create()
        {
            ViewData["IdVehículo"] = new SelectList(_context.Vehiculos, "Id", "Placa");
            return View();
        }

        // POST: /MantenimientosMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Mantenimientos.Add(mantenimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVehículo"] = new SelectList(_context.Vehiculos, "Id", "Placa", mantenimiento.IdVehículo);
            return View(mantenimiento);
        }

        // GET: /MantenimientosMvc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null) return NotFound();

            ViewData["IdVehículo"] = new SelectList(_context.Vehiculos, "Id", "Placa", mantenimiento.IdVehículo);
            return View(mantenimiento);
        }

        // POST: /MantenimientosMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mantenimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Mantenimientos.Any(m => m.Id == id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVehículo"] = new SelectList(_context.Vehiculos, "Id", "Placa", mantenimiento.IdVehículo);
            return View(mantenimiento);
        }

        // GET: /MantenimientosMvc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var mantenimiento = await _context.Mantenimientos
                .Include(m => m.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mantenimiento == null) return NotFound();

            return View(mantenimiento);
        }

        // POST: /MantenimientosMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento != null)
            {
                _context.Mantenimientos.Remove(mantenimiento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}