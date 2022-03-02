using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarManagerA.BL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

       public async Task<Products> Create(Products products)
        {
            var result = await _productsRepository.GetAll();
            var index =result.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            products.Id = (int)(index != null ? index + 1 : 1);

            return await _productsRepository.Create(products);
        }

        public async Task Delete(int id)
        {
           await _productsRepository.Delete(id);
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            return await _productsRepository.GetAll();
        }

        public Task<Products> GetById(int id)
        {
            return _productsRepository.GetById(id);
        }

        public async Task<Products> Update(Products products)
        {
            return await _productsRepository.Update(products);
        }
    }
}
