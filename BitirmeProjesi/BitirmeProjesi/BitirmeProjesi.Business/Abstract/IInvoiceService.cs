using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Abstract
{
    public interface IInvoiceService
    {
        void Create(Invoice entity);
        void Update(Invoice entity);
        void Delete(Invoice entity);
        List<Invoice> GetAll();
        Invoice GetById(int id);
        Invoice CreateAndReturnInvoice(Invoice entity);
        List<Invoice> GetAllInvoiceByApartment();
        Invoice GetByIdWithUser(int id);
    }
}
