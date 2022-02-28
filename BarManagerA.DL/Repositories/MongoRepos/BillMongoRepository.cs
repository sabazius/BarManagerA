using BarManagerA.DL.Interfaces;
using BarManagerA.Models.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Bill> Create(Bill userPosition)
        {
            await _billCollection.InsertOneAsync(userPosition);
            return userPosition;
        }


        public async Task Delete(int id)
        {
            var bill = GetById(id);
            await _billCollection.DeleteOneAsync(bill => bill.Id == id);

        }

        public async Task<IEnumerable<Bill>> GetAll()
        {
            var result = await _billCollection.FindAsync(bill => true);
            return result.ToEnumerable();
        }

        public async Task<Bill> GetById(int id)
        {

            var result = await _billCollection.FindAsync(userPosition => userPosition.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<Bill> Update(Bill bill)
        {
           await  _billCollection.ReplaceOneAsync(billToReplace => billToReplace.Id == bill.Id, bill);
            return bill;
        }
    }
}
