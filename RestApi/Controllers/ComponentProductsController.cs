using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Model;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentProductsController : ControllerBase
    {
        private readonly FoodContext _context;

        public ComponentProductsController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/ComponentProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentProduct>>> GetComponentProduct()
        {
          if (_context.ComponentProduct == null)
          {
              return NotFound();
          }
            return await _context.ComponentProduct.ToListAsync();
        }

        // GET: api/ComponentProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentProduct>> GetComponentProduct(int id)
        {
          if (_context.ComponentProduct == null)
          {
              return NotFound();
          }
            var componentProduct = await _context.ComponentProduct.FindAsync(id);

            if (componentProduct == null)
            {
                return NotFound();
            }

            return componentProduct;
        }

        // PUT: api/ComponentProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentProduct(int id, ComponentProduct componentProduct)
        {
            if (id != componentProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(componentProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ComponentProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponentProduct>> PostComponentProduct(ComponentProduct componentProduct)
        {
          if (_context.ComponentProduct == null)
          {
              return Problem("Entity set 'FoodContext.ComponentProduct'  is null.");
          }
            _context.ComponentProduct.Add(componentProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponentProduct", new { id = componentProduct.Id }, componentProduct);
        }

        // DELETE: api/ComponentProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentProduct(int id)
        {
            if (_context.ComponentProduct == null)
            {
                return NotFound();
            }
            var componentProduct = await _context.ComponentProduct.FindAsync(id);
            if (componentProduct == null)
            {
                return NotFound();
            }

            _context.ComponentProduct.Remove(componentProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentProductExists(int id)
        {
            return (_context.ComponentProduct?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
