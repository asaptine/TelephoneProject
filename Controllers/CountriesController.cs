using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.DB;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly TellContext _context;
        public CountriesController(TellContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountries(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return country;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountries(int id, [FromBody] Country country)
        {
            country.Id = id;
            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostCountries(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuntries(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
