using System;
using AutoMapper;
using BarManagerA.BL.Interfaces;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _tagService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result =  _tagService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<TagResponse>(result);

            return Ok(response);
            

        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] TagRequest tagRequest)
        {
            if (tagRequest == null) return BadRequest();

            var tag = _mapper.Map<Tag>(tagRequest);

            var result = _tagService.Create(tag);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _tagService.Delete(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Tag tag)
        {
            if (tag == null) return BadRequest();

            var searchTag = _tagService.GetById(tag.Id);

            if (searchTag == null) return NotFound(tag);

            var result = _tagService.Update(tag);

            if (result != null) return Ok(result);

            return NotFound(result);
        }



    }
}
