using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Reservaciones : Controller
    {
        private readonly HotelAPIDbContext _HotelContext;
        public Reservaciones(HotelAPIDbContext context)
        {
            _HotelContext = context;
        }
        [HttpGet("api/reservaciones")]
        public async Task<IActionResult> GetReservaciones()
        {
            return Ok(await _HotelContext.Reservaciones.ToListAsync());
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetReservacion([FromRoute] int Id)
        {
            var reservacion = await _HotelContext.Reservaciones.FindAsync(Id);
            if (reservacion == null)
            {
                return NotFound();
            }
            return Ok(reservacion);
        }

        [HttpPost("api/reservaciones")]
        public async Task<IActionResult> AddReservaciones(Reservacion reservacion)
        {
            var agregarReservacion = new Reservacion()
            {
                NumeroHabitacion = reservacion.NumeroHabitacion,
                IdCliente = reservacion.IdCliente,
                FechaInicio= reservacion.FechaInicio,
                FechaFinal=reservacion.FechaFinal,
                NoPersonas=reservacion.NoPersonas,

            };
            await _HotelContext.Reservaciones.AddAsync(agregarReservacion);
            await _HotelContext.SaveChangesAsync();
            return Ok(agregarReservacion);
        }
    }
}
