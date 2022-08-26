using BlazorTickets.Data;
using BlazorTickets.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorTickets.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SystemUserController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SystemUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemUser>>> GetSystemUsers()
        {
            if (_context.SystemUsers == null)
            {
                return NotFound();
            }
            return await _context.SystemUsers.ToListAsync();
        }

        // GET: api/SystemUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUser>> GetSystemUser(int id)
        {
            if (_context.SystemUsers == null)
            {
                return NotFound();
            }
            var systemUser = await _context.SystemUsers.FindAsync(id);

            if (systemUser == null)
            {
                return NotFound();
            }

            return systemUser;
        }

        // PUT: api/SystemUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemUser(int id, SystemUser systemUser)
        {
            if (id != systemUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemUserExists(id))
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

        // POST: api/SystemUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SystemUser>> PostSystemUser(SystemUser systemUser)
        {
            if (_context.SystemUsers == null)
            {
                return Problem("Entity set 'DatabaseContext.SystemUsers' is null.");
            }
            _context.SystemUsers.Add(systemUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemUser", new { id = systemUser.Id }, systemUser);
        }

        // DELETE: api/SystemUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemUser(int id)
        {
            if (_context.SystemUsers == null)
            {
                return NotFound();
            }
            var systemUser = await _context.SystemUsers.FindAsync(id);
            if (systemUser == null)
            {
                return NotFound();
            }

            _context.SystemUsers.Remove(systemUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemUserExists(int id)
        {
            return (_context.SystemUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
