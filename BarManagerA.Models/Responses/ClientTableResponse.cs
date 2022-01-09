using BarManagerA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarManagerA.Models.Responses
{
    class ClientTableResponse
    {
        public int ID { get; set; }
        public int Seats { get; set; }
        public List<Location> Location { get; set; }
        public List<int> Orders { get; set; }
        public List<int> Furniture { get; set; }
    }
}
