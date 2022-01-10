using BarManagerA.Models.DTO;
using System.Collections.Generic;

namespace BarManagerA.Models.Requests
{
   public class ClientTableRequest
    {
        public int Seats { get; set; }
        public List<Location> Location { get; set; }
        public List<int> Orders { get; set; }
        public List<int> Furniture { get; set; }
    }
}
