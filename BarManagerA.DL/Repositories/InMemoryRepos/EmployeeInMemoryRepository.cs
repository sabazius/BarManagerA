using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManagerA.DL.InMemoryDB;

namespace BarManagerA.DL.Repositories.InMemoryRepos
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
    {

        public EmployeeInMemoryRepository()
        {

        }

        public Employee Create(Employee employee)
        {
            EmployeeInMemoryCollection.EmployeeDb.Add(employee);

            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(x => x.Id == id);

            if (employee != null) EmployeeInMemoryCollection.EmployeeDb.Remove(employee);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return EmployeeInMemoryCollection.EmployeeDb;
        }

        public Employee GetById(int id)
        {
            return EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(x => x.Id == id);
        }

        public Employee Update(Employee employee)
        {
            var item = EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(x => x.Id == employee.Id);

            item.Name = employee.name;

            return employee;
        }
    }
}