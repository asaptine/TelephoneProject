using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.DB;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace Projekt.Controllers
{
    [Route("api/appOperators")]
    [ApiController]
    public class AppOperatorsController : ControllerBase
    {
        private readonly TellContext _context; 
        public AppOperatorsController(TellContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppOperator>>> GetAppOperators()
        {
            return await _context.AppOperators.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppOperator>> GetAppOperators(int id)
        {
            var appOperator = await _context.AppOperators.FindAsync(id);
            if (appOperator == null)
            {
                return NotFound();
            }
            return appOperator;
        }
        [HttpPost]
        public async Task<IActionResult> PostAppOperators(AppOperator appOperator)
        {
            _context.AppOperators.Add(appOperator);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutappOerators(int id, [FromBody] AppOperator appOperator)
        {
            appOperator.Id = id;
            _context.Entry(appOperator).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperators(int id)
        {
            var appOperator = await _context.AppOperators.FindAsync(id);

            if (appOperator == null)
            {
                return NotFound();
            }

            _context.AppOperators.Remove(appOperator);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
    }
}
