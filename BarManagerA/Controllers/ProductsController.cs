using AutoMapper;
using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await  _productsService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();


        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await  _productsService.GetById(id);

            if (result != null) return Ok(result);

            var response = _mapper.Map<ProductsResponse>(result);

            return Ok(response);

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create ([FromBody] ProductsRequest productsRequest)
        {
            if (productsRequest == null) return BadRequest();

            var products = _mapper.Map<Products>(productsRequest);

            var result = await _productsService.Create(products);

            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

             await _productsService.Delete(id);  
            
            return Ok(id);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Products products)
        {
            if (products == null) return BadRequest();

            var searchTag = await _productsService.GetById(products.Id);

            if (searchTag == null) return NotFound(products);

            var result = await _productsService.Update(products);

            if (result != null) return Ok(result);

            return NotFound(result);
        }
    }
}

