using Microsoft.AspNetCore.Mvc;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Enums;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BarManagerA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly Ilogger<ClientController> _logger;
        private readonly ICLientRepository _clientRepository;


        public ClientController(ILogger<ClientController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }
        

        }

    [HttpGet("getAll")],
    public IActionResult GetAll()
    {
        var result = _clientRepository.GetAll();

        if (result != null) return Ok(result);

        return NoContent();
    }

    [HttpGet("getById")]
    public IActionResult Get(int id)
    {
        var result = _clientRepository.GetById(id);

        if (result != null) return Ok(result);

        return NotFound(result);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] Client client)
    {
        if (client == null) return BadRequest();

        var result = _clientRepository.Create(client);

        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        if (id <= 0) return BadRequest(id);

        var result = _clientRepository.Delete(id);

        if (result != null) return Ok(result);

        return NotFound(result);
    }

    [HttpPost("Update")]
    public IActionResult Update([FromBody] Client client)
    {
        if (client == null) return BadRequest();

        var searchClient = _clientRepository.GetById(client.Id);

        if (searchClient == null) return NotFound(client);

        var result = _clientRepository.Update(client);

        if (result != null) return Ok(result);

        return NotFound(result);
    }



}    
   
