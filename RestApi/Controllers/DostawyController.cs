using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.ForView;
using RestApi.Helpers;
using RestApi.Models;
using RestApi.Models.Contexts;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DostawyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public DostawyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Dostawy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DostawyForView>>> GetDostawy()
        {
          if (_context.Dostawy == null)
          {
              return NotFound();
          }
            return (await _context.Dostawy.Include(dos => dos.Dostawca).ToListAsync()).Select(dos => (DostawyForView)dos).ToList();
        }

        // GET: api/Dostawy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DostawyForView>> GetDostawy(int id)
        {
          if (_context.Dostawy == null)
          {
              return NotFound();
          }
            var dostawy = await _context.Dostawy.Include(dos => dos.Dostawca).FirstOrDefaultAsync(dos => dos.DostawaId == id);

            if (dostawy == null)
            {
                return NotFound();
            }
                
            return (DostawyForView)dostawy;
        }

        // PUT: api/Dostawy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDostawy(int id, DostawyForView dostawy)
        {
            if (id != dostawy.DostawaId)
            {
                return BadRequest();
            }

            var dos = await _context.Dostawy.FindAsync(id);
            if (dos == null)
            {
                return NotFound();
            }
            dos.CopyProperties(dostawy);

            _context.Entry(dos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DostawyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(dostawy);
        }

        // POST: api/Dostawy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DostawyForView>> PostDostawy(DostawyForView dostawy)
        {
          if (_context.Dostawy == null)
          {
              return Problem("Entity set 'CompanyContext.Dostawy'  is null.");
          }

            var dos = (Dostawy)dostawy;
            _context.Dostawy.Add(dos);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (DostawyExists(dostawy.DostawaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(dostawy);
        }

        // DELETE: api/Dostawy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDostawy(int id)
        {
            if (_context.Dostawy == null)
            {
                return NotFound();
            }
            var dostawy = await _context.Dostawy.FindAsync(id);
            if (dostawy == null)
            {
                return NotFound();
            }

            _context.Dostawy.Remove(dostawy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DostawyExists(int id)
        {
            return (_context.Dostawy?.Any(e => e.DostawaId == id)).GetValueOrDefault();
        }
    }
}
