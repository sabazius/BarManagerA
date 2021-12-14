using BarManagerA.Models.Enums;
using System;

namespace BarManagerA.Models.Responses
{
    public class BillResponse
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public BillStatus BillStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeFinished { get; set; }

    }
}
