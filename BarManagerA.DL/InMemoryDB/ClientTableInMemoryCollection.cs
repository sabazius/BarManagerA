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
                Id =1,
                Seats = 2,
                Location = new List<Location>
                 {
                    new Location()
                    {
                        Id = 1,
                        Name = "A"
                    }
                },
                Orders = new List<int>
                {
                    1
                },
                Furniture = new List<int>
                {
                   2
                }

            },
            new ClientTable()
            {
                Id = 2,
                Seats = 4,
                Location = new List<Location>
                 {
                    new Location()
                    {
                        Id = 1,
                        Name = "B"
                    }
                },
                Orders = new List<int>
                {
                  5
                },
                Furniture = new List<int>
                {
                   6
                }
            },
            new ClientTable()
            {
                Id = 3,
                Seats = 5,
                Location = new List<Location>
                 {
                    new Location()
                    {
                        Id = 1,
                        Name = "C"
                    }
                },
                Orders = new List<int>
                {
                  3
                },
                Furniture = new List<int>
                {
                  7
                }
            }
        };
    }
}
