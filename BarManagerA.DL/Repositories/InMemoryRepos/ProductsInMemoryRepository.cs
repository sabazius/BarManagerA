using BarManagerA.DL.InMemoryDB;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarManagerA.DL.Repositories.InMemoryRepos
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        public ProductsInMemoryRepository()
        {

        }

        public Products Create(Products products)
        {
            ProductsInMemoryCollection.ProductsDB.Add(products);
            return products;
        }

        public Products Delete(int id)
        {
            var products = ProductsInMemoryCollection.ProductsDB.FirstOrDefault(x => x.Id == id);

            if (products != null) ProductsInMemoryCollection.ProductsDB.Remove(products);

            return products;

           
        }

        public IEnumerable<Products> GetAll()
        {
            return ProductsInMemoryCollection.ProductsDB;
        }

        public Products GetById(int id)
        {
            return ProductsInMemoryCollection.ProductsDB.FirstOrDefault(x => x.Id == id);
        }

        public void GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Products Update(Products products)
        {
            var item = ProductsInMemoryCollection.ProductsDB.FirstOrDefault(x => x.Id == products.Id);

            item.Name = products.Name;

            return products;
        }
    }
}
