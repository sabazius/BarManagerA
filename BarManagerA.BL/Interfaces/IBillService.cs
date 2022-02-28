using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarManagerA.BL.Interfaces
{
    public interface IBillService
    {
        Task <Bill> Create(Bill bill);

        Task <Bill> Update(Bill bill);

        Task Delete(int id);

        Task <Bill>  GetById(int id);

        Task <IEnumerable<Bill>> GetAll();
    }
}
