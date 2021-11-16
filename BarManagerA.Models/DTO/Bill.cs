using BarManagerA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManagerA.Models.DTO
{
   public class Bill
    {
        public int ID { get; set; }
        

        public double Amount{ get; set; }
        

        public BillStatus BillStatus { get; set; }
        

        public string PaymentType { get; set; }
        

        public int Created { get; set; }
        

        public int Finished { get; set; }
        

    }
}
