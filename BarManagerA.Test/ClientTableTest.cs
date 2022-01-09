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
    public class ClientTableTestss
    {
        private readonly IMapper _mapper;
        private Mock<IClientTableRepository> _clienttableRepository;
        private IClientTableService _clienttableService;
        private ClientTableController _controller;
        private Mock<ILogger> _logger;

        private IList<ClientTable> ClientTables = new List<ClientTable>()
        {
            { new ClientTable() { Id = 1, Seats = 35} },
            { new () { Id = 2, Seats = 10} },
        };

        public ClientTableTestss()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _clienttableRepository = new Mock<IClientTableRepository>();

            _logger = new Mock<ILogger>();

            _clienttableService = new ClientTableService(_clienttableRepository.Object, _logger.Object);

            _controller = new ClientTableController(_clienttableService, _mapper);
        }

        [Fact]
        public void ClientTable_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IClientTableService>();

            mockedService.Setup(x => x.GetAll())
                .Returns(ClientTables);
            //inject
            var controller = new ClientTableController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var positions = okObjectResult.Value as IEnumerable<ClientTableResponse>;
            Assert.NotNull(positions);
            Assert.Equal(expectedCount, positions.Count());
        }

        [Fact]
        public void  ClientTable_GetByID_SeatCheck()
        {
            //setup
            var ClientTableID = 2;
            var expectedSeats = 4;

            _clienttableRepository.Setup(x => x.GetByID(ClientTableID))
                .Returns(ClientTables.FirstOrDefault(x => x.Id == ClientTableID));

            //Act
            var result = _controller.GetById(ClientTableID);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as ClientTableResponse;
            var ClientTable = _mapper.Map<ClientTable>(response);

            Assert.NotNull(ClientTable);
            Assert.Equal(expectedSeats, ClientTable.Seats);
        }

        [Fact]
        public void  ClientTable_GetByID_NotFound()
        {
            //setup
            var userPositionID = 3;

            _clienttableRepository.Setup(x => x.GetByID(userPositionID))
                .Returns(ClientTables.FirstOrDefault(x => x.Id == userPositionID));

            //Act
            var result = _controller.GetById(userPositionID);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public void ClientTable_Update_ClientTableSeat()
        {
            //setup
            var ClientTableID = 1;
            var expectedClientTableSeat = 19;

            var ClientTable = ClientTables.FirstOrDefault(x => x.Id == ClientTableID);
            ClientTable.Seats = expectedClientTableSeat;

            _clienttableRepository.Setup(x => x.GetByID(ClientTable.Id)).Returns(ClientTables.FirstOrDefault(x => x.Id == ClientTableID));
            _clienttableRepository.Setup(x => x.Update(ClientTable)).Returns(ClientTables.FirstOrDefault(x => x.Id == ClientTableID));


            //Act
            var result = _controller.Update(ClientTable);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var pos = okObjectResult.Value as ClientTableResponse;
            Assert.NotNull(pos);
            Assert.Equal(expectedClientTableSeat, pos.Seats);
        }

        [Fact]
        public void ClientTable_Delete_Existing_PositionName()
        {
            //setup
            var ClientTableID = 1;

            var ClientTable = ClientTables.FirstOrDefault(x => x.Id == ClientTableID);


            _clienttableRepository.Setup(x => x.Delete(ClientTableID)).Callback(() => ClientTables.Remove(ClientTable));

            //Act
            var result = _controller.Delete(ClientTableID);

            //Assert
            var okObjectResult = result as StatusCodeResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.Null(ClientTables.FirstOrDefault(x => x.Id == ClientTableID));
        }

        [Fact]
        public void ClientTable_Delete_NotExisting_PositionSeat()
        {
            //setup
            var userPositionID = 3;

            var position = ClientTables.FirstOrDefault(x => x.Id == userPositionID);


            _clienttableRepository.Setup(x => x.Delete(userPositionID)).Callback(() => ClientTables.Remove(position));

            //Act
            var result = _controller.Delete(userPositionID);

            //Assert
            Assert.Null(ClientTables.FirstOrDefault(x => x.Id == userPositionID));
        }

        [Fact]
        public void ClientTable_Create_PositionName()
        {
            //setup
            var clientTable = new ClientTable()
            {
                Id = 3,
                Seats = 1,
            };

            _clienttableRepository.Setup(x => x.GetAll())
                .Returns(ClientTables);

            _clienttableRepository.Setup(x => x.Create(It.IsAny<ClientTable>())).Callback(() =>
            {
                ClientTables.Add(clientTable);
            }).Returns(new ClientTable()
            {
                Id = 3,
                Seats = 4,
            });

            //Act
            var result = _controller.Create(_mapper.Map<ClientTableRequest>(clientTable));

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.NotNull(ClientTables.FirstOrDefault(x => x.Id == clientTable.Id));
        }

    }
}
