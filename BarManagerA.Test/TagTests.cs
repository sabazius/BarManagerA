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
    public class TagTests
    {
        private readonly IMapper _mapper;
        private Mock<ITagRepository> _tagRepository;
        private ITagService _tagService;
        private TagController _controller;
        private Mock<ILogger> _logger;

        private IList<Tag> Tags = new List<Tag>()
        {
            { new Tag() { Id = 1, Name = "xxx"} },
            { new Tag() { Id = 2, Name = "sss"} },
        };

        public TagTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _tagRepository = new Mock<ITagRepository>();

            _logger = new Mock<ILogger>();

            _tagService = new TagService(_tagRepository.Object, _logger.Object);

            //inject
            _controller = new TagController(_tagService, _mapper);
        }





        [Fact]
        public void Tag_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<ITagService>();

            mockedService.Setup(x => x.GetAll())
                .Returns(Tags);
            //inject
            var controller = new TagController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var positions = okObjectResult.Value as IEnumerable<TagResponse>;
            Assert.NotNull(positions);
            Assert.Equal(expectedCount, positions.Count());
        }

        [Fact]
        public void Tag_GetById_NameCheck()
        {
            //setup
            var tagId = 2;
            var expectedName = "sss";

            _tagRepository.Setup(x => x.GetById(tagId))
                .Returns(Tags.FirstOrDefault(x => x.Id == tagId));

            //Act
            var result = _controller.Get(tagId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as TagResponse;
            var tag = _mapper.Map<Tag>(response);

            Assert.NotNull(tag);
            Assert.Equal(expectedName, tag.Name);
        }

        [Fact]
        public void Tag_GetById_NotFound()
        {
            //setup
            var userPositionId = 3;

            _tagRepository.Setup(x => x.GetById(userPositionId))
                .Returns(Tags.FirstOrDefault(x => x.Id == userPositionId));

            //Act
            var result = _controller.Get(userPositionId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public void Tag_Update_TagName()
        {
            //setup
            var tagId = 1;
            var expectedTagName = "New Tag Name";

            var tag = Tags.FirstOrDefault(x => x.Id == tagId);
            tag.Name = expectedTagName;

            _tagRepository.Setup(x => x.GetById(tag.Id)).Returns(Tags.FirstOrDefault(x => x.Id == tagId));
            _tagRepository.Setup(x => x.Update(tag)).Returns(Tags.FirstOrDefault(x => x.Id == tagId));


            //Act
            var result = _controller.Update(tag);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var pos = okObjectResult.Value as TagResponse;
            Assert.NotNull(pos);
            Assert.Equal(expectedTagName, pos.Name);
        }

        [Fact]
        public void Tag_Delete_Existing_PositionName()
        {
            //setup
            var tagId = 1;

            var tag = Tags.FirstOrDefault(x => x.Id == tagId);


            _tagRepository.Setup(x => x.Delete(tagId)).Callback(() => Tags.Remove(tag));

            //Act
            var result = _controller.Delete(tagId);

            //Assert
            var okObjectResult = result as StatusCodeResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.Null(Tags.FirstOrDefault(x => x.Id == tagId));
        }

        [Fact]
        public void Tag_Delete_NotExisting_PositionName()
        {
            //setup
            var userPositionId = 3;

            var position = Tags.FirstOrDefault(x => x.Id == userPositionId);


            _tagRepository.Setup(x => x.Delete(userPositionId)).Callback(() => Tags.Remove(position));

            //Act
            var result = _controller.Delete(userPositionId);

            //Assert
            Assert.Null(Tags.FirstOrDefault(x => x.Id == userPositionId));
        }

        [Fact]
        public void Tag_Create_PositionName()
        {
            //setup
            var tag = new Tag()
            {
                Id = 3,
                Name = "Name 3",
            };

            _tagRepository.Setup(x => x.GetAll())
                .Returns(Tags);

            _tagRepository.Setup(x => x.Create(It.IsAny<Tag>())).Callback(() =>
            {
                Tags.Add(tag);
            }).Returns(new Tag()
            {
                Id = 3,
                Name = "Name 3",
            });

            //Act
            var result = _controller.Create(_mapper.Map<TagRequest>(tag));

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.NotNull(Tags.FirstOrDefault(x => x.Id == tag.Id));
        }

    }
}
