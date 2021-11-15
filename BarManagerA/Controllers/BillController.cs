using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BarManagerA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        public BillController(ILogger<BillController> logger)
        {
              _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Bill_Models> Get()
        {
            return new List<Bill_Models>()
            {
                {
                    new Bill_Models()
                    {
                        Id = 1,
                        Name = "TestName"
                    }
                },
                {
                    new Bill_Models()
                    {
                        Id = 2,
                        Name = "TestName2"
                    }
                }
            };
        }
    }
}
