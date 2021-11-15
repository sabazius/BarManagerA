using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BarManagerA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        public BillController(ILogger<BillController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Bill> Get()
        {
            return new List<Bill>()
            {
                {
                    new Bill()
                    {
                       Amount = 5
                    }
                },

                {
                    new Bill()
                    {
                        BillStatus = true
                    }
                },

                {
                    new Bill()
                    {
                        Created = 14112021 
                    }
                },

                {
                    new Bill()
                    {
                        Finished = 15112021
                    }
                },

                {
                    new Bill()
                    {
                        ID = 749
                    }
                },

                {
                    new Bill()
                    {
                        PaymentType = "bankTransfer"
                    }
                }

            };
        }
    }
}
