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
        //public IActionResult Index()
        //{
        //    return ViewComponent();
        //}
    }
}
