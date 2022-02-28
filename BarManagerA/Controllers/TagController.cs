using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _tagService.GetAll();

            var response = _mapper.Map<IEnumerable<TagResponse>>(result);

            if (response != null) return Ok(response);

            return NoContent();
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get(int id)
        {
            var result =  await _tagService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<TagResponse>(result);

            return Ok(response);
            

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TagRequest tagRequest)
        {
            if (tagRequest == null) return BadRequest();

            var tag = _mapper.Map<Tag>(tagRequest);

            var result = await _tagService.Create(tag);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            await _tagService.Delete(id);

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Tag tag)
        {
            if (tag == null) return BadRequest();

            var searchTag = await _tagService.GetById(tag.Id);

            if (searchTag == null) return NotFound(tag);

            var result = await _tagService.Update(tag);


            var response = _mapper.Map<TagResponse>(result);

            if (response != null) return Ok(response);

            return NotFound(tag);
        }



    }
}
