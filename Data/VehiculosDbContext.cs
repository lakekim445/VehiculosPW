using Microsoft.EntityFrameworkCore;
using VehiculosMVC.Models;

namespace VehiculosMVC.Data
{
    public class VehiculosDbContext : DbContext
    {
        public VehiculosDbContext(
            DbContextOptions<VehiculosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
    }
}