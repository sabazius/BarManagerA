using System.Collections.Generic;

namespace BarManagerA.Models.DTO
{
    public class ClientTable
    {
        public int ID { get; set; }
        public int Seats { get; set; }
        public Location Location { get; set; }
        public List<int> Orders { get; set; }
        public List<int> Furniture { get; set; }
}
} 
