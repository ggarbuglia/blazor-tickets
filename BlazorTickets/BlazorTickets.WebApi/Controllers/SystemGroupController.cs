using BlazorTickets.Data;
using BlazorTickets.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorTickets.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemGroupController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SystemGroupController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SystemGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemGroup>>> GetSystemGroups()
        {
            if (_context.SystemGroups == null)
            {
                return NotFound();
            }
            return await _context.SystemGroups.ToListAsync();
        }

        // GET: api/SystemGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemGroup>> GetSystemGroup(int id)
        {
            if (_context.SystemGroups == null)
            {
                return NotFound();
            }
            var systemGroup = await _context.SystemGroups.FindAsync(id);

            if (systemGroup == null)
            {
                return NotFound();
            }

            return systemGroup;
        }

        // PUT: api/SystemGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemGroup(int id, SystemGroup systemGroup)
        {
            if (id != systemGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemGroupExists(id))
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

        // POST: api/SystemGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SystemGroup>> PostSystemGroup(SystemGroup systemGroup)
        {
            if (_context.SystemGroups == null)
            {
                return Problem("Entity set 'DatabaseContext.SystemGroups' is null.");
            }
            _context.SystemGroups.Add(systemGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemGroup", new { id = systemGroup.Id }, systemGroup);
        }

        // DELETE: api/SystemGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemGroup(int id)
        {
            if (_context.SystemGroups == null)
            {
                return NotFound();
            }
            var systemGroup = await _context.SystemGroups.FindAsync(id);
            if (systemGroup == null)
            {
                return NotFound();
            }

            _context.SystemGroups.Remove(systemGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemGroupExists(int id)
        {
            return (_context.SystemGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
