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

        public Products Create(Products products)
        {
            _productsCollection.InsertOne(products);
            return products;
        }

        public Products Delete(int id)
        {
            var product = GetById(id);

            _productsCollection.DeleteOne(Products => Products.Id == id);

            return product;
        }

        public IEnumerable<Products> GetAll()
        {
           return _productsCollection.Find(products => true).ToList();
        }

        public Products GetById(int id) =>
            _productsCollection.Find(products => products.Id == id).FirstOrDefault();
        

        public Products Update(Products products)
        {
            _productsCollection.ReplaceOne(productsToReplace => productsToReplace.Id == products.Id, products);
            return products;
        }
    }
}
