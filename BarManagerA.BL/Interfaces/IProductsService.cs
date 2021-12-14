using BarManagerA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManagerA.BL.Interfaces
{
   public interface IProductsService
    {

        Products Create(Products products);

        Products Update(Products products);

        Products Delete(int id);

        Products GetById(int id);

        IEnumerable<Products> GetAll();
    }
}
