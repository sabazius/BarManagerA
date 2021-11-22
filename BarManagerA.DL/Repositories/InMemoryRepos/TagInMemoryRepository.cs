using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManagerA.DL.InMemoryDB;

namespace BarManagerA.DL.Repositories.InMemoryRepos
{
    public class TagInMemoryRepository : ITagRepository
    {

        public TagInMemoryRepository()
        {
            
        }

        public Tag Create(Tag tag)
        {
            TagInMemoryCollection.TagDb.Add(tag);

            return tag;
        }

        public Tag Delete(int id)
        {
            var tag = TagInMemoryCollection.TagDb.FirstOrDefault(x => x.Id == id);

            if (tag != null) TagInMemoryCollection.TagDb.Remove(tag);

            return tag;
        }

        public IEnumerable<Tag> GetAll()
        {
            return TagInMemoryCollection.TagDb;
        }

        public Tag GetById(int id)
        {
            return TagInMemoryCollection.TagDb.FirstOrDefault(x => x.Id == id);
        }

        public Tag Update(Tag tag)
        {
            var item = TagInMemoryCollection.TagDb.FirstOrDefault(x => x.Id == tag.Id);

            item.Name = tag.Name;

            return tag;
        }
    }
}
