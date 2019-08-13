using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.DB;
using Projekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Projekt.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly TellContext _context;
        public PhonesController(TellContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phone>>> GetPhones()
        {
            return await _context.Phones.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> GetPhones(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            return phone;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhones(int id, [FromBody] Phone phone)
        {
            phone.Id = id;
            _context.Entry(phone).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostPhones(Phone phone)
        {
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhones(int id)
        {
            var phone = await _context.Phones.FindAsync(id);

            if (phone == null)
            {
                return NotFound(phone);
            }

            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

