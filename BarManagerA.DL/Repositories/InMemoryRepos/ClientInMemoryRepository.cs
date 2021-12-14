using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManagerA.DL.InMemoryDB;

namespace BarManagerA.DL.Repositories.InMemoryRepos
{
    public class ClientInMemoryRepository : IClientRepository
    {

        public ClientInMemoryRepository()
        {

        }

        public Client Create(Client client)
        {
            ClientInMemoryCollection.ClientDb.Add(client);

            return client;
        }

        public Client Delete(int id)
        {
            var client = ClientInMemoryCollection.ClientDb.FirstOrDefault(x => x.Id == id);

            if (client != null) ClientInMemoryCollection.ClientDb.Remove(client);

            return client;
        }

        public IEnumerable<Client> GetAll()
        {
            return ClientInMemoryCollection.ClientDb;
        }

        public Client GetById(int id)
        {
            return ClientInMemoryCollection.ClientDb.FirstOrDefault(x => x.Id == id);
        }

        public Client Update(Client client)
        {
            var item = ClientInMemoryCollection.ClientDb.FirstOrDefault(x => x.Id == client.Id);

            item.Name = client.Name;

            return client;
        }
    }
}
