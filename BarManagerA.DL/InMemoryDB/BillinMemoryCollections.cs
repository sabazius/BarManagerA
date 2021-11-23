using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.DL.InMemoryDB
{
    public static class BillInMemoryCollection
    {
        public static List<Bill> TagDb = new List<Bill>()
        {
            new Bill()
            {
                Id = 1,
                Name = "TestNameA"
            },
            new Bill()
            {
                Id = 2,
                Name = "TestNameB"
            },
            new Bill()
            {
                Id = 3,
                Name = "TestNameC"
            }
        };
    }
}
