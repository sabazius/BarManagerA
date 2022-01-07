using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManagerA.DL.InMemoryDB;

namespace BarManagerA.DL.Repositories.InMemoryRepos
{
    public class ClientTableInMemoryRepository : IClientTableRepository
    {
        public ClientTableInMemoryRepository()
        {

        }

        public ClientTable Create(ClientTable clienttable)
        {
            ClientTableInMemoryCollection.ClientTableDB.Add(clienttable);
            return clienttable;
        }

        public ClientTable Delete(int ID)
        {

            var clienttable = ClientTableInMemoryCollection.ClientTableDB.FirstOrDefault(clienttable=>clienttable.ID== ID);

            if (clienttable != null) ClientTableInMemoryCollection.ClientTableDB.Remove(clienttable);

            return clienttable;
        }

        public IEnumerable<ClientTable> GetAll()
        {
            return ClientTableInMemoryCollection.ClientTableDB;
        }

        public ClientTable GetByID(int ID)
        {
            return ClientTableInMemoryCollection.ClientTableDB.FirstOrDefault(x => x.ID == ID);
        }

        public ClientTable Update(ClientTable clienttable)
        {
            var result = ClientTableInMemoryCollection.ClientTableDB.FirstOrDefault(x => x.ID == clienttable.ID);
            result.Seats = clienttable.Seats;
            return result;
        }
    }
}
