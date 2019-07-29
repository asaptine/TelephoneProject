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
        public async Task<ActionResult<IEnumerable<PhoneOperator>>> GetPhoneOperatorItems()
        {
            return await _context.PhoneOperators.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneOperator>> GetPhoneOperatorItem(int id)
        {
            var PhoneOperatorItem = await _context.PhoneOperators.FindAsync(id);
            if (PhoneOperatorItem == null)
            {
                return NotFound();
            }
            return PhoneOperatorItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostPhoneOperatorItem(PhoneOperator item)
        {
            _context.PhoneOperators.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoPhoneOperator(int id, [FromBody] PhoneOperator item)
        {
            item.Id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoPhoneOperator(int id)
        {
            var todoItem = await _context.PhoneOperators.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.PhoneOperators.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
