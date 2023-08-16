
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace ExamenU3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var listCategories = await _context.Categories.ToListAsync();
            if (listCategories == null || listCategories.Count == 0) return NoContent();
            return Ok(listCategories);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Category category)
        {
            if (category == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(category);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            if (category == null || category.Id != id) return BadRequest();
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null) return NotFound();
            entity.Nombre = category.Nombre;
            entity.FechaCreacion = category.FechaCreacion;
            entity.FechaActualizacion = category.FechaActualizacion;
            
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getcategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

    }
}