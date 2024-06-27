using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase{
    private readonly EcommerceContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(EcommerceContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(new { message = "User created with success, DigitaleWeb" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(User loginUser){
        
    }
}