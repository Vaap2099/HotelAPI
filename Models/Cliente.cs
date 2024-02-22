using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Cliente
    {
        [Key] public string IdCliente { get; set; } = null!;
        public string? NombreCliente { get; set; }
        public string? Telefono { get; set; }
    }
}
