using System;
using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace BarManagerA.BL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly ILogger _logger;

        public TagService(ITagRepository tagRepository, ILogger logger)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }

        public Tag Create(Tag tag)
        {
            var index = _tagRepository.GetAll()?.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            tag.Id = (int) (index != null ? index + 1 : 1);

            return _tagRepository.Create(tag);
        }

        public Tag Update(Tag tag)
        {
            return _tagRepository.Update(tag);
        }

        public void Delete(int id)
        {
            _tagRepository.Delete(id);
        }

        public Tag GetById(int id)
        {
            return _tagRepository.GetById(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            _logger.Information("Tag GetAll");

            return _tagRepository.GetAll();
        }
    }
}
