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
        public async Task<ActionResult<IEnumerable<Phone>>> GetPhoneItems()
        {
            return await _context.Phones.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> GetPhoneItem(int id)
        {
            var PhoneItem = await _context.Phones.FindAsync(id);
            if (PhoneItem == null)
            {
                return NotFound();
            }
            return PhoneItem;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoPhone(int id, [FromBody] Phone item)
        {
            item.Id = id;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostPhoneItem(Phone item)
        {
            _context.Phones.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoPhone(int id)
        {
            var todoItem = await _context.Phones.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Phones.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

