using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models.Contexts;

namespace RestApi.Controllers
{
    public class OrderValueController : Controller
    {
        private readonly CompanyContext _context;

        public OrderValueController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet("TotalOrderValueOfClientByStatus")]
        public async Task<ActionResult<decimal>> GetTotalOrderValueOfClientByStatus(int clientId, string status)
        {
            var total = await _context.ZamowioneProdukty
                .Include(zp => zp.Zamowienie)
                .Where(zp => zp.Zamowienie.KlientId == clientId && zp.Zamowienie.Status == status)
                .SumAsync(zp => (decimal)(zp.Ilosc * zp.CenaJednostkowa));

            return Ok(total);
        }

        [HttpGet("OrderCountByClient")]
        public async Task<ActionResult<int>> GetOrderCountByClient(int clientId)
        {
            var count = await _context.Zamowienia
                .CountAsync(z => z.KlientId == clientId);

            return Ok(count);
        }
    }
}
