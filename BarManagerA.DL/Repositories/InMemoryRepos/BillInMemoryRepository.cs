using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManagerA.DL.InMemoryDB;

namespace BarManagerA.DL.Repositories.InMemoryRepos
{
    public class BillInMemoryRepository : IBillRepository
    {

        public BillInMemoryRepository()
        {

        }

        public Bill Create(Bill bill)
        {
            BillInMemoryCollection.BillDb.Add(bill);

            return bill;
        }

        public Bill Delete(int id)
        {
            var bill = BillInMemoryCollection.BillDb.FirstOrDefault(x => x.ID == id);

            if (bill != null) BillInMemoryCollection.BillDb.Remove(bill);

            return bill;
        }

        public IEnumerable<Bill> GetAll()
        {
            return BillInMemoryCollection.BillDb;
        }

        public Bill GetById(int id)
        {
            return BillInMemoryCollection.BillDb.FirstOrDefault(x => x.ID == id);
        }

        public Bill Update(Bill bill)
        {
            var item = BillInMemoryCollection.BillDb.FirstOrDefault(x => x.ID == bill.ID);

            item.Amount = bill.Amount;
            item.BillStatus = bill.BillStatus;
            item.DateTimeCreated = bill.DateTimeCreated;
            item.DateTimeFinished = bill.DateTimeFinished;
            item.PaymentType = bill.PaymentType;
            
            return bill;
        }
    }
}
