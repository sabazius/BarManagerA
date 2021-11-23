using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.DL.Interfaces
{
    public interface ITagRepository
    {
        Tag Create(Tag tag);

        Tag Update(Tag tag);

        Tag Delete(int id);

        Tag GetById(int id);

        IEnumerable<Tag> GetAll();
    }
}
