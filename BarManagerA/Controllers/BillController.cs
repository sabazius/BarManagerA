﻿using BarManagerA.Models.DTO;
using BarManagerA.Models.Enums;
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
                       Amount = 5,
                        BillStatus = BillStatus.Paid,
                        Created = 14112021,
                         Finished = 15112021,
                         ID = 749,
                         PaymentType = "bankTransfer"
                                }
                },

                {
                    new Bill()
                    {
                                 Amount = 2,
            BillStatus = BillStatus.WaitingToPay,
            Created = 13112021,
              Finished = 14112021,
               ID = 748,
               PaymentType = "Cash"

                    }
                },

             };
        }
    }
}