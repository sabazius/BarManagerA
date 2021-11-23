using BarManagerA.Models.Enums;
using System;

namespace BarManagerA.Models.DTO
{
    public class Bill
    {
        public int ID { get; set; }
        

        public double Amount{ get; set; }
        

        public BillStatus BillStatus { get; set; }
        

        public string PaymentType { get; set; }
        

        public DateTime DateTimeCreated { get; set; }
        //DateTimeCreated = DateTime.Now;

        public DateTime DateTimeFinished { get; set; }
        //DateTimeFinished = DateTime.Get;

    }
}
