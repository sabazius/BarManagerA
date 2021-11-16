using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller")]
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
