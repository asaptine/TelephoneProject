using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.DB;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly TellContext _context;
        public ClientsController(TellContext context)
        {
            _context = context;
/*            if (_context.Clients.Count() < 2)
            {
                _context.Clients.Add(new Client { LastName = "Buhovac", LocationId = 1 });
                _context.Clients.Add(new Client { LastName = "Štuban", LocationId = 2 });
                _context.SaveChanges();
            }
*/
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetBankItems()
        {
            return await _context.Clients.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientItem(int id)
        {
            var ClientItem = await _context.Clients.FindAsync(id);
            if (ClientItem == null)
            {
                return NotFound();
            }
            return ClientItem;
        }
        [HttpPost]
        public async Task<IActionResult> PostClientItem(Client item)
        {
            _context.Clients.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, [FromBody] Client item)
        {
            item.Id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoClient(int id)
        {
            var todoItem = await _context.Clients.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}