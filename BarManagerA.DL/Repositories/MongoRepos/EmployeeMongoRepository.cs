using BarManagerA.DL.Interfaces;
using BarManagerA.Models.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using Employee = BarManagerA.Models.DTO.Employee;

namespace BarManagerA.DL.Repositories.MongoRepos
{
    public class EmployeeMongoRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> _employeeCollection;


        public EmployeeMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _employeeCollection = database.GetCollection<Employee>("Employees");
        }

        public Employee Create(Employee userPosition)
        {
            _employeeCollection.InsertOne(userPosition);
            return userPosition;
        }

        public Employee Delete(int id)
        {
            var employee = GetById(id);
            _employeeCollection.DeleteOne(employee => employee.Id == id);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeCollection.Find(employee => true).ToList();
        }

        public Employee GetById(int id) =>
            _employeeCollection.Find(userPosition => userPosition.Id == id).FirstOrDefault();

        public Employee Update(Employee employee)
        {
            _employeeCollection.ReplaceOne(employeeToReplace => employeeToReplace.Id == employee.Id, employee);
            return employee;
        }
    }
}