using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {

        }

        [HttpGet]
        public Products Get()
        {
            return new Products()
            {
                Id = 1,
                Name = "TestProducts",
                Price = 1
            };
        }
    }
}
