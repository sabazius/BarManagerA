using BarManagerA.BL.Interfaces;
using BarManagerA.DL.Interfaces;
using BarManagerA.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarManagerA.BL.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;

        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<Bill> Create(Bill bill)
        {

            var result =  await _billRepository.GetAll();
            var index = result.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            bill.Id = (int)(index != null ? index + 1 : 1);

            return await _billRepository.Create(bill);
        }

        public Task<Bill> Update(Bill bill)
        {
            return _billRepository.Update(bill);
        }

        public Task Delete(int id)
        {
            return _billRepository.Delete(id);
        }

        public Task<Bill> GetById(int id)
        {
            return _billRepository.GetById(id);
        }

        public Task <IEnumerable<Bill>> GetAll()
        {
            return _billRepository.GetAll();
        }
    }
}
