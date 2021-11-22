using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BarManagerA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        private readonly ITagRepository _tagRepository;

        public TagController(ILogger<TagController> logger, ITagRepository tagRepository)
        {
            _logger = logger;
            _tagRepository = tagRepository;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _tagRepository.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result =  _tagRepository.GetById(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Tag tag)
        {
            if (tag == null) return BadRequest();

            var result = _tagRepository.Create(tag);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _tagRepository.Delete(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Tag tag)
        {
            if (tag == null) return BadRequest();

            var searchTag = _tagRepository.GetById(tag.Id);

            if (searchTag == null) return NotFound(tag);

            var result = _tagRepository.Update(tag);

            if (result != null) return Ok(result);

            return NotFound(result);
        }



    }
}
