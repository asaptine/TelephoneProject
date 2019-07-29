using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.DB;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Projekt.Controllers
{

    [Route("api/bills")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly TellContext _context;



        public BillsController(TellContext context)
        {
            _context = context;

            /*if (_context.Bills.Count() < 2)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Bills.Add(new Bill { Amount = 159 });
                _context.Bills.Add(new Bill { Amount = 15 });
                _context.SaveChanges();
            }*/
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBillItems()
        {
            return await _context.Bills.ToListAsync();
        }


        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBillsItem(int id)
        {
            var todoItem = await _context.Bills.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostTodoItem(Bill item)
        {
            _context.Bills.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, [FromBody] Bill item)
        {
            item.Id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoBill(int id)
        {
            var todoItem = await _context.Bills.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Bills.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // [HttpPost]
        // public async Task<ActionResult<IEnumerable<String>>> PostBankItems()
        // {
        //     List<string> lista = new List<string> { "a", "b", "c"};
        //     return await lista.ToAsyncEnumerable<string>();
        // }
    }
}