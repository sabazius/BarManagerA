using System;
using System.Collections.Generic;
using System.Text;

namespace BarManagerA.Models.DTO
{
    class Bill_Models
    {
        public int d_ID { get; set; }
        //number

        public float d_Amount { get; set; }
        //mount

        public bool d_BillStatus { get; set; }
        // BillStatus enum

        public string d_PaymentType { get; set; }
        // PaymentType enum

        public int d_Created { get; set; }
        //date and time

        public int d_Finished { get; set; }
        //date and time

    }
}
