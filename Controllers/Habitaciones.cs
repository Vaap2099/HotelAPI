using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Habitaciones : ControllerBase
    {
        
        private readonly HotelAPIDbContext _HotelContext;
        public Habitaciones(HotelAPIDbContext context)
        {
            _HotelContext = context;
        }

        [HttpGet("api/habitaciones")]
        public async Task< IActionResult > GetHabitaciones()
        {
            return Ok(await _HotelContext.Habitaciones.ToListAsync());
        }

        [HttpGet]
        [Route("{NumeroHabitacion:int}")]
        public async Task<IActionResult> GetHabitacion([FromRoute] int NumeroHabitacion)
        {
            var habitacion = await _HotelContext.Habitaciones.FindAsync(NumeroHabitacion);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }

        [HttpPost("api/habitaciones")]
        public async Task<IActionResult> AddHabitacion(Habitacion habitacion)
        {
            var agregarhabitacion = new Habitacion()
            {
                NumeroHabitacion = habitacion.NumeroHabitacion,
                Descripcion = habitacion.Descripcion,
                Fotos = habitacion.Fotos,
                Precio = habitacion.Precio,
                NumeroCamas=habitacion.NumeroCamas,
                Suite=habitacion.Suite,

            };
            await _HotelContext.Habitaciones.AddAsync(agregarhabitacion);
            await _HotelContext.SaveChangesAsync();                
            return Ok(agregarhabitacion);
        }

        [HttpPut]
        [Route("{NumeroHabitacion:int}")]
        public async Task<IActionResult> UpdateHabitacion([FromRoute] int NumeroHabitacion, Habitacion updateHabitacion)
        {
            var habitacion = await _HotelContext.Habitaciones.FindAsync(NumeroHabitacion);
            if (habitacion != null)
            {
                habitacion.NumeroHabitacion = updateHabitacion.NumeroHabitacion;
                habitacion.Descripcion = updateHabitacion?.Descripcion;
                habitacion.Precio = updateHabitacion?.Precio;
                habitacion.Fotos = updateHabitacion?.Fotos;
                habitacion.NumeroCamas = updateHabitacion?.NumeroCamas;
                if (updateHabitacion.Suite != null) { 
                    habitacion.Suite = updateHabitacion.Suite;
                }
                else
                {
                    habitacion.Suite = false;
                }
                habitacion.Suite = updateHabitacion.Suite;
                await _HotelContext.SaveChangesAsync();
                return Ok(habitacion);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{NumeroHabitacion:int}")]
        public async Task<IActionResult> DeleteHabitacion([FromRoute] int NumeroHabitacion)
        {
            var habitacion = await _HotelContext.Habitaciones.FindAsync(NumeroHabitacion);
            if (habitacion != null)
            {
                _HotelContext.Remove(habitacion);
                _HotelContext.SaveChanges();
                return Ok(habitacion);
            }
            return NotFound();
        }

        //public IActionResult Index()
        //{
        //    return ViewComponent();
        //}
    }
}
