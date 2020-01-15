using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIdeGraaf.Models;

namespace WebAPIdeGraaf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly degraafContext _context;

        public ReceiptsController(degraafContext context)
        {
            _context = context;
        }

        // GET: api/Receipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipts>>> GetReceipts()
        {
            return await _context.Receipts.ToListAsync();
        }

        // GET: api/Receipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipts>> GetReceipts(long id)
        {
            var receipts = await _context.Receipts.FindAsync(id);

            if (receipts == null)
            {
                return NotFound();
            }

            return receipts;
        }

        // PUT: api/Receipts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceipts(long id, Receipts receipts)
        {
            if (id != receipts.Id)
            {
                return BadRequest();
            }

            _context.Entry(receipts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Receipts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Receipts>> PostReceipts(Receipts receipts)
        {
            _context.Receipts.Add(receipts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceipts", new { id = receipts.Id }, receipts);
        }

        // DELETE: api/Receipts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Receipts>> DeleteReceipts(long id)
        {
            var receipts = await _context.Receipts.FindAsync(id);
            if (receipts == null)
            {
                return NotFound();
            }

            _context.Receipts.Remove(receipts);
            await _context.SaveChangesAsync();

            return receipts;
        }

        private bool ReceiptsExists(long id)
        {
            return _context.Receipts.Any(e => e.Id == id);
        }
    }
}
