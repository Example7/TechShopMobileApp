using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.ForView;
using RestApi.Helpers;
using RestApi.Models.Contexts;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZamowieniaController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ZamowieniaController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Zamowienia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZamowienieForView>>> GetZamowienia()
        {
          if (_context.Zamowienia == null)
          {
              return NotFound();
          }
            return (await _context.Zamowienia.Include(ord => ord.Klient).ToListAsync()).Select(ord => (ZamowienieForView)ord).ToList();
        }

        // GET: api/Zamowienia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZamowienieForView>> GetZamowienia(int id)
        {
          if (_context.Zamowienia == null)
          {
              return NotFound();
          }
            var zamowienia = await _context.Zamowienia.Include(ord => ord.Klient).FirstOrDefaultAsync(ord => ord.ZamowienieId == id);

            if (zamowienia == null)
            {
                return NotFound();
            }

            return (ZamowienieForView)zamowienia;
        }

        // PUT: api/Zamowienia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZamowienia(int id, ZamowienieForView zamowienie)
        {
            if (id != zamowienie.ZamowienieId)
            {
                return BadRequest();
            }
            var ord = await _context.Zamowienia.FindAsync(id);
            ord.CopyProperties(zamowienie);
            _context.Entry(ord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamowieniaExists(id))
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

        // POST: api/Zamowienia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ZamowienieForView>> PostZamowienia(ZamowienieForView zamowienie)
        {
          if (_context.Zamowienia == null)
          {
              return Problem("Entity set 'CompanyContext.Zamowienia'  is null.");
          }
            _context.Zamowienia.Add(zamowienie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZamowieniaExists(zamowienie.ZamowienieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok(zamowienie);
        }

        // DELETE: api/Zamowienia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZamowienia(int id)
        {
            if (_context.Zamowienia == null)
            {
                return NotFound();
            }
            var zamowienia = await _context.Zamowienia.FindAsync(id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            _context.Zamowienia.Remove(zamowienia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZamowieniaExists(int id)
        {
            return (_context.Zamowienia?.Any(e => e.ZamowienieId == id)).GetValueOrDefault();
        }
    }
}
