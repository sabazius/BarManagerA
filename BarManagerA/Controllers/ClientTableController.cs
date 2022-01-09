using AutoMapper;
using BarManagerA.BL.Interfaces;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientTableController : ControllerBase
    {
        private readonly IClientTableService _clientTableService;
        private readonly IMapper _mapper;

        public ClientTableController(IClientTableService clientTableService, IMapper mapper )
        {
            _clientTableService = clientTableService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
           var result = _clientTableService.GetAll();

            var response = _mapper.Map<IEnumerable<ClientTableResponse>>(result);

            if (response != null) return Ok(response);

            return NoContent();

        }

        [HttpGet("GetByID")]
        public IActionResult GetById(int ID)
        {
            var result = _clientTableService.GetByID(ID);

            if (result == null) return NotFound(ID);

            var response = _mapper.Map<ClientTableResponse>(result);

            return Ok(response);

        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] ClientTableRequest clienttable)
        {
            if (clienttable == null) return BadRequest();

            var tag = _mapper.Map<ClientTable>(clienttable);

            var result = _clientTableService.Create(tag);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            _clientTableService.Delete(id);

            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ClientTable clienttable)
        {
            if (clienttable == null) return BadRequest();

            var searchTag = _clientTableService.GetByID(clienttable.ID);

            if (searchTag == null) return NotFound(clienttable);

            var result = _clientTableService.Update(clienttable);


            var response = _mapper.Map<ClientTableResponse>(result);

            if (response != null) return Ok(response);

            return NotFound(clienttable);
        }


    }
}
