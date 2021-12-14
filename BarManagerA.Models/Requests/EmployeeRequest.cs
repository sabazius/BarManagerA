using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarManagerA.Models.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; set; }

        public Enums.EmployeeType EmployeeType { get; set; }

        public int ClientTable { get; set; }

    }
}
