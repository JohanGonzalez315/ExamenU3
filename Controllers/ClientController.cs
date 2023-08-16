
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace ExamenU3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var listClients = await _context.Clients.ToListAsync();
            if (listClients == null || listClients.Count == 0) return NoContent();
            return Ok(listClients);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Client client)
        {
            if (client == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(client);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] Client client)
        {
            if (client == null || client.Id != id) return BadRequest();
            var entity = await _context.Clients.FindAsync(id);
            if (entity == null) return NotFound();
            entity.Nombre = client.Nombre;
            entity.Apellidos = client.Apellidos;
            entity.RFC = client.RFC;
            entity.CorreoElectronico = client.CorreoElectronico;
            entity.Telefono = client.Telefono;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

    }
}