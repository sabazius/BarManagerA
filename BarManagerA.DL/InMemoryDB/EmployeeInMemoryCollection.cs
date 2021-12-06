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
                Name = "TestNameA"
            },
            new Employee()
            {
                Id = 2,
                Name = "TestNameB"
            },
            new Employee()
            {
                Id = 3,
                Name = "TestNameC"
            }
        };
    }
}