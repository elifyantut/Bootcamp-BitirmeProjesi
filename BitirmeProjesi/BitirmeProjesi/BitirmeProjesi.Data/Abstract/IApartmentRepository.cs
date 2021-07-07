using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Abstract
{
    public interface IApartmentRepository:IRepository<Apartment>
    {
        Apartment GetByIdWithUser(int id);
        List<Apartment> GetByUserIdWithUserAndInvoice(string id);
    }
}
