using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIdeGraaf.Models;

namespace WebAPIdeGraaf.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly degraafContext _context;

        public TablesController(degraafContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tables>>> GetTables()
        {
            return await _context.Tables.ToListAsync();
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tables>> GetTables(long id)
        {
            var tables = await _context.Tables.FindAsync(id);

            if (tables == null)
            {
                return NotFound();
            }

            return tables;
        }

        // PUT: api/Tables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTables(long id, Tables tables)
        {
            if (id != tables.Id)
            {
                return BadRequest();
            }

            _context.Entry(tables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablesExists(id))
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

        // POST: api/Tables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tables>> PostTables(Tables tables)
        {
            _context.Tables.Add(tables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTables", new { id = tables.Id }, tables);
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tables>> DeleteTables(long id)
        {
            var tables = await _context.Tables.FindAsync(id);
            if (tables == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(tables);
            await _context.SaveChangesAsync();

            return tables;
        }

        private bool TablesExists(long id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }
    }
}
