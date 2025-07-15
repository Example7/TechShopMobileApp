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
    public class ZamowioneProduktyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ZamowioneProduktyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/ZamowioneProdukty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZamowioneProduktyForView>>> GetZamowioneProdukty()
        {
            if (_context.ZamowioneProdukty == null)
            {
                return NotFound();
            }

            return (await _context.ZamowioneProdukty
                .Include(cli => cli.Zamowienie)
                .Include(cli => cli.Produkt)
                .ToListAsync())
                .Select(zp => (ZamowioneProduktyForView)zp)
                .ToList();
        }

        // GET: api/ZamowioneProdukty/1/2
        [HttpGet("{zamowienieId}/{produktId}")]
        public async Task<ActionResult<ZamowioneProduktyForView>> GetZamowioneProdukty(int zamowienieId, int produktId)
        {
            var zamowioneProdukty = await _context.ZamowioneProdukty.FindAsync(zamowienieId, produktId);
            if (zamowioneProdukty == null)
            {
                return NotFound();
            }

            return (ZamowioneProduktyForView)zamowioneProdukty;
        }

        // PUT: api/ZamowioneProdukty/1/2
        [HttpPut("{zamowienieId}/{produktId}")]
        public async Task<IActionResult> PutZamowioneProdukty(int zamowienieId, int produktId, ZamowioneProduktyForView zamowioneProdukty)
        {
            if (zamowienieId != zamowioneProdukty.ZamowienieId || produktId != zamowioneProdukty.ProduktId)
            {
                return BadRequest();
            }

            var entity = await _context.ZamowioneProdukty.FindAsync(zamowienieId, produktId);
            if (entity == null)
            {
                return NotFound();
            }

            entity.CopyProperties(zamowioneProdukty);
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamowioneProduktyExists(zamowienieId, produktId))
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

        // POST: api/ZamowioneProdukty
        [HttpPost]
        public async Task<ActionResult<ZamowioneProduktyForView>> PostZamowioneProdukty(ZamowioneProduktyForView zamowioneProdukty)
        {
            if (_context.ZamowioneProdukty == null)
            {
                return Problem("Entity set 'CompanyContext.ZamowioneProdukty' is null.");
            }

            var entity = (ZamowioneProdukty)zamowioneProdukty;
            _context.ZamowioneProdukty.Add(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZamowioneProduktyExists(zamowioneProdukty.ZamowienieId, zamowioneProdukty.ProduktId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetZamowioneProdukty),
                new { zamowienieId = zamowioneProdukty.ZamowienieId, produktId = zamowioneProdukty.ProduktId },
                zamowioneProdukty);
        }

        // DELETE: api/ZamowioneProdukty/1/2
        [HttpDelete("{zamowienieId}/{produktId}")]
        public async Task<IActionResult> DeleteZamowioneProdukty(int zamowienieId, int produktId)
        {
            var entity = await _context.ZamowioneProdukty.FindAsync(zamowienieId, produktId);
            if (entity == null)
            {
                return NotFound();
            }

            _context.ZamowioneProdukty.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZamowioneProduktyExists(int zamowienieId, int produktId)
        {
            return _context.ZamowioneProdukty.Any(e =>
                e.ZamowienieId == zamowienieId && e.ProduktId == produktId);
        }
    }
}
