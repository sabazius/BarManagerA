using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.BL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public Tag Create(Tag tag)
        {
            return _tagRepository.Create(tag);
        }

        public Tag Update(Tag tag)
        {
            return _tagRepository.Update(tag);
        }

        public Tag Delete(int id)
        {
            return _tagRepository.Delete(id);
        }

        public Tag GetById(int id)
        {
            return _tagRepository.GetById(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }
    }
}
