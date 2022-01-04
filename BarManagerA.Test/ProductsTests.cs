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
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace BarManagerA.Test
{
    public class ProductsTests
    {
        private readonly IMapper _mapper;
        private Mock<IProductsRepository> _productsRepository;
        private IProductsService _productsService;
        private ProductsController _controller;
        private Mock<ILogger> _logger;

        private IList<Products> Products = new List<Products>()
        {
            { new Products() { Id = 1, Name = "Bananas"} },
            { new Products() { Id = 2, Name = "Apples"} },
        };

        public ProductsTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _productsRepository = new Mock<IProductsRepository>();

            _logger = new Mock<ILogger>();

            _productsService = new ProductsService(_productsRepository.Object, _logger.Object);

            //inject
            _controller = new ProductsController(_productsService, _mapper);
        }

        [Fact]
        public void Products_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IProductsService>();

            mockedService.Setup(x => x.GetAll())
                .Returns(Products);
            //inject
            var controller = new ProductsController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var positions = okObjectResult.Value as IEnumerable<Products>;
            Assert.NotNull(positions);
            Assert.Equal(expectedCount, positions.Count());
        }

        [Fact]
        public void Products_GetById_NameCheck()
        {
            //setup
            var productsId = 2;
            var expectedName = "Apples";

            _productsRepository.Setup(x => x.GetById(productsId))
                .Returns(Products.FirstOrDefault(x => x.Id == productsId));

            //Act
            var result = _controller.Get(productsId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as Products;
            var products = _mapper.Map<Products>(response);

            Assert.NotNull(products);
            Assert.Equal(expectedName, products.Name);
        }

        [Fact]
        public void Products_GetById_NotFound()
        {
            //setup
            var userPositionId = 3;

            _productsRepository.Setup(x => x.GetById(userPositionId))
                .Returns(Products.FirstOrDefault(x => x.Id == userPositionId));

            //Act
            var result = _controller.Get(userPositionId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public void Products_Update_ProductsName()
        {
            //setup
            var productsId = 1;
            var expectedProductsName = "New Products Name";

            var products = Products.FirstOrDefault(x => x.Id == productsId);
            products.Name = expectedProductsName;

            _productsRepository.Setup(x => x.GetById(products.Id)).Returns(Products.FirstOrDefault(x => x.Id == productsId));
            _productsRepository.Setup(x => x.Update(products)).Returns(Products.FirstOrDefault(x => x.Id == productsId));

            //Act
            var result = _controller.Update(products);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var pos = okObjectResult.Value as Products;
            Assert.NotNull(pos);
            Assert.Equal(expectedProductsName, pos.Name);
        }

        [Fact]
        public void Products_Delete_Existing_PositionName()
        {
            //setup
            var productsId = 1;

            var products = Products.FirstOrDefault(x => x.Id == productsId);

            _productsRepository.Setup(x => x.Delete(productsId)).Callback(() => Products.Remove(products)).Returns(products);

            //Act
            var result = _controller.Delete(products.Id);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.Null(Products.FirstOrDefault(x => x.Id == productsId));
        }

        [Fact]
        public void Products_Delete_NotExisting_PositionName()
        {
            //setup
            var userPositionId = 3;

            var position = Products.FirstOrDefault(x => x.Id == userPositionId);

            _productsRepository.Setup(x => x.Delete(userPositionId)).Callback(() => Products.Remove(position));

            //Act
            var result = _controller.Delete(userPositionId);

            //Assert
            Assert.Null(Products.FirstOrDefault(x => x.Id == userPositionId));
        }

        [Fact]
        public void Products_Create_PositionName()
        {
            //setup
            var products = new Products()
            {
                Id = 3,
                Name = "Name 3",
            };

            _productsRepository.Setup(x => x.GetAll())
                .Returns(Products);

            _productsRepository.Setup(x => x.Create(It.IsAny<Products>())).Callback(() =>
            {
                Products.Add(products);
            }).Returns(new Products()
            {
                Id = 3,
                Name = "Name 3",
            });

            //Act
            var result = _controller.Create(_mapper.Map<ProductsRequest>(products));

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.NotNull(Products.FirstOrDefault(x => x.Id == products.Id));
        }
    }
}

