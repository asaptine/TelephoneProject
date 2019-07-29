using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.DB;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Controllers
{
    [Route("api/operators")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly TellContext _context;
        public OperatorsController(TellContext context)
        {
            _context = context;
            /*if (_context.Operators.Count() < 2)
            {
                _context.Operators.Add(new Operator { Name ="tcom" });
                _context.Operators.Add(new Operator { Name ="vip" });
                _context.SaveChanges();
            }*/
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operator>>> GetOperatorItems()
        {
            return await _context.Operators.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> GetOperatorItem(int id)
        {
            var OperatorItem = await _context.Operators.FindAsync(id);
            if (OperatorItem == null)
            {
                return NotFound();
            }
            return OperatorItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostOperatorItem(Operator item)
        {
            _context.Operators.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, [FromBody] Operator item)
        {
            item.Id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }



        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoOperator(int id)
        {
            var todoItem = await _context.Operators.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Operators.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
