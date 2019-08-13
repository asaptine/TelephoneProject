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
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocations(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return location;
        }
        [HttpPost]
        public async Task<IActionResult> PostLocations(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTLocations(int id, [FromBody] Location location)
        {
            location.Id = id;
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocations(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
