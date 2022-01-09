using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.DL.Interfaces
{
    public interface IClientTableRepository
    {
        ClientTable Create(ClientTable clienttable);

        ClientTable Update(ClientTable clienttable);

        ClientTable Delete(int Id);

        ClientTable GetByID(int Id);
        IEnumerable<ClientTable> GetAll();

    }
}
