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
            },
            new ClientTable()
            {
                ID = 2,
                Seats = 4
            },
            new ClientTable()
            {
                ID = 3,
                Seats = 5
            }
        };
    }
}
