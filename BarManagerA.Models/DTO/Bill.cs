using System;
using System.Collections.Generic;
using System.Text;

namespace BarManagerA.Models.DTO
{
   public class Bill
    {
        public int d_ID { get; set; }
        

        public float Amount { get; set; }
        

        public bool BillStatus { get; set; }
        

        public string PaymentType { get; set; }
        

        public int Created { get; set; }
        

        public int Finished { get; set; }
        

    }
}
