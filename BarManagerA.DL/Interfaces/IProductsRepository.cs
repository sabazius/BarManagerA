using BarManagerA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManagerA.DL.Interfaces
{
   public interface IProductsRepository
    {
        Products Create(Products products);

        Products Update(Products products);

        Products Delete(int id);

        Products GetById(int id);

        IEnumerable<Products> GetAll();
        void GetById(object id);
    }
}
