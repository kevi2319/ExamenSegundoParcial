using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen2do.Data;
using Examen2do.Models;

namespace Examen2do.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
            => await _context.Productos.ToListAsync();

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            return producto;
        }

        // PUT: api/Productoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.IdProducto) return BadRequest();
            _context.Entry(producto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Productos.Any(e => e.IdProducto == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // POST: api/Productoes
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                // Log de errores de validación
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"❌ Campo '{entry.Key}': {error.ErrorMessage}");
                    }
                }
                return BadRequest(ModelState);
            }

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto),
                                   new { id = producto.IdProducto },
                                   producto);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
