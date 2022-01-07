using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.BL.Interfaces
{
    public interface IClientTableService
    {
        ClientTable Create(ClientTable clienttable);

        ClientTable Update(ClientTable clienttable);

        ClientTable Delete(int id);

        ClientTable GetById(int id);

        IEnumerable<ClientTable> GetAll();
    }
}

