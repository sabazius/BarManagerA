using BarManagerA.BL.Interfaces;
using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private readonly IBillService _billService;

        public BillController(ILogger<BillController> logger, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _billService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = _billService.GetById(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Bill bill)
        {
            if (bill == null) return BadRequest();

            var result = _billService.Create(bill);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _billService.Delete(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Bill bill)
        {
            if (bill == null) return BadRequest();

            var searchBill = _billService.GetById(bill.ID);

            if (searchBill == null) return NotFound(bill);

            var result = _billService.Update(bill);

            if (result != null) return Ok(result);

            return NotFound(result);
        }



    }
}
