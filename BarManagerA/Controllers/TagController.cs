using System;
using System.Collections.Generic;
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
        private IProductsService productsService;
        private IMapper mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        public TagController(IProductsService productsService, IMapper mapper)
        {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _tagService.GetAll();

            var response = _mapper.Map<IEnumerable<TagResponse>>(result);

            if (response != null) return Ok(response);

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

            _tagService.Delete(id);

            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Tag tag)
        {
            if (tag == null) return BadRequest();

            var searchTag = _tagService.GetById(tag.Id);

            if (searchTag == null) return NotFound(tag);

            var result = _tagService.Update(tag);


            var response = _mapper.Map<TagResponse>(result);

            if (response != null) return Ok(response);

            return NotFound(tag);
        }



    }
}
