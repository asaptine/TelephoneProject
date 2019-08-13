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

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            return await _context.Bills.ToListAsync();
        }


        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBills(int id)
        {
            var bill = await _context.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }
        [HttpPost]
        public async Task<IActionResult> PostBills(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBills(int id, [FromBody] Bill bill)
        {bill.Id = id;
            _context.Entry(bill).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            var bill = await _context.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            _context.Bills.Remove(bill);
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