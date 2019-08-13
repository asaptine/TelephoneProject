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

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClients(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostClients(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutClients(int id, [FromBody] Client client)
        {
            client.Id = id;
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClients(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}