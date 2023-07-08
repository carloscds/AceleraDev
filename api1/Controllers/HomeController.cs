using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;

namespace api1.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly SqlConnection _connection;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _connection = new SqlConnection("data source=(local); initial catalog=xxAceleraDev; user id=teste; password=teste;trusted_connection=true; encrypt=false");
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("OK");
    }

    [HttpPost("{valor}")]
    public IActionResult Insere(int valor)
    {
        if(valor > 0)
        {
            return Ok($"valor ok: {valor}");
        }
        else
        {
            return BadRequest("valor precisa ser maior que ZERO");
        }
    }

    [HttpPost("Estrutura")]
    public IActionResult Estrutura(Cliente cliente)
    {
        return Created("","Estrutura criada");
    }

    [HttpGet("ListaClientes")]
    public IActionResult ListaClientes()
    {
        try
        {
            var dados = _connection.Query<Cliente>("SELECT * FROM cliente");
            return Ok(dados);
        }
        catch (Exception ex)
        {
            _logger.LogError("Erro: " + ex.Message);
            return BadRequest("Erro: " + ex.Message);
        }
    }

    [HttpPost("InserirClientes")]
    public IActionResult InserirClientes([FromBody] ClienteDTO cliente )
    {
        var dados = _connection.Execute("insert into cliente(nome) values(@nome)",
                        new { nome = cliente.Nome});
        return Created("","");
    }
}
