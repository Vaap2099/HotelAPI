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
        [Route("{IdCliente:int}")]
        public async Task<IActionResult> GetCliente([FromRoute] int IdCliente)
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
                DPI = cliente.DPI,

            };
            await _HotelContext.Clientes.AddAsync(agregarcliente);
            await _HotelContext.SaveChangesAsync();
            return Ok(agregarcliente);
        }

        [HttpPut]
        [Route("{IdCliente:int}")]
        public async Task<IActionResult> UpdateHabitacion([FromRoute] int IdCliente, Cliente updateCliente)
        {
            var cliente = await _HotelContext.Clientes.FindAsync(IdCliente);
            if (cliente != null)
            {
                cliente.IdCliente = updateCliente.IdCliente;
                cliente.NombreCliente = updateCliente?.NombreCliente;
                cliente.Telefono = updateCliente?.Telefono;
                cliente.DPI = updateCliente?.DPI;                
                await _HotelContext.SaveChangesAsync();
                return Ok(cliente);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{IdCliente:int}")]
        public async Task<IActionResult> DeleteHabitacion([FromRoute] int IdCliente)
        {
            var cliente = await _HotelContext.Clientes.FindAsync(IdCliente);
            if (cliente != null)
            {
                _HotelContext.Remove(cliente);
                _HotelContext.SaveChanges();
                return Ok(cliente);
            }
            return NotFound();
        }

    }
}
