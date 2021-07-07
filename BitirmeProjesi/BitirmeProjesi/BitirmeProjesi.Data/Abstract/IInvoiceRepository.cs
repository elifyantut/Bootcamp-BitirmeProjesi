using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Abstract
{
    public interface IInvoiceRepository:IRepository<Invoice>
    {
        Invoice CreateAndReturnInvoice(Invoice entity);
        List<Invoice> GetAllInvoiceByApartment();
        Invoice GetByIdWithUser(int id);
    }
}
