using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosMVC.Models;
using VehiculosMVC.Data;

namespace VehiculosMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly VehiculosDbContext _context;

        public VehiculosController(VehiculosDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<IActionResult> GetVehiculos()
        {
            var vehiculos = await _context.Vehiculos.ToListAsync();
            return Ok(vehiculos);
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null) return NotFound();
            return Ok(vehiculo);
        }

        // POST: api/Vehiculos
        [HttpPost]
        public async Task<IActionResult> PostVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVehiculo),
                new { id = vehiculo.Id }, vehiculo);
        }

        // PUT: api/Vehiculos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id) return BadRequest();

            _context.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(vehiculo);
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null) return NotFound();

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Vehículo eliminado correctamente" });
        }
    }
}