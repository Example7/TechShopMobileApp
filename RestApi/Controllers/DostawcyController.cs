using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.ForView;
using RestApi.Helpers;
using RestApi.Models.Contexts;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DostawcyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public DostawcyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Dostawcy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DostawcyForView>>> GetDostawcy()
        {
          if (_context.Dostawcy == null)
          {
              return NotFound();
          }
            return (await _context.Dostawcy.ToListAsync()).Select(dos => (DostawcyForView)dos).ToList();
        }

        // GET: api/Dostawcy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DostawcyForView>> GetDostawcy(int id)
        {
          if (_context.Dostawcy == null)
          {
              return NotFound();
          }
            var dostawcy = await _context.Dostawcy.FindAsync(id);

            if (dostawcy == null)
            {
                return NotFound();
            }

            return (DostawcyForView)dostawcy;
        }

        // PUT: api/Dostawcy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDostawcy(int id, DostawcyForView dostawcy)
        {
            if (id != dostawcy.DostawcaId)
            {
                return BadRequest();
            }
            var dos = await _context.Dostawcy.FindAsync(id);
            dos.CopyProperties(dostawcy);
            _context.Entry(dos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DostawcyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(dostawcy);
        }

        // POST: api/Dostawcy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DostawcyForView>> PostDostawcy(DostawcyForView dostawcy)
        {
          if (_context.Dostawcy == null)
          {
              return Problem("Entity set 'CompanyContext.Dostawcy'  is null.");
          }
            
            _context.Dostawcy.Add(dostawcy);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (DostawcyExists(dostawcy.DostawcaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(dostawcy);
        }

        // DELETE: api/Dostawcy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDostawcy(int id)
        {
            if (_context.Dostawcy == null)
            {
                return NotFound();
            }
            var dostawcy = await _context.Dostawcy.FindAsync(id);
            if (dostawcy == null)
            {
                return NotFound();
            }

            _context.Dostawcy.Remove(dostawcy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DostawcyExists(int id)
        {
            return (_context.Dostawcy?.Any(e => e.DostawcaId == id)).GetValueOrDefault();
        }
    }
}
