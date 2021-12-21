using AutoMapper;
using BarManagerA.BL.Interfaces;
using BarManagerA.BL.Services;
using BarManagerA.Controllers;
using BarManagerA.DL.Interfaces;
using BarManagerA.Host.Controllers;
using BarManagerA.Host.Extensions;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace BarManagerA.Test
{
    public class EmployeeTests
    {
        private readonly IMapper _mapper;
        private Mock<IEmployeeRepository> _employeeRepository;
        private IEmployeeService _employeeService;
        private EmployeeController _controller;
        private Mock<ILogger> _logger;

        private IList<Employee> Employees = new List<Employee>()
        {
            { new Employee() { Id = 1, Name = "xxx"} },
            { new Employee() { Id = 2, Name = "sss"} },
        };

        public EmployeeTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _employeeRepository = new Mock<IEmployeeRepository>();

            _logger = new Mock<ILogger>();

            _employeeService = new EmployeeService(_employeeRepository.Object, _logger.Object);

            //inject
            _controller = new EmployeeController(_employeeService, _mapper);
        }

        [Fact]
        public void Employee_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IEmployeeService>();

            mockedService.Setup(x => x.GetAll())
                .Returns(Employees);
            //inject
            var controller = new EmployeeController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var positions = okObjectResult.Value as IEnumerable<EmployeeResponse>;
            Assert.NotNull(positions);
            Assert.Equal(expectedCount, positions.Count());
        }

        [Fact]
        public void Employee_GetById_NameCheck()
        {
            //setup
            var employeeId = 2;
            var expectedName = "sss";

            _employeeRepository.Setup(x => x.GetById(employeeId))
                .Returns(Employees.FirstOrDefault(x => x.Id == employeeId));

            //Act
            var result = _controller.Get(employeeId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as EmployeeResponse;
            var employee = _mapper.Map<Employee>(response);

            Assert.NotNull(employee);
            Assert.Equal(expectedName, employee.Name);
        }

        [Fact]
        public void Employee_GetById_NotFound()
        {
            //setup
            var userPositionId = 3;

            _employeeRepository.Setup(x => x.GetById(userPositionId))
                .Returns(Employees.FirstOrDefault(x => x.Id == userPositionId));

            //Act
            var result = _controller.Get(userPositionId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public void Employee_Update_TagName()
        {
            //setup
            var employeeId = 1;
            var expectedEmployeeName = "New Employee Name";

            var employee = Employees.FirstOrDefault(x => x.Id == employeeId);
            employee.Name = expectedEmployeeName;

            _employeeRepository.Setup(x => x.GetById(employee.Id)).Returns(Employees.FirstOrDefault(x => x.Id == employeeId));
            _employeeRepository.Setup(x => x.Update(employee)).Returns(Employees.FirstOrDefault(x => x.Id == employeeId));


            //Act
            var result = _controller.Update(employee);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var pos = okObjectResult.Value as EmployeeResponse;
            Assert.NotNull(pos);
            Assert.Equal(expectedEmployeeName, pos.Name);
        }

        [Fact]
        public void Tag_Delete_Existing_PositionName()
        {
            //setup
            var employeeId = 1;

            var employee = Employees.FirstOrDefault(x => x.Id == employeeId);


            _employeeRepository.Setup(x => x.Delete(employeeId)).Callback(() => Employees.Remove(employee));

            //Act
            var result = _controller.Delete(employeeId);

            //Assert
            var okObjectResult = result as StatusCodeResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.Null(Employees.FirstOrDefault(x => x.Id == employeeId));
        }

        [Fact]
        public void Employee_Delete_NotExisting_PositionName()
        {
            //setup
            var userPositionId = 3;

            var position = Employees.FirstOrDefault(x => x.Id == userPositionId);


            _employeeRepository.Setup(x => x.Delete(userPositionId)).Callback(() => Employees.Remove(position));

            //Act
            var result = _controller.Delete(userPositionId);

            //Assert
            Assert.Null(Employees.FirstOrDefault(x => x.Id == userPositionId));
        }

        [Fact]
        public void Employee_Create_PositionName()
        {
            //setup
            var employee = new Employee()
            {
                Id = 3,
                Name = "Name 3",
            };

            _employeeRepository.Setup(x => x.GetAll())
                .Returns(Employees);

            _employeeRepository.Setup(x => x.Create(It.IsAny<Employee>())).Callback(() =>
            {
                Employees.Add(employee);
            }).Returns(new Employee()
            {
                Id = 3,
                Name = "Name 3",
            });

            //Act
            var result = _controller.Create(_mapper.Map<EmployeeRequest>(employee));

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.NotNull(Employees.FirstOrDefault(x => x.Id == employee.Id));
        }

    }
}
