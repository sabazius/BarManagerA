using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarManagerA.DL.Interfaces
{
    public interface IBillRepository
    {
        Task <Bill> Create(Bill bill);

        Task <Bill> Update(Bill bill);

        Task Delete(int id);

        Task <Bill> GetById(int id);

        Task <IEnumerable<Bill>> GetAll();
    }
}
