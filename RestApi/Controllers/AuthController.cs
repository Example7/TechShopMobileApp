using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Models.Contexts;
using RestApi.Models.DTO;
using RestApi.Services;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly CompanyContext _context;

    public AuthController(CompanyContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (await _context.Uzytkownicy.AnyAsync(u => u.Email == dto.Email))
            return BadRequest("Użytkownik z takim emailem już istnieje");

        var hasloHash = BCrypt.Net.BCrypt.HashPassword(dto.Haslo);

        var user = new Uzytkownik
        {
            Email = dto.Email,
            HasloHash = hasloHash,
            Rola = "User"
        };

        _context.Uzytkownicy.Add(user);
        await _context.SaveChangesAsync();

        return Ok("Zarejestrowano pomyślnie");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _context.Uzytkownicy.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Haslo, user.HasloHash))
            return Unauthorized("Niepoprawny email lub hasło");

        var token = JwtService.GenerateToken(user);

        return Ok(new { token });
    }
}
