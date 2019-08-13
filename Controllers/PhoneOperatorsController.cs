using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.DB;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Controllers
{
    [Route("api/phoneOperators")]
    [ApiController]
    public class PhoneOperatorsController : ControllerBase
    {
        private readonly TellContext _context;
        public PhoneOperatorsController(TellContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneOperator>>> GetPhoneOperators()
        {
            return await _context.PhoneOperators.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneOperator>> GetPhoneOperators(int id)
        {
            var phoneOperator = await _context.PhoneOperators.FindAsync(id);
            if (phoneOperator == null)
            {
                return NotFound();
            }
            return phoneOperator;
        }
        [HttpPost]
        public async Task<IActionResult> PostPhoneOperators(PhoneOperator phoneOperator)
        {
            _context.PhoneOperators.Add(phoneOperator);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneOperators(int id, [FromBody] PhoneOperator phoneOperator)
        {
            phoneOperator.Id = id;
            _context.Entry(phoneOperator).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneOperators(int id)
        {
            var phoneOperator = await _context.PhoneOperators.FindAsync(id);

            if (phoneOperator == null)
            {
                return NotFound();
            }

            _context.PhoneOperators.Remove(phoneOperator);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
