using System.ComponentModel.DataAnnotations;

namespace VehiculosMVC.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Placa { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; } = string.Empty;

        public int Año { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo { get; set; } = string.Empty;
    }
}