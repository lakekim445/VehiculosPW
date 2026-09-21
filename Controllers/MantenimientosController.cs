using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosMVC.Models;
using VehiculosMVC.Data;

namespace VehiculosMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientosController : ControllerBase
    {
        private readonly VehiculosDbContext _context;

        public MantenimientosController(VehiculosDbContext context)
        {
            _context = context;
        }

        // GET: api/Mantenimientos
        [HttpGet]
        public async Task<IActionResult> GetMantenimientos()
        {
            var mantenimientos = await _context.Mantenimientos
                .Include(m => m.Vehiculo)
                .ToListAsync();
            return Ok(mantenimientos);
        }

        // GET: api/Mantenimientos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMantenimiento(int id)
        {
            var mantenimiento = await _context.Mantenimientos
                .Include(m => m.Vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mantenimiento == null) return NotFound();
            return Ok(mantenimiento);
        }

        // GET: api/Mantenimientos/vehiculo/1
        [HttpGet("vehiculo/{idVehiculo}")]
        public async Task<IActionResult> GetMantenimientosPorVehiculo(int idVehiculo)
        {
            var mantenimientos = await _context.Mantenimientos
                .Where(m => m.IdVehículo == idVehiculo)
                .Include(m => m.Vehiculo)
                .ToListAsync();

            return Ok(mantenimientos);
        }

        // POST: api/Mantenimientos
        [HttpPost]
        public async Task<IActionResult> PostMantenimiento(Mantenimiento mantenimiento)
        {
            _context.Mantenimientos.Add(mantenimiento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMantenimiento),
                new { id = mantenimiento.Id }, mantenimiento);
        }

        // PUT: api/Mantenimientos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMantenimiento(int id, Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.Id) return BadRequest();

            _context.Entry(mantenimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(mantenimiento);
        }

        // DELETE: api/Mantenimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento(int id)
        {
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null) return NotFound();

            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Mantenimiento eliminado correctamente" });
        }
    }
}