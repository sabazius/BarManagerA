using System;
using AutoMapper;
using BarManagerA.BL.Interfaces;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;
using Microsoft.AspNetCore.Mvc;
namespace BarManagerA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = _employeeService.GetById(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] EmployeeRequest employeeRequest)
        {
            if (employeeRequest == null) return BadRequest();

            var employee = _mapper.Map<Employee>(employeeRequest);

            var result = _employeeService.Create(employee);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _employeeService.Delete(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();

            var searchTag = _employeeService.GetById(employee.Id);

            if (searchTag == null) return NotFound(employee);

            var result = _employeeService.Update(employee);

            if (result != null) return Ok(result);

            return NotFound(result);
        }



    }
}