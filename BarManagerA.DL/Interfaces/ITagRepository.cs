using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarManagerA.DL.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> Create(Tag tag);

        Task<Tag> Update(Tag tag);

        Task Delete(int id);

        Task<Tag> GetById(int id);

        Task<IEnumerable<Tag>> GetAll();
    }
}
