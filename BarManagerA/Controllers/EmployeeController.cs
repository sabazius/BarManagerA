using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BarManagerA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _employeeRepository.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = _employeeRepository.GetById(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();

            var result = _employeeRepository.Create(employee);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _employeeRepository.Delete(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();

            var searchTag = _employeeRepository.GetById(employee.Id);

            if (searchTag == null) return NotFound(employee);

            var result = _employeeRepository.Update(employee);

            if (result != null) return Ok(result);

            return NotFound(result);
        }



    }
}
