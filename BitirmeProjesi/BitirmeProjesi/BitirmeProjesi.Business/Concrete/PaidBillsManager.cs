using BitirmeProjesi.Business.Abstract;
using BitirmeProjesi.Data.Abstract;
using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Concrete
{
   public class PaidBillsManager : IPaidBillsService
    {
        private readonly IPaidBillsRepository _paidBillsRepository;

        public PaidBillsManager(IPaidBillsRepository paidBillsRepository)
        {
            _paidBillsRepository = paidBillsRepository;
        }

        public void Create(PaidBills entity)
        {
            _paidBillsRepository.Create(entity);
        }

        public void Delete(PaidBills entity)
        {
            _paidBillsRepository.Delete(entity);
        }

        public List<PaidBills> GetAll()
        {
            return _paidBillsRepository.GetAll();
        }

        public PaidBills GetById(int id)
        {
            return _paidBillsRepository.GetById(id);
        }

        public void Update(PaidBills entity)
        {
            _paidBillsRepository.Update(entity);
        }
    }
}
