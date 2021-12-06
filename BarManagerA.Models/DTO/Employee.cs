namespace BarManagerA.Models.DTO
{
    public class Employee
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public Enums.EmployeeType EmployeeType { get; set; }

        public int ClientTable { get; set; }
    }
}