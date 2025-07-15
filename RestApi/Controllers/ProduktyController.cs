using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.ForView;
using RestApi.Models;
using RestApi.Models.Contexts;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ProduktyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Produkty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduktForView>>> GetProdukty()
        {
          if (_context.Produkty == null)
          {
              return NotFound();
          }
            return (await _context.Produkty.Include(prod => prod.Kategorie).ToListAsync()).Select(prod => (ProduktForView)prod).ToList();
        }

        // GET: api/Produkty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProduktForView>> GetProdukty(int id)
        {
          if (_context.Produkty == null)
          {
              return NotFound();
          }
            var produkty = await _context.Produkty.Include(prod => prod.Kategorie).FirstOrDefaultAsync(prod => prod.ProduktId == id);

            if (produkty == null)
            {
                return NotFound();
            }

            return (ProduktForView)produkty;
        }

        // PUT: api/Produkty/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukty(int id, ProduktForView produkty)
        {
            if (id != produkty.ProduktId)
            {
                return BadRequest();
            }

            Produkty produktyToChange = produkty;
            _context.Entry(produktyToChange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktyExists(id))
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

        // POST: api/Produkty
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProduktForView>> PostProdukty(ProduktForView produkty)
        {
          if (_context.Produkty == null)
          {
              return Problem("Entity set 'CompanyContext.Produkty'  is null.");
          }
            Produkty produktyToChange = produkty;
            _context.Produkty.Add(produktyToChange);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProduktyExists(produkty.ProduktId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok(produktyToChange);
        }

        // DELETE: api/Produkty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdukty(int id)
        {
            if (_context.Produkty == null)
            {
                return NotFound();
            }
            var produkty = await _context.Produkty.FindAsync(id);
            if (produkty == null)
            {
                return NotFound();
            }

            _context.Produkty.Remove(produkty);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProduktyExists(int id)
        {
            return (_context.Produkty?.Any(e => e.ProduktId == id)).GetValueOrDefault();
        }
    }
}
