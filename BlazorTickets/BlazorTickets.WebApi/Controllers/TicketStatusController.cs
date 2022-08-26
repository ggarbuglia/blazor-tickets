using BlazorTickets.Data;
using BlazorTickets.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorTickets.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatusController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TicketStatusController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TicketStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketStatus>>> GetTicketStatuses()
        {
            if (_context.TicketStatuses == null)
            {
                return NotFound();
            }
            return await _context.TicketStatuses.ToListAsync();
        }

        // GET: api/TicketStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketStatus>> GetTicketStatus(int id)
        {
            if (_context.TicketStatuses == null)
            {
                return NotFound();
            }
            var ticketStatus = await _context.TicketStatuses.FindAsync(id);

            if (ticketStatus == null)
            {
                return NotFound();
            }

            return ticketStatus;
        }

        // PUT: api/TicketStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketStatus(int id, TicketStatus ticketStatus)
        {
            if (id != ticketStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketStatusExists(id))
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

        // POST: api/TicketStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketStatus>> PostTicketStatus(TicketStatus ticketStatus)
        {
            if (_context.TicketStatuses == null)
            {
                return Problem("Entity set 'DatabaseContext.TicketStatuses' is null.");
            }
            _context.TicketStatuses.Add(ticketStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketStatus", new { id = ticketStatus.Id }, ticketStatus);
        }

        // DELETE: api/TicketStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketStatus(int id)
        {
            if (_context.TicketStatuses == null)
            {
                return NotFound();
            }
            var ticketStatus = await _context.TicketStatuses.FindAsync(id);
            if (ticketStatus == null)
            {
                return NotFound();
            }

            _context.TicketStatuses.Remove(ticketStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketStatusExists(int id)
        {
            return (_context.TicketStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
