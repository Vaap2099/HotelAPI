using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? Telefono { get; set; }
        public string? DPI { get; set; } 
    }
}
