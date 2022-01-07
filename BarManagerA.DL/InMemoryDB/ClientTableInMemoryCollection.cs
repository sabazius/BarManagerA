using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.DL.InMemoryDB
{
    public class ClientTableInMemoryCollection
    {
        public static List<ClientTable> ClientTableDB = new List<ClientTable>()
        {
            new ClientTable()
            {
                ID =1,
                Seats = 2
                //Location = 
                //Orders = new List<Orders>
                //{
                //    new Orders()
                //    {
                //        Id = 1
                //    }
                //}
                //Furniture = new List<Furniture>
                //{
                //    new Furniture()
                //    {
                //        Id = 1,
                //    }
                //}
                
            },
            new ClientTable()
            {
                ID = 2,
                Seats = 4
                //Location = 
                //Orders = new List<Orders>
                //{
                //    new Orders()
                //    {
                //        Id = 1
                //    }
                //}
                //Furniture = new List<Furniture>
                //{
                //    new Furniture()
                //    {
                //        Id = 1,
                //    }
                //}
            },
            new ClientTable()
            {
                ID = 3,
                Seats = 5
                //Location = 
                //Orders = new List<Orders>
                //{
                //    new Orders()
                //    {
                //        Id = 1
                //    }
                //}
                //Furniture = new List<Furniture>
                //{
                //    new Furniture()
                //    {
                //        Id = 1,
                //    }
                //}
            }
        };
    }
}
