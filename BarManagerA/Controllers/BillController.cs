using AutoMapper;
using BarManagerA.BL.Interfaces;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public BillController(ILogger<BillController> logger, IBillService billService, IMapper mapper)
        {
            _logger = logger;
            _billService = billService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task <IActionResult> GetAll()
        {
            var result = await _billService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _billService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<BillResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task <IActionResult> Create([FromBody] BillRequest billRequest)
        {
            if (billRequest == null) return BadRequest();

            var tag = _mapper.Map<Bill>(billRequest);

            var result = await _billService.Create(tag);

            return Ok(result);
        }

        [HttpDelete]
        public async Task <IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            await _billService.Delete(id);

           return Ok(id);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Bill bill)
        {
            if (bill == null) return BadRequest();

            var searchBill = await _billService.GetById(bill.Id);

            if (searchBill == null) return NotFound(bill);

            var result =  await _billService.Update(bill);

            if (result != null) return Ok(result);

            return NotFound(result);
        }



    }
}
