using BarManagerA.BL.Interfaces;
using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientTableController : ControllerBase
    {
        private readonly IClientTableService _clientTableService;

        public ClientTableController(IClientTableService clientTableService)
        {
            _clientTableService = clientTableService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
           var result = _clientTableService.GetAll();

            return Ok(result);
            
        }
        [HttpGet("GetByID")]
        public IActionResult GetById(int ID)
        {
            if (ID <= 0) return BadRequest();

            var result = _clientTableService.GetByID(ID);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] ClientTable clienttable)
        {
            if (clienttable == null) return BadRequest();

            var result = _clientTableService.Create(clienttable);

            return Ok(clienttable);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _clientTableService.Delete(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ClientTable clienttable)
        {
            if (clienttable == null) return BadRequest();

            var searchClienttable= _clientTableService.GetByID(clienttable.ID);

            if (searchClienttable == null) return NotFound(clienttable.ID);

            var result = _clientTableService.Update(clienttable);

            return Ok(result);
        }


    }
}
