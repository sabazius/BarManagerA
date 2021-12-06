using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Create(Employee employee)
        {
            return _employeeRepository.Create(employee);
        }

        public Employee Update(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }

        public Employee Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
    }
}