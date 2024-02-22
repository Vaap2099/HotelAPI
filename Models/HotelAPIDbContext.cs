using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Models
{
    public class HotelAPIDbContext: DbContext
    {
        public HotelAPIDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Habitacion> Habitaciones { get; set; } = null!;
        public virtual DbSet<Reservacion> Reservaciones { get; set; } = null!;

    }
}
