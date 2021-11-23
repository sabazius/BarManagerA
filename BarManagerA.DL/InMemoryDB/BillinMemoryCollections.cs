using BarManagerA.Models.DTO;
using BarManagerA.Models.Enums;
using System;
using System.Collections.Generic;

namespace BarManagerA.DL.InMemoryDB
{
    public static class BillInMemoryCollection
    {
        public static List<Bill> BillDb = new List<Bill>()
        {
            new Bill()
            {
                    Amount = 5,
                    BillStatus = BillStatus.Paid,
                    DateTimeCreated = DateTime.Now,
                    DateTimeFinished = DateTime.Now,
                    ID = 749,
                    PaymentType = PaymentType.CreditCard
            },
            new Bill()
            {
                    Amount = 5,
                    BillStatus = BillStatus.Paid,
                    DateTimeCreated = DateTime.Now,
                    DateTimeFinished = DateTime.Now,
                    ID = 748,
                    PaymentType = PaymentType.Cash
            },
            new Bill()
            {
                    Amount = 5,
                    BillStatus = BillStatus.Paid,
                    DateTimeCreated = DateTime.Now,
                    DateTimeFinished = DateTime.Now,
                    ID = 999,
                    PaymentType = PaymentType.CreditCard
            }
        };
    }
}
