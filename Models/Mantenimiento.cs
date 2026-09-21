using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculosMVC.Models
{
    public class Mantenimiento
    {
        public int Id { get; set; }

        [Required]
        public int IdVehículo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(100)]
        public string TipoServicio { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Descripción { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }

        [ForeignKey("IdVehículo")]
        public Vehiculo? Vehiculo { get; set; }
    }
}