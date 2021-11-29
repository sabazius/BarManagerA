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
        private readonly IProductsRepository _productsRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductsRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _productsRepository.GetAll();

            if (result != null) return Ok(result);

            return NoContent();


        }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result = _productsRepository.GetById(id);

            if (result != null) return Ok(result);

            return NotFound(result);

        }

        [HttpPost("Create")]
        public IActionResult Create ([FromBody] Products products)
        {
            if (products == null) return BadRequest();

            var result = _productsRepository.Create(products);

            return Ok(result);
        }
    }
}
