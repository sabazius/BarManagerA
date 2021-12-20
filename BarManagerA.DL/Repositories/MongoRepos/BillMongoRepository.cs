using BarManagerA.DL.Interfaces;
using BarManagerA.Models.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using Bill = BarManagerA.Models.DTO.Bill;

namespace BarManagerA.DL.Repositories.MongoRepos
{
    public class BillMongoRepository : IBillRepository
    {
        private readonly IMongoCollection<Bill> _billCollection;


        public BillMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _billCollection = database.GetCollection<Bill>("Bills");
        }

        public Bill Create(Bill userPosition)
        {
            _billCollection.InsertOne(userPosition);
            return userPosition;
        }
         

        public Bill Delete(int id)
        {
            var bill = GetById(id);
            _billCollection.DeleteOne(bill => bill.Id == id);

            return bill;
        }

        public IEnumerable<Bill> GetAll()
        {
            return _billCollection.Find(bill => true).ToList();
        }

        public  Bill GetById(int id) =>
            _billCollection.Find(userPosition => userPosition.Id == id).FirstOrDefault();

        public Bill Update(Bill bill)
        {
            _billCollection.ReplaceOne(billToReplace => billToReplace.Id == bill.Id, bill);
            return bill;
        }
    }
}
