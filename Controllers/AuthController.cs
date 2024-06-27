using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly EcommerceContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(EcommerceContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    // POST: api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        // a try catch block to handle the exception
        try
        {
            var userExists = await _context.Users.AnyAsync(u => u.Username == user.Username);
            if (userExists)
            {
                return Conflict(new { message = "User already exists, DigitalesWeb" });
            }
            else
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(new { message = "User created with success, DigitaleWeb" });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(User loginUser)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginUser.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }
        var token = GenerateJwtToken(user);
        return Ok(new { token });

    }
    // Generate token
    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}