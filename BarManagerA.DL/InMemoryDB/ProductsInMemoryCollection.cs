
using BarManagerA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManagerA.DL.InMemoryDB
{
    public static class ProductsInMemoryCollection
    {
        public static List<Products> ProductsDB = new List<Products>()
        {
        new Products()
        {
            Id = 1,
                Name = "TestNameA",
                Price = 1000
        },
         new Products()
        {
            Id = 2,
                Name = "TestNameB",
                Price = 2000
        },
          new Products()
        {
            Id = 3,
                Name = "TestNameC",
                Price = 3000
        },
        };
    }
}
