using System;
using System.Collections.Generic;
using System.Text;

namespace BarManagerA.Models.DTO
{
    class Bill_Models
    {
        public int d_ID { get; set; }
        

        public float Amount { get; set; }
        

        public bool BillStatus { get; set; }
        

        public string PaymentType { get; set; }
        

        public int Created { get; set; }
        

        public int Finished { get; set; }
        

    }
}
