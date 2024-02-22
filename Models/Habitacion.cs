using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Habitacion
    {
        
        [Key] public int NumeroHabitacion { get; set; }
        public string? Fotos { get; set; }
        public string? Descripcion { get; set; }
        public double? Precio { get; set; }
        public int? NumeroCamas { get; set; }
        public bool Suite { get; set; } = false;

    }
}
