using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Abstract
{
    public interface IPaidBillsService
    {
        void Create(PaidBills entity);
        void Update(PaidBills entity);
        void Delete(PaidBills entity);
        List<PaidBills> GetAll();
        PaidBills GetById(int id);
    }
}
