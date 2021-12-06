using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.DL.InMemoryDB
{
    public static class ClientInMemoryCollection
    {
        public static List<Client> ClientDb = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Name = "TestNameA"
                MoneySpend = DateTime.Today,
                Discount = 1,
            },
            new Client()
            {
                Id = 2,
                Name = "TestNameB"
                MoneySpend = DateTime.Today,
                Discount = 2,
            },
            new Client()
            {
                Id = 3,
                Name = "TestNameC"
                MoneySpend = DateTime.Today,
                Discount = 3,
            }
        };
    }
}
