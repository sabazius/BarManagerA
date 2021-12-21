using AutoMapper;
using BarManagerA.BL.Interfaces;
using BarManagerA.BL.Services;
using BarManagerA.DL.Interfaces;
using BarManagerA.Host.Controllers;
using BarManagerA.Host.Extensions;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
using Serilog;

namespace BarManagerA.Test
{
    public class BillTests
    {
        private readonly IMapper _mapper;
        private Mock<IBillRepository> _billRepository;
        private IBillService _billService;
        private BillController _controller;
        private Mock<ILogger> _logger;

        private IList<Bill> Bills = new List<Bill>()
        {
            { new Bill() { Id = 1, Amount = 35.2} },
            { new Bill() { Id = 2, Amount = 10.97} },
        };

        public BillTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _billRepository = new Mock<IBillRepository>();

            _logger = new Mock<ILogger>();

            _billService = new BillService(_billRepository.Object);

            //inject
            _controller = new BillController(_logger.Object, _billService, _mapper);
        }

        [Fact]
        public void Bill_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IBillService>();

            mockedService.Setup(x => x.GetAll())
                .Returns(Bills);
            //inject
            var controller = new BillController(_logger.Object, mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var positions = okObjectResult.Value as IEnumerable<BillResponse>;
            Assert.NotNull(positions);
            Assert.Equal(expectedCount, positions.Count());
        }

        [Fact]
        public void Bill_GetById_AmountCheck()
        {
            //setup
            var billId = 2;
            var expectedAmount = 10.97;

            _billRepository.Setup(x => x.GetById(billId))
                .Returns(Bills.FirstOrDefault(x => x.Id == billId));

            //Act
            var result = _controller.Get(billId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as BillResponse;
            var bill = _mapper.Map<Bill>(response);

            Assert.NotNull(bill);
            Assert.Equal(expectedAmount, bill.Amount);
        }

        [Fact]
        public void Bill_GetById_NotFound()
        {
            //setup
            var userPositionId = 3;

            _billRepository.Setup(x => x.GetById(userPositionId))
                .Returns(Bills.FirstOrDefault(x => x.Id == userPositionId));

            //Act
            var result = _controller.Get(userPositionId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public void Bill_Update_BillAmount()
        {
            //setup
            var billId = 1;
            var expectedBillAmount = 11.99;

            var bill = Bills.FirstOrDefault(x => x.Id == billId);
            bill.Amount = expectedBillAmount;

            _billRepository.Setup(x => x.GetById(bill.Id)).Returns(Bills.FirstOrDefault(x => x.Id == billId));
            _billRepository.Setup(x => x.Update(bill)).Returns(Bills.FirstOrDefault(x => x.Id == billId));


            //Act
            var result = _controller.Update(bill);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var pos = okObjectResult.Value as BillResponse;
            Assert.NotNull(pos);
            Assert.Equal(expectedBillAmount, pos.Amount);
        }

        [Fact]
        public void Bill_Delete_Existing_PositionName()
        {
            //setup
            var billId = 1;

            var bill = Bills.FirstOrDefault(x => x.Id == billId);


            _billRepository.Setup(x => x.Delete(billId)).Callback(() => Bills.Remove(bill));

            //Act
            var result = _controller.Delete(billId);

            //Assert
            var okObjectResult = result as StatusCodeResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.Null(Bills.FirstOrDefault(x => x.Id == billId));
        }

        [Fact]
        public void Bill_Delete_NotExisting_PositionAmount()
        {
            //setup
            var userPositionId = 3;

            var position = Bills.FirstOrDefault(x => x.Id == userPositionId);


            _billRepository.Setup(x => x.Delete(userPositionId)).Callback(() => Bills.Remove(position));

            //Act
            var result = _controller.Delete(userPositionId);

            //Assert
            Assert.Null(Bills.FirstOrDefault(x => x.Id == userPositionId));
        }

        [Fact]
        public void Bill_Create_PositionName()
        {
            //setup
            var bill = new Bill()
            {
                Id = 3,
                Amount = 1.3,
            };

            _billRepository.Setup(x => x.GetAll())
                .Returns(Bills);

            _billRepository.Setup(x => x.Create(It.IsAny<Bill>())).Callback(() =>
            {
                Bills.Add(bill);
            }).Returns(new Bill()
            {
                Id = 3,
                Amount = 5.49,
            });

            //Act
            var result = _controller.Create(_mapper.Map<BillRequest>(bill));

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.NotNull(Bills.FirstOrDefault(x => x.Id == bill.Id));
        }

    }
}
