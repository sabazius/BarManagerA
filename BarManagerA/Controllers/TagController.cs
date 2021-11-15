using BarManagerA.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BarManagerA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        public TagController(ILogger<TagController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return new List<Tag>()
            {
                {
                    new Tag()
                    {
                        Id = 1,
                        Name = "TestName"
                    }
                },
                {
                    new Tag()
                    {
                        Id = 2,
                        Name = "TestName2"
                    }
                }
            };
        }
    }
}
