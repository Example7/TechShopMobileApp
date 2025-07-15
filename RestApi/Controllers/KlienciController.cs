using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.ForView;
using RestApi.Models;
using RestApi.Models.Contexts;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlienciController : ControllerBase
    {
        private readonly CompanyContext _context;

        public KlienciController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Klienci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KlientForView>>> GetKlienci()
        {
          if (_context.Klienci == null)
          {
              return NotFound();
          }
            return (await _context.Klienci.ToListAsync()).Select(cli => (KlientForView)cli).ToList();
        }

        // GET: api/Klienci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KlientForView>> GetKlienci(int id)
        {
          if (_context.Klienci == null)
          {
              return NotFound();
          }
            var klienci = await _context.Klienci.FindAsync(id);

            if (klienci == null)
            {
                return NotFound();
            }

            return (KlientForView)klienci;
        }

        // PUT: api/Klienci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlienci(int id, KlientForView klienci)
        {
            if (id != klienci.KlientId)
            {
                return BadRequest();
            }

            Klienci cliToChange = klienci;
            _context.Entry(cliToChange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlienciExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Klienci
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KlientForView>> PostKlienci(KlientForView klienci)
        {
          if (_context.Klienci == null)
          {
              return Problem("Entity set 'CompanyContext.Klienci'  is null.");
          }

            Klienci cliToChange = klienci;
            _context.Klienci.Add(cliToChange);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(KlienciExists(klienci.KlientId))
                {
                    return Conflict();
                } 
                else
                {
                    throw;
                }
            }
            return Ok(cliToChange);
        }

        // DELETE: api/Klienci/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKlienci(int id)
        {
            if (_context.Klienci == null)
            {
                return NotFound();
            }
            var klienci = await _context.Klienci.FindAsync(id);
            if (klienci == null)
            {
                return NotFound();
            }

            _context.Klienci.Remove(klienci);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool KlienciExists(int id)
        {
            return (_context.Klienci?.Any(e => e.KlientId == id)).GetValueOrDefault();
        }
    }
}
