using Microsoft.AspNetCore.Mvc;
using BarManagerA.Models.DTO;


namespace BarManagerA.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientTableController : ControllerBase
    {
        public ClientTableController()
        {

        }
        [HttpGet]
        public ClientTable Get()
        {
            return new ClientTable()
            {
                ID = 1,
                Seats = 2
            };
        }
    }
}
