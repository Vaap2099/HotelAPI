using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    public class HomeController : Controller
    {
                
        private readonly HotelAPIDbContext _HotelContext;
        public HomeController(HotelAPIDbContext context)
            {
                _HotelContext = context;
            }

        [HttpGet]
        public async Task <IActionResult> GetHabitaciones()
        {
            return Ok(await _HotelContext.Habitaciones.ToListAsync());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
