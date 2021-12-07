using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarManagerA.BL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        Products IProductsService.Create(Products products)
        {         
            var index = _productsRepository.GetAll()?.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            products.Id = (int)(index != null ? index + 1 : 1);

            return _productsRepository.Create(products);
        }

        Products IProductsService.Delete(int id)
        {
            return _productsRepository.Delete(id);
        }

        IEnumerable<Products> IProductsService.GetAll()
        {
            return _productsRepository.GetAll();
        }

        Products IProductsService.GetById(int id)
        {
            return _productsRepository.GetById(id);
        }

        Products IProductsService.Update(Products products)
        {
            return _productsRepository.Update(products);
        }
    }
}
