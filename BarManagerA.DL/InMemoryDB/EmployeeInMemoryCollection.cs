using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.DL.InMemoryDB
{
    public static class EmployeeInMemoryCollection
    {
        public static List<Employee> EmployeeDb = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                name = "TestNameA"
            },
            new Employee()
            {
                Id = 2,
                name = "TestNameB"
            },
            new Employee()
            {
                Id = 3,
                name = "TestNameC"
            }
        };
    }
}
