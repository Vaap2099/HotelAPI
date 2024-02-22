using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Clientes : ControllerBase
    {
        private readonly HotelAPIDbContext _HotelContext;
        public Clientes(HotelAPIDbContext context)
        {
            _HotelContext = context;
        }

        [HttpGet("api/clientes")]
        public async Task<IActionResult> GetClientes()
        {
            return Ok(await _HotelContext.Clientes.ToListAsync());
        }
    }
}
