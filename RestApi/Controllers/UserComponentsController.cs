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
    public class UserComponentsController : ControllerBase
    {
        private readonly FoodContext _context;

        public UserComponentsController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/UserComponents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserComponent>>> GetUserComponent()
        {
          if (_context.UserComponent == null)
          {
              return NotFound();
          }
            return await _context.UserComponent.ToListAsync();
        }

        // GET: api/UserComponents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserComponent>> GetUserComponent(int id)
        {
          if (_context.UserComponent == null)
          {
              return NotFound();
          }
            var userComponent = await _context.UserComponent.FindAsync(id);

            if (userComponent == null)
            {
                return NotFound();
            }

            return userComponent;
        }

        // PUT: api/UserComponents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserComponent(int id, UserComponent userComponent)
        {
            if (id != userComponent.Id)
            {
                return BadRequest();
            }

            _context.Entry(userComponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserComponentExists(id))
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

        // POST: api/UserComponents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserComponent>> PostUserComponent(UserComponent userComponent)
        {
          if (_context.UserComponent == null)
          {
              return Problem("Entity set 'FoodContext.UserComponent'  is null.");
          }
            _context.UserComponent.Add(userComponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserComponent", new { id = userComponent.Id }, userComponent);
        }

        // DELETE: api/UserComponents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserComponent(int id)
        {
            if (_context.UserComponent == null)
            {
                return NotFound();
            }
            var userComponent = await _context.UserComponent.FindAsync(id);
            if (userComponent == null)
            {
                return NotFound();
            }

            _context.UserComponent.Remove(userComponent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserComponentExists(int id)
        {
            return (_context.UserComponent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
