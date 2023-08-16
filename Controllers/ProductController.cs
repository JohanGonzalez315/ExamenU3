
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace ExamenU3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var listProducts = await _context.Products.ToListAsync();
            if (listProducts == null || listProducts.Count == 0) return NoContent();
            return Ok(listProducts);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Product product)
        {
            if (product == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(product);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (product == null || product.Id != id) return BadRequest();
            var entity = await _context.Products.FindAsync(id);
            if (entity == null) return NotFound();
            entity.Nombre = product.Nombre;
            entity.Descripcion = product.Descripcion;
            entity.Precio = product.Precio;
            entity.Cantidad = product.Cantidad;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}