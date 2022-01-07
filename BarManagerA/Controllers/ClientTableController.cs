using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientTableController : ControllerBase
    {
        private readonly IClientTableRepository _clientTableRepository;

        public ClientTableController(IClientTableRepository clientTableRepository)
        {
            _clientTableRepository = clientTableRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
           var result = _clientTableRepository.GetAll();

            return Ok(result);
            
        }
        [HttpGet("GetByID")]
        public IActionResult GetById(int ID)
        {
            if (ID <= 0) return BadRequest();

            var result = _clientTableRepository.GetByID(ID);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] ClientTable clienttable)
        {
            if (clienttable == null) return BadRequest();

            var result = _clientTableRepository.Create(clienttable);

            return Ok(clienttable);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _clientTableRepository.Delete(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ClientTable clienttable)
        {
            if (clienttable == null) return BadRequest();

            var searchClienttable= _clientTableRepository.GetByID(clienttable.ID);

            if (searchClienttable == null) return NotFound(clienttable.ID);

            var result = _clientTableRepository.Update(clienttable);

            return Ok(result);
        }


    }
}
