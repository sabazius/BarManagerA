using BarManagerA.DL.Interfaces;
using BarManagerA.Models.Configuration;
using BarManagerA.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BarManagerA.DL.Repositories.MongoRepos
{
    public class ClientTableMongoRepository : IClientTableRepository

    {
        private readonly IMongoCollection<ClientTable> _clienttableCollection;
        public ClientTableMongoRepository(IOptions<MongoDbConfiguration>config)
        {
            var client= new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _clienttableCollection = database.GetCollection<ClientTable>("ClientTable");
        }
        public ClientTable Create(ClientTable clienttable)
        {
            _clienttableCollection.InsertOne(clienttable);

            return clienttable;
          
        }

        public ClientTable Delete(int Id)
        {

            var clienttable = GetByID(Id);

            _clienttableCollection.DeleteOne(clienttable => clienttable.Id == Id);

            return clienttable;
        }

        public IEnumerable<ClientTable> GetAll()
        {
            return _clienttableCollection.Find(clienttable => true).ToList();
        }

        public ClientTable GetByID(int Id) =>
        
            _clienttableCollection.Find(userPosition => userPosition.Id == Id).FirstOrDefault();
        

        public ClientTable Update(ClientTable clienttable)
        {
            _clienttableCollection.ReplaceOne(clienttableToReplace => clienttableToReplace.Id == clienttable.Id, clienttable);

            return clienttable;
        }
    }
}
