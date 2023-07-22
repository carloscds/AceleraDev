using Microsoft.AspNetCore.Mvc;

namespace api2.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;
        
    public ClienteController(ILogger<ClienteController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("OK");
    }

    [HttpGet("{id}")]
    public IActionResult GetId(int id)
    {
        return Ok($"Seu ID: {id}");
    }
}
