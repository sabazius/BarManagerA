using BarManagerA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarManagerA.DL.Interfaces
{
   public interface IProductsRepository
    {
        Task<Products> Create(Products products);

        Task<Products> Update(Products products);

        Task Delete(int id);

        Task<Products> GetById(int id);

        Task<IEnumerable<Products>> GetAll();

    }
}
