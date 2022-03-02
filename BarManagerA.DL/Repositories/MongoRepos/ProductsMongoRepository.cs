using BarManagerA.DL.Interfaces;
using BarManagerA.Models.Configuration;
using BarManagerA.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarManagerA.DL.Repositories.MongoRepos
{
    public class ProductsMongoRepository : IProductsRepository
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public ProductsMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _productsCollection = database.GetCollection<Products>("Products");
        }

        public async Task<Products> Create(Products products)
        {
            await _productsCollection.InsertOneAsync(products);

            return products;
        }

        public async Task Delete(int id)
        {
            await _productsCollection.DeleteOneAsync(Products => Products.Id == id);
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            var result = await _productsCollection.FindAsync(products => true);

            return result.ToEnumerable();
        }

        public async Task<Products> GetById(int id)
        {
            var result = await _productsCollection.FindAsync(products => products.Id == id);

            return result.FirstOrDefault();
        }

        public async Task<Products> Update(Products products)
        {
            var result = await _productsCollection.ReplaceOneAsync(productsToReplace => productsToReplace.Id == products.Id, products);

            return products;
        }
    }
}
