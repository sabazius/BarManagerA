using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.DL.InMemoryDB
{
    public static class TagInMemoryCollection
    {
        public static List<Tag> TagDb = new List<Tag>()
        {
            new Tag()
            {
                Id = 1,
                Name = "TestNameA"
            },
            new Tag()
            {
                Id = 2,
                Name = "TestNameB"
            },
            new Tag()
            {
                Id = 3,
                Name = "TestNameC"
            }
        };
    }
}
