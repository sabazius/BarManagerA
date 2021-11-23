using BarManagerA.Models.DTO;
using BarManagerA.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
                    Amount = 5,
                    BillStatus = BillStatus.Paid,
                    DateTimeCreated = DateTime.Now,
                    DateTimeFinished = DateTime.Now,
                    ID = 888,
                    PaymentType = PaymentType.CreditCard
                    }
                },

                {
                    new Bill()
                    {
                    Amount = 2,
                    BillStatus = BillStatus.WaitingToPay,
                    DateTimeCreated = DateTime.Now,
                    DateTimeFinished = DateTime.Now,
                    ID = 848,
                    PaymentType = PaymentType.CreditCard
                    }
                },

             };
        }
    }
}
