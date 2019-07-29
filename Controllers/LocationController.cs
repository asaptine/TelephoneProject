using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.DB;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly TellContext _context; 
        public LocationsController(TellContext context)
        {
            _context = context;
            /*if (_context.Locations.Count() < 2)
            {
                _context.Locations.Add(new Location { Name = "Mraclin" });
                _context.Locations.Add(new Location { Name = "Velika Gorica" });
                _context.SaveChanges();
            }*/
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocationItems()
        {
            return await _context.Locations.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationItem(int id)
        {
            var LocationItem = await _context.Locations.FindAsync(id);
            if (LocationItem == null)
            {
                return NotFound();
            }
            return LocationItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostLocationItem(Location item)
        {
            _context.Locations.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoLocation(int id, [FromBody] Location item)
        {
            item.Id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoLocation(int id)
        {
            var todoItem = await _context.Locations.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
