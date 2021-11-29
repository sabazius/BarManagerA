using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.DL.Interfaces
{
    public interface IBillRepository
    {
        Bill Create(Bill bill);

        Bill Update(Bill bill);

        Bill Delete(int id);

        Bill GetById(int id);

        IEnumerable<Bill> GetAll();
    }
}
