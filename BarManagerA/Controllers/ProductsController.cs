using AutoMapper;
using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {           
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _productsService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();


        }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = _productsService.GetById(id);

            if (result != null) return Ok(result);

            var response = _mapper.Map<ProductsResponse>(result);

            return Ok(response);

        }

        [HttpPost("Create")]
        public IActionResult Create ([FromBody] ProductsRequest productsRequest)
        {
            if (productsRequest == null) return BadRequest();

            var products = _mapper.Map<Products>(productsRequest);

            var result = _productsService.Create(products);

            return Ok(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

           var result = _productsService.Delete(id);

            if (result != null) return Ok(result);

            return NotFound(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Products products)
        {
            if (products == null) return BadRequest();

            var searchTag = _productsService.GetById(products.Id);

            if (searchTag == null) return NotFound(products);

            var result = _productsService.Update(products);

            if (result != null) return Ok(result);

            return NotFound(result);
        }
    }
}

