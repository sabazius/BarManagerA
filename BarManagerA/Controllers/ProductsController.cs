using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
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

            return NotFound(result);

        }

        [HttpPost("Create")]
        public IActionResult Create ([FromBody] Products products)
        {
            if (products == null) return BadRequest();

            var result = _productsService.Create(products);

            return Ok(result);
        }
    }
}
