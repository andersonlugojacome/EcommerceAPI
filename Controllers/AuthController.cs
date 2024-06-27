using EcommerceAPI.Data;
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
}