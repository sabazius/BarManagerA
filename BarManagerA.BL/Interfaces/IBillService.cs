using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.BL.Interfaces
{
    public interface IBillService
    {
        Bill Create(Bill bill);

        Bill Update(Bill bill);

        Bill Delete(int id);

        Bill GetById(int id);

        IEnumerable<Bill> GetAll();
    }
}
