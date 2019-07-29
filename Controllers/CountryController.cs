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
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var CountryItem = await _context.Countries.FindAsync(id);
            if (CountryItem == null)
            {
                return NotFound();
            }
            return CountryItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoCountry(int id, [FromBody] Country item)
        {
            item.Id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostCountryItem(Country item)
        {
            _context.Countries.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoCountry(int id)
        {
            var todoItem = await _context.Countries.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
