using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.BL.Interfaces
{
    public interface ITagService
    {
        Tag Create(Tag tag);

        Tag Update(Tag tag);

        Tag Delete(int id);

        Tag GetById(int id);

        IEnumerable<Tag> GetAll();
    }
}
