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
    public class ReservationsController : ControllerBase
    {
        private readonly degraafContext _context;

        public ReservationsController(degraafContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservations>> GetReservations(long id)
        {
            var reservations = await _context.Reservations.FindAsync(id);

            if (reservations == null)
            {
                return NotFound();
            }

            return reservations;
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservations(long id, Reservations reservations)
        {
            if (id != reservations.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationsExists(id))
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

        // POST: api/Reservations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Reservations>> PostReservations(Reservations reservations)
        {
            _context.Reservations.Add(reservations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservations", new { id = reservations.Id }, reservations);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservations>> DeleteReservations(long id)
        {
            var reservations = await _context.Reservations.FindAsync(id);
            if (reservations == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservations);
            await _context.SaveChangesAsync();

            return reservations;
        }

        private bool ReservationsExists(long id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
