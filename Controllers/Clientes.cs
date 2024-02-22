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

        [HttpGet]
        [Route("{IdCliente}")]
        public async Task<IActionResult> GetCliente([FromRoute] string IdCliente)
        {
            var cliente = await _HotelContext.Clientes.FindAsync(IdCliente);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost("api/clientes")]
        public async Task<IActionResult> AddCliente(Cliente cliente)
        {
            var agregarcliente = new Cliente()
            {
                IdCliente = cliente.IdCliente,
                NombreCliente = cliente.NombreCliente,
                Telefono = cliente.Telefono,

            };
            await _HotelContext.Clientes.AddAsync(agregarcliente);
            await _HotelContext.SaveChangesAsync();
            return Ok(agregarcliente);
        }
    }
}
