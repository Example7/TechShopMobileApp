using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.ForView;
using RestApi.Helpers;
using RestApi.Models.Contexts;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorieController : ControllerBase
    {
        private readonly CompanyContext _context;

        public KategorieController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Kategorie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KategorieForView>>> GetKategorie()
        {
          if (_context.Kategorie == null)
          {
              return NotFound();
          }
            return (await _context.Kategorie.ToListAsync()).Select(kat => (KategorieForView)kat).ToList();
        }

        // GET: api/Kategorie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KategorieForView>> GetKategorie(int id)
        {
          if (_context.Kategorie == null)
          {
              return NotFound();
          }
            var kategorie = await _context.Kategorie.FindAsync(id);

            if (kategorie == null)
            {
                return NotFound();
            }

            return (KategorieForView)kategorie;
        }

        // PUT: api/Kategorie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategorie(int id, KategorieForView kategorie)
        {
            if (id != kategorie.KategoriaId)
            {
                return BadRequest();
            }
            var kat = await _context.Kategorie.FindAsync(id);
            id.CopyProperties(kategorie);
            _context.Entry(kat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(kategorie);
        }

        // POST: api/Kategorie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KategorieForView>> PostKategorie(KategorieForView kategorie)
        {
          if (_context.Kategorie == null)
          {
              return Problem("Entity set 'CompanyContext.Kategorie'  is null.");
          }
            _context.Kategorie.Add(kategorie);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorieExists(kategorie.KategoriaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(kategorie);
        }

        // DELETE: api/Kategorie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategorie(int id)
        {
            if (_context.Kategorie == null)
            {
                return NotFound();
            }
            var kategorie = await _context.Kategorie.FindAsync(id);
            if (kategorie == null)
            {
                return NotFound();
            }

            _context.Kategorie.Remove(kategorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategorieExists(int id)
        {
            return (_context.Kategorie?.Any(e => e.KategoriaId == id)).GetValueOrDefault();
        }
    }
}
