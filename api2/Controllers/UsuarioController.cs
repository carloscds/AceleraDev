using Microsoft.AspNetCore.Mvc;

namespace api2.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
        
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }

    [HttpGet("String")]
    public string GetString()
    {
        return "OK do usuario";
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new UsuarioDTO { Nome = "Teste"});
    }

    [HttpGet("{id}")]
    public IActionResult GetId(int id)
    {
        if(id == 0)
        {
            return NotFound();
        }
        return Ok($"Seu ID de usuario: {id}");
    }

    [HttpPost]
    public IActionResult Post([FromBody] UsuarioDTO usuario)
    {
        return Created("Criado",1);
    }

    [HttpPut]
    public IActionResult Alterar([FromBody] UsuarioDTO usuario)
    {
        return Ok("Alterado");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok($"Deletado :{id}");
    }

    [HttpPatch("{id}/{nome}")]
    public IActionResult Patch(int id, string nome)
    {
        return Ok($"Alterado o nome {nome} do {id}");
    }


}
